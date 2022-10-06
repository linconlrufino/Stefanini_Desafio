using Domain.Entities;

namespace Domain.Repositories;

public interface IPessoaRepository
{
    Task<bool> Create(Pessoa pessoa);
    Task<bool> Update(Pessoa pessoa);
    Task<bool> Delete(int id);
    Task<Pessoa> GetById(int id);
    Task<IEnumerable<Pessoa>> GetAll();
    Task<bool> VerificarSeCpfExiste(string cpf);
}
