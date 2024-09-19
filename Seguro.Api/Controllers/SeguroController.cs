using Crud.Domain.Commands.Seguros;
using Crud.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeguroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarSeguro([FromBody] CreateSeguroCommand command)
        {
            var seguroId = await _mediator.Send(command);
            return Ok(new { SeguroId = seguroId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterSeguro(int id)
        {
            var seguro = await _mediator.Send(new GetSeguroByIdQuery { Id = id });
            if (seguro == null)
                return NotFound();

            return Ok(seguro);
        }

        [HttpGet("relatorio")]
        public async Task<IActionResult> GerarRelatorio()
        {
            var mediaValorSeguro = await _mediator.Send(new GetMediaValorSeguroQuery());
            return Ok(new { MediaValorSeguro = mediaValorSeguro });
        }
    }
}