using Application.Commands;
using Application.Commands.Pessoa;
using Application.DTOs;
using Application.Handlers;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("v1/pessoas")]
    public class PessoaController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<PessoaDTO>> GetAsync(
           [FromServices] IPessoaRepository repository)
        {
            var result = await repository.GetAll();
            return result.Select(x => new PessoaDTO
            {
                Id = x.Id,
                Idade = x.Idade,
                CPF = x.CPF,
                Nome = x.Nome,
                CodigoCidade = x.Cidade != null ? x.Cidade.Id : 0
            });

        }

        [Route("/v1/pessoas/{id:int}")]
        [HttpGet]
        public async Task<Pessoa> GetByIdAsync(
           [FromRoute] int id,
           [FromServices] IPessoaRepository repository)
        {
            return await repository.GetById(id);

        }

        [Route("")]
        [HttpPost]
        public async Task<GenericCommandResult> PostAsync(
            [FromBody] CreatePessoaCommand command,
            [FromServices] PessoaHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);

        }

        [Route("")]
        [HttpPut]
        public async Task<GenericCommandResult> PutAsync(
            [FromBody] UpdatePessoaCommand command,
            [FromServices] PessoaHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);

        }

        [Route("/v1/pessoas/{id:int}")]
        [HttpDelete]
        public async Task<bool> DeleteAsync(
          [FromRoute] int id,
           [FromServices] IPessoaRepository repository)
        {
            return await repository.Delete(id);

        }
    }
}