using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContatoController.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class ContatoController : ControllerBase
  {
    private readonly AgendaContext _context;
    public ContatoController(AgendaContext context)
    {
      _context = context;
    }

    [HttpPost]
    public IActionResult CreateCrud(Contatos contato)
    {
      _context.Add(contato);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetCrud), new { id = contato.Id }, contato);
    }

    [HttpGet("teste/{id}")]
    public IActionResult GetCrud(int id)
    {
      var contato = _context.Contatos.Find(id);

      if (contato == null) return NotFound();

      return Ok(contato);
    }

    [HttpGet("{name}")]
    public IActionResult GetCrudByName(string name)
    {
      var nome = _context.Contatos.Where(x => x.Name.Contains(name));
      return Ok(nome);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCrud(int id, Contatos contato)
    {
      var GetId = _context.Contatos.Find(id);
      if (GetId == null) return NotFound();

      GetId.Name = contato.Name;
      GetId.Telefone = contato.Telefone;
      GetId.Ativo = contato.Ativo;

      _context.Update(GetId);
      _context.SaveChanges();

      return Ok(GetId);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCrud(int id)
    {
      var DeleteId = _context.Contatos.Find(id);
      if (DeleteId == null)
        return NotFound();

      _context.Remove(DeleteId);
      _context.SaveChanges();

      return NoContent();
    }
  }
}