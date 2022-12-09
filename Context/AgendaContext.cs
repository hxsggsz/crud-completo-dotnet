using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
  public class AgendaContext : DbContext

  {
    public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
    {

    }
    public DbSet<Contatos> Contatos { get; set; }
    
    
  }
}