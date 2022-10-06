using Application.Commands;
using Application.Commands.Cidade;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Handlers;

namespace Application.Handlers;

public class CidadeHandler :
    IHandler<CreateCidadeCommand>,
    IHandler<UpdateCidadeCommand>
{
    private readonly ICidadeRepository _repository;

    public CidadeHandler(ICidadeRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICommandResult> Handle(CreateCidadeCommand command)
    {
        if (command.Nome is null || command.UF is null)
            return new GenericCommandResult(false, "Ops, parece que algo está errado!", command);

        var cidade = new Cidade(command.Nome, command.UF);

        await _repository.Create(cidade);

        return new GenericCommandResult(true, "Registro cadastrado!", cidade);
    }

    public async Task<ICommandResult> Handle(UpdateCidadeCommand command)
    {
        var cidade = await _repository.GetById(command.Id);

        if (cidade is null)
            return new GenericCommandResult(false, "Ops, registro não localizado!", command);

        cidade.Update(command.Nome, command.UF);

        await _repository.Update(cidade);

        return new GenericCommandResult(true, "Registro atualizado!", cidade);
    }
}