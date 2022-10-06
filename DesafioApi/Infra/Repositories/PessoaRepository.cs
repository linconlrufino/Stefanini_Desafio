using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly DesafioContext _context;

    public PessoaRepository(DesafioContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(Pessoa pessoa)
    {
        try
        {
            await _context.Pessoas.AddAsync(pessoa);

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
            var pessoa = await _context.Pessoas
                            .FirstOrDefaultAsync(PessoaQueries.GetById(id));

            _context.Pessoas.Remove(pessoa);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Pessoa>> GetAll()
    {
        try
        {
            return await _context.Pessoas.Include(x => x.Cidade)
                        .OrderBy(x => x.Id).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Pessoa> GetById(int id)
    {
        try
        {
            return await _context.Pessoas.Include(x => x.Cidade)
                      .FirstOrDefaultAsync(PessoaQueries.GetById(id));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Update(Pessoa pessoa)
    {
        try
        {
            _context.Update(pessoa);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> VerificarSeCpfExiste(string cpf)
    {
        try
        {
            return await _context.Pessoas.AnyAsync(x => x.CPF == cpf);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
