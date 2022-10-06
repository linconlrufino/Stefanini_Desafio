using Domain.Entities;

namespace Application.DTOs;

public class PessoaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int CodigoCidade { get; set; }
    public int Idade { get; set; }
}

