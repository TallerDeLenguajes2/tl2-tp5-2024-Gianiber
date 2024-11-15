using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Tienda;
using RepositoriosTienda;

namespace ControladoresTienda;

[ApiController]
[Route("[controller]")]

public class ProductoController : ControllerBase
{
    private ProductosRepository repo = new ProductosRepository();
    [HttpGet]
    public IEnumerable<Producto> Get()
    {
        return repo.GetAll();
    }

    [HttpPost]
    public ActionResult Post(Producto producto)
    {
        repo.Create(producto);
        return Created("Producto creado",producto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id,Producto updtProducto)
    {
        repo.Update(id,updtProducto);
        return Ok();
    }
}