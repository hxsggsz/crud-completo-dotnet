using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataController.Controllers
{


  [Route("api")]
  [ApiController]
  public class DataController : ControllerBase
  {
    [HttpGet("data")]
    public IActionResult ObterHora()
    {
      var Obj = new
      {
        Data = DateTime.Now.ToLongDateString(),
        Hora = DateTime.Now.ToShortTimeString()
      };

      return Ok(Obj);
    }
    [HttpGet("apresentar")]
    public IActionResult Apresentar(string nome)
    {
      var mensagem = $"olá, me chamo {nome}";

      return Ok(new { mensagem });
    }
  }
}