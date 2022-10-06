using Domain.Entities;

namespace Domain.Repositories;

public interface ICidadeRepository
{
    Task<bool> Create(Cidade cidade);
    Task<bool> Update(Cidade cidade);
    Task<bool> Delete(int id);
    Task<Cidade> GetById(int id);
    Task<Cidade> GetByName(string nome);
    Task<IEnumerable<Cidade>> GetAll();
}
