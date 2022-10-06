using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Cidade
{
    public Cidade(string nome, string uF)
    {
        Nome = nome;
        UF = uF;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string UF { get; private set; }

    [JsonIgnore()]
    public List<Pessoa> Pessoas { get; private set; }

    public void Update(string nome, string uf)
    {
        if (nome is not null)
            Nome = nome;

        if (uf is not null)
            UF = uf;
    }
}