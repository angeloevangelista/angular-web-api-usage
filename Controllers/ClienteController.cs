using System.Collections.Generic;
using System.Linq;
using angular_web_api_usage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angular_web_api_usage.Controllers
{
  [Controller]
  public class ClienteController
  {
    private readonly AngularWebApiContext _context;

    public ClienteController(AngularWebApiContext context)
    {
      _context = context;
    }

    [Route("clientes")]
    [HttpGet]
    public IEnumerable<Cliente> Index()
    {
      return _context.Clientes.AsNoTracking().ToList();
    }
  }
}
