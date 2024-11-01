using Biblioteca.UseCases.UseCases.Prestamos.Solicitar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers;

[ApiController]
[Route("api/prestamos")]
public class PrestamoController : ControllerBase
{
    private readonly ISender _sender;

    public PrestamoController(ISender sender) => _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Solicitar(
        [FromBody] SolicitarCommand request,
        CancellationToken cancellationToken) => Ok(await _sender.Send(request, cancellationToken));
}