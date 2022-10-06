using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class CidadeRepository : ICidadeRepository
{
    private readonly DesafioContext _context;

    public CidadeRepository(DesafioContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(Cidade cidade)
    {
        try
        {
            await _context.Cidades.AddAsync(cidade);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var cidade = await _context.Cidades.FirstOrDefaultAsync(x => x.Id == id);

            _context.Cidades.Remove(cidade);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Cidade>> GetAll()
    {
        try
        {
            return await _context.Cidades
                        .AsNoTracking()
                        .OrderBy(x => x.UF).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Cidade> GetById(int id)
    {
        try
        {
            return await _context.Cidades
                      .FirstOrDefaultAsync(CidadeQueries.GetById(id));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Cidade> GetByName(string nome)
    {
        try
        {
            return await _context.Cidades
                      .FirstOrDefaultAsync(CidadeQueries.GetByName(nome));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Update(Cidade cidade)
    {
        try
        {
            _context.Update(cidade);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
