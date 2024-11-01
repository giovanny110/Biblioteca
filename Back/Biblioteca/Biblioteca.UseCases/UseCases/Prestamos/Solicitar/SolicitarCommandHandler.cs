using Biblioteca.DTOs.Commons;
using Biblioteca.Entities.Enumerations;
using Biblioteca.Entities.Pocos;
using Biblioteca.Interfaces.IRepositories;
using MediatR;
using System.Net;

namespace Biblioteca.UseCases.UseCases.Prestamos.Solicitar;

public class SolicitarCommandHandler : IRequestHandler<SolicitarCommand, MessageResult<bool>>
{
    private const int CANTIDAD_LIBROS_POR_CLIENTE = 3;

    private readonly IListaNegraRepository _listaNegraRepository;
    private readonly IPrestamosRepository _prestamosRepository;
    private readonly ILibroDetalleRepository _libroDetalleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SolicitarCommandHandler(IListaNegraRepository listaNegraRepository, IPrestamosRepository prestamosRepository, ILibroDetalleRepository libroDetalleRepository, IUnitOfWork unitOfWork)
    {
        _listaNegraRepository = listaNegraRepository;
        _prestamosRepository = prestamosRepository;
        _libroDetalleRepository = libroDetalleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<MessageResult<bool>> Handle(SolicitarCommand request, CancellationToken cancellationToken)
    {
        try
        {//1. Validar si esta en la lista negra
            bool existInBlackList = await _listaNegraRepository.CheckExist(request.IdUsuarioSolicitante, cancellationToken);

            if (existInBlackList)
                return MessageResult<bool>.Create(false, "El usuario no esta habilitado para prestamos", HttpStatusCode.BadRequest);

            //2. Validar si tiene menos de 3 peticiones
            int numberBookBorrowen = await _prestamosRepository.GetNumberBookBorrowdByCustomer(request.IdUsuarioSolicitante, cancellationToken);
            if (numberBookBorrowen == CANTIDAD_LIBROS_POR_CLIENTE)
                return MessageResult<bool>.Create(false, "El usuario ya supero el limite de prestamos", HttpStatusCode.BadRequest);

            //3. Validar si el libro esta disponible
            var book = await _libroDetalleRepository.GetBookAvailable(request.LibroId, cancellationToken);
            if (book is null)
                return MessageResult<bool>.Create(false, "El Libro no se encuentra disponible", HttpStatusCode.BadRequest);

            //4. Registrar Solicitud
            var newRequest = new Prestamo()
            {
                IdClienteSolicitante = request.IdUsuarioSolicitante,
                IdLibro = book.IdLibro,
                LibroCodigoBarra = book.CodigoBarra,
                IdEstadoPrestamo = (int)LoanStatus.PENDIENTE,
                FechaRegistro = DateTime.Now,
                FlagEstado = true,
                FlagEliminado = false
            };

            _prestamosRepository.Add(newRequest);

            await _unitOfWork.SaveChangesAsync();

            return MessageResult<bool>.Create(true, "Se registro la solicitud", HttpStatusCode.OK);

        }
        catch (Exception ex)
        {
            return MessageResult<bool>.Create(false, $"error inesperado => {ex.Message}", HttpStatusCode.InternalServerError);
        }

    }
}
