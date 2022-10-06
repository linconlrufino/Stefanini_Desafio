using Shared.Commands;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Pessoa;

public class UpdatePessoaCommand : ICommand
{
    public UpdatePessoaCommand() { }

    public UpdatePessoaCommand(int id, string nome, string cPF, int codigoCidade, int idade)
    {
        Id = id;
        Nome = nome;
        CPF = cPF;
        CodigoCidade = codigoCidade;
        Idade = idade;
    }

    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(300, ErrorMessage = "Tamanho máximo - 300")]
    public string Nome { get; set; }
    [Required]
    [StringLength(11, ErrorMessage = "Tamanho máximo - 11")]
    public string CPF { get; set; }

    [Required]
    public int CodigoCidade { get; set; }

    [Required]
    public int Idade { get; set; }
}
