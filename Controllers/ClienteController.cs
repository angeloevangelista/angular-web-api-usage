using System.Collections.Generic;
using System.Linq;
using angular_web_api_usage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angular_web_api_usage.Controllers
{
  [Controller]
  [Route("api/clientes")]
  public class ClienteController
  {
    private readonly AngularWebApiContext _context;

    public ClienteController(AngularWebApiContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Cliente> Index()
    {
      return _context.Clientes.AsNoTracking().ToList();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Show([FromRoute] int id)
    {
      var cliente = _context.Clientes
        .AsNoTracking()
        .FirstOrDefault(pre => pre.Id == id);

      if (cliente == null)
      {
        return new NotFoundResult();
      }

      return new OkObjectResult(cliente);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Cliente cliente)
    {
      var clienteEncontrado = _context.Clientes.Find(id);

      if (clienteEncontrado == null)
      {
        return new BadRequestResult();
      }

      clienteEncontrado.Nome = cliente.Nome;
      clienteEncontrado.Email = cliente.Email;
      clienteEncontrado.Endereco = cliente.Endereco;
      clienteEncontrado.Cidade = cliente.Cidade;

      _context.Entry<Cliente>(clienteEncontrado).State = EntityState.Modified;
      _context.SaveChanges();

      return new OkObjectResult(clienteEncontrado);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Destroy([FromRoute] int id)
    {
      var cliente = _context.Clientes.Find(id);

      if (cliente == null)
      {
        return new BadRequestResult();
      }

      _context.Entry<Cliente>(cliente).State = EntityState.Deleted;
      _context.SaveChanges();

      return new OkObjectResult(cliente);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Cliente cliente)
    {
      _context.Add(cliente);
      _context.SaveChanges();

      return new OkObjectResult(cliente);
    }
  }
}
