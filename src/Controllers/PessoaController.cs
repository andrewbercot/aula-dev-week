using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;
using Microsoft.EntityFrameworkCore;
namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController:ControllerBase{

private DatabaseContext _context { get; set; }

public PessoaController(DatabaseContext context)
{
  this._context=context;
}
    [HttpGet]
    public List<Pessoa> get(){
    //  Pessoa pessoa=new Pessoa();
     // Contrato contrato=new Contrato(50.5,"abc123");
    //  pessoa.Contratos.Add(contrato);
    return _context.Pessoas.Include(p=>p.Contratos).ToList();
   

    }
    [HttpPost]
    public Pessoa Post(Pessoa pessoa){
      _context.Pessoas.Add(pessoa);
      _context.SaveChanges();
      return pessoa;

    }

      [HttpPut("{id}")]
        public string Update([FromRoute]int id,[FromBody]Pessoa pessoa){
        _context.Pessoas.Update(pessoa);
        _context.SaveChanges();
      return "Dados do id "+ id+" atualizados";

    }

         [HttpDelete("{id}")]
        public string Delete([FromRoute]int id,[FromBody]Pessoa pessoa){

      return "Deletado dados do id "+ id+" atualizados";

    }
}

