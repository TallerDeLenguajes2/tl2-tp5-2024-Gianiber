using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Tienda;
using RepositoriosTienda;

namespace ControladoresTienda;

[ApiController]
[Route("[controller]")]

public class PresupuestoController : ControllerBase
{
    private PresupuestosRepository repo = new PresupuestosRepository();
    [HttpGet]
    public IEnumerable<Presupuestos> Get()
    {
        return repo.GetAll();
    }

    [HttpPost]
    public ActionResult Post(Presupuestos presu)
    {
        repo.Create(presu);
        return Created("Presupuesto creado",presu);
    }
}