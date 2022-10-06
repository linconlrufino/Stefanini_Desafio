using Application.Commands;
using Application.Commands.Pessoa;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Handlers;

namespace Application.Handlers;

public class PessoaHandler :
    IHandler<CreatePessoaCommand>,
    IHandler<UpdatePessoaCommand>
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ICidadeRepository _cidadeRepository;

    public PessoaHandler(IPessoaRepository pessoaRepository, ICidadeRepository cidadeRepository)
    {
        _pessoaRepository = pessoaRepository;
        _cidadeRepository = cidadeRepository;
    }

    public async Task<ICommandResult> Handle(CreatePessoaCommand command)
    {
        if (await _pessoaRepository.VerificarSeCpfExiste(command.CPF))
            return new GenericCommandResult(false, "Ops, CPF já cadastrado!", command);

        var cidade = await _cidadeRepository.GetById(command.CodigoCidade);

        if (cidade is null)
            return new GenericCommandResult(false, "Ops, cidade não localizada!", command);

        var pessoa = new Pessoa(command.Nome, command.CPF, cidade, command.Idade);

        await _pessoaRepository.Create(pessoa);

        return new GenericCommandResult(true, "Registro cadastrado!", pessoa);
    }

    public async Task<ICommandResult> Handle(UpdatePessoaCommand command)
    {
        var pessoa = await _pessoaRepository.GetById(command.Id);

        if (pessoa is null)
            return new GenericCommandResult(false, "Ops, registro não localizado!", command);

        var cidade = await _cidadeRepository.GetById(command.CodigoCidade);

        if (cidade is null)
            return new GenericCommandResult(false, "Ops, Cidade não localizada!", command);

        pessoa.Update(command.Nome, command.CPF, cidade, command.Idade);

        await _pessoaRepository.Update(pessoa);

        return new GenericCommandResult(true, "Registro atualizado!", pessoa);
    }
}
