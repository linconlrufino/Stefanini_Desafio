namespace Domain.Entities;

public class Pessoa
{
    public Pessoa() { }

    public Pessoa(string nome, string cPF, Cidade cidade, int idade)
    {
        Nome = nome;
        CPF = cPF;
        Cidade = cidade;
        Idade = idade;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public Cidade Cidade { get; private set; }
    public int Idade { get; private set; }

    public void Update(string nome, string cPF, Cidade cidade, int idade)
    {
        if (nome is not null)
            Nome = nome;

        if (cPF is not null)
            CPF = cPF;

        if (cidade is not null)
            Cidade = cidade;

        if (idade > 0)
            Idade = idade;
    }
}
