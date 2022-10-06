using Shared.Commands;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Cidade;

public class UpdateCidadeCommand : ICommand
{
    public UpdateCidadeCommand() { }

    public UpdateCidadeCommand(int id, string nome, string uF)
    {
        Id = id;
        Nome = nome;
        UF = uF;
    }

    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(200, ErrorMessage = "Tamanho máximo - 200")]
    public string Nome { get; set; }

    [Required]
    [MaxLength(2, ErrorMessage = "Tamanho máximo - 2")]
    public string UF { get; set; }
}
