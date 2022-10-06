using Shared.Commands;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Cidade;

public class CreateCidadeCommand : ICommand
{
    public CreateCidadeCommand() { }

    public CreateCidadeCommand(string nome, string uF)
    {
        Nome = nome;
        UF = uF;
    }

    [Required]
    [MaxLength(200, ErrorMessage = "Tamanho máximo - 200")]
    public string Nome { get; set; }

    [Required]
    [StringLength(2, ErrorMessage = "Tamanho máximo - 2")]
    public string UF { get; set; }
}
