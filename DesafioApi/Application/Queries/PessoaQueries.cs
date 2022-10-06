using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Queries;

public static class PessoaQueries
{
    public static Expression<Func<Pessoa, bool>> GetById(int id)
    {
        return x => x.Id == id;
    }
}
