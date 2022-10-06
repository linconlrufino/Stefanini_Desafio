using Application.Commands;
using Application.Commands.Cidade;
using Application.Handlers;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("v1/cidades")]
    public class CidadeController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Cidade>> GetAsync(
           [FromServices] ICidadeRepository repository)
        {
            return await repository.GetAll();

        }

        [Route("/v1/cidades/{id:int}")]
        [HttpGet]
        public async Task<Cidade> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] ICidadeRepository repository)
        {
            return await repository.GetById(id);

        }

        [Route("/v1/cidades/{nome}")]
        [HttpGet]
        public async Task<Cidade> GetByIdAsync(
            [FromRoute] string nome,
            [FromServices] ICidadeRepository repository)
        {
            return await repository.GetByName(nome);

        }

        [Route("")]
        [HttpPost]
        public async Task<GenericCommandResult> PostAsync(
            [FromBody] CreateCidadeCommand command,
            [FromServices] CidadeHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);

        }

        [Route("")]
        [HttpPut]
        public async Task<GenericCommandResult> PutAsync(
            [FromBody] UpdateCidadeCommand command,
            [FromServices] CidadeHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);

        }

        [Route("/v1/cidades/{id:int}")]
        [HttpDelete]
        public async Task<bool> DeleteAsync(
           [FromRoute] int id,
            [FromServices] ICidadeRepository repository)
        {
            return await repository.Delete(id);

        }
    }
}