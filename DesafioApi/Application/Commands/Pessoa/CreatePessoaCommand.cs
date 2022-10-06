using Shared.Commands;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Pessoa;

public class CreatePessoaCommand : ICommand
{
    public CreatePessoaCommand() { }

    public CreatePessoaCommand(string nome, string cPF, int codigoCidade, int idade)
    {
        Nome = nome;
        CPF = cPF;
        CodigoCidade = codigoCidade;
        Idade = idade;
    }

    [Required]
    [MaxLength(300, ErrorMessage = "Tamanho máximo - 300")]
    public string Nome { get; set; }

    [Required]
    [MaxLength(11, ErrorMessage = "Tamanho máximo - 11")]
    public string CPF { get; set; }

    [Required]
    public int CodigoCidade { get; set; }

    [Required]
    public int Idade { get; set; }
}
