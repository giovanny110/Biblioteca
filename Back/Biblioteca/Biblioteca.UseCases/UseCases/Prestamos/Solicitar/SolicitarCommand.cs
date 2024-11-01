using Biblioteca.DTOs.Commons;
using MediatR;

namespace Biblioteca.UseCases.UseCases.Prestamos.Solicitar;

public sealed record SolicitarCommand(int IdUsuarioSolicitante, int LibroId) : IRequest<MessageResult<bool>>;