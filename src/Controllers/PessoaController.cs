using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
    public ActionResult<List<Pessoa>> Get(){
    //  Pessoa pessoa=new Pessoa();
     // Contrato contrato=new Contrato(50.5,"abc123");
    //  pessoa.Contratos.Add(contrato);
    var result=_context.Pessoas.Include(p=>p.Contratos).ToList();
    if(!result.Any()) return NoContent();
    return Ok(result);
   

    }
    [HttpPost]
    public ActionResult<Pessoa> Post(Pessoa pessoa){
      _context.Pessoas.Add(pessoa);
      _context.SaveChanges();

      return Created("criado",pessoa);

    }

      [HttpPut("{id}")]
        public ActionResult<Object> Update([FromRoute]int id,[FromBody]Pessoa pessoa){
       try
       {
        var result=_context.Pessoas.SingleOrDefault(e=>e.Id==id);
          if(result is null)
          { return NotFound(new{
            msg =" Registro não Encontrado",
            status=HttpStatusCode.NotFound
          });
          }
        _context.Pessoas.Update(pessoa);
        _context.SaveChanges();
       }
       catch(System.Exception)
       {
        return BadRequest(new{
        msg="Houve erro ao enviar solicitação de atualzicao"+ 
         " do id "+ id,
        status=HttpStatusCode.BadRequest
      });
       }
      return Ok(new{
        msg="Dados do id "+ id+" atualizados",
        status=HttpStatusCode.OK
      });

    }


 [HttpDelete("{id}")]
     public ActionResult<Object> Delete([FromRoute]int id){
    var result=_context.Pessoas.SingleOrDefault(e=>e.Id==id);
    if(result is null)
    {
        return BadRequest(new{
          msg="Conteúdo inexistente, solicitação inválida",
          status=HttpStatusCode.BadRequest
        });
    }
    _context.Pessoas.Remove(result);
    _context.SaveChanges();
    return Ok(new{
      msg="deletado pessoa de ID "+id,
      status=HttpStatusCode.OK});
    }
}

