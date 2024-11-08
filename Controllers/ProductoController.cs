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
    /*[HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Producto> Get()
    {
        using (var sqliteconex = new SqliteConnection("Data Source=Database/Tienda.db;"))
        {
            sqliteconex.Open();
            var consulta = @"SELECT * FROM Productos;";
            SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                int salida = Convert.ToInt32(reader["IdProducto"]);
            }
            sqliteconex.Close();
        }
    }*/
}