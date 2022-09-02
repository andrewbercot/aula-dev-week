using System.Collections.Generic;
 namespace src.Models;

public class Pessoa
{

    public Pessoa()
    {
        this.Nome="Template";
        this.Idade=0;
        this.Contratos=new List<Contrato>();
        this.Ativado=true;
    }

    public Pessoa(string nome,int idade,string cpf)
    {
        this.Nome=nome;
        this.Idade=idade;
        this.Cpf=cpf;
        this.Ativado=true;
    }
    public string Nome {get;set;}
    public string? Cpf { get; set; }
    public bool? Ativado{get;set;}
    public int Idade{ get; set; }
    public List<Contrato> Contratos{ get; set; }

    public int Id { get; set; }
    
}    