using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Queries;

public static class CidadeQueries
{
    public static Expression<Func<Cidade, bool>> GetById(int id)
    {
        return x => x.Id == id;
    }

    public static Expression<Func<Cidade, bool>> GetByName(string nome)
    {
        return x => x.Nome == nome;
    }
}
