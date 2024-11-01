using FluentValidation;

namespace Biblioteca.UseCases.UseCases.Prestamos.Solicitar;

public class SolicitarCommandValidation : AbstractValidator<SolicitarCommand>
{
    public SolicitarCommandValidation()
    {
        RuleFor(x => x.IdUsuarioSolicitante)
            .GreaterThan(0).WithMessage("El ID del usuario no es valido");

        RuleFor(x => x.LibroId)
            .GreaterThan(0).WithMessage("El ID de libro no es valido");
    }
}