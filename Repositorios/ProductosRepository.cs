using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Data.Sqlite;
using Tienda;

namespace RepositoriosTienda
{
    public class ProductosRepository : IProductosRepository
    {
        private string cadenaConexion = "Data Source=Database/Tienda.db;Cache=Shared";
        public void Create(Producto prod)
        {
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                var consulta = $@"INSERT INTO Productos (Descripcion, Precio) VALUES ('{prod.Descripcion}',{prod.Precio});";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                int reader = comando.ExecuteNonQuery();
                sqliteconex.Close();
            }
        }

        public List<Producto> GetAll()
        {
            List<Producto> productos = new List<Producto>();
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                var consulta = @"SELECT * FROM Productos;";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                SqliteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.Idproducto = Convert.ToInt32(reader["IdProducto"]);
                    producto.Descripcion = reader["Descripcion"].ToString();
                    producto.Precio = Convert.ToInt32(reader["Precio"]);
                    productos.Add(producto);
                }
                sqliteconex.Close();
            }
            return productos;
        }

        public Producto GetById(int id)
        {
            Producto producto = new Producto();
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                var consulta = $@"SELECT * FROM Productos WHERE idProducto = {id};";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                SqliteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    producto.Idproducto = Convert.ToInt32(reader["IdProducto"]);
                    producto.Descripcion = reader["Descripcion"].ToString();
                    producto.Precio = Convert.ToInt32(reader["Precio"]);
                }
                sqliteconex.Close();
            }
            return producto;
        }

        public void Remove(int id)
        {
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                var consulta = $@"DELETE FROM Productos WHERE idProducto = {id};";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                int reader = comando.ExecuteNonQuery();
                sqliteconex.Close();
            }
        }

        public void Update(int id,Producto producto)
        {
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                var consulta = $@"UPDATE Productos SET Descripcion = {producto.Descripcion}, Precio = {producto.Precio} WHERE idProducto = {id};";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                int reader = comando.ExecuteNonQuery();
                sqliteconex.Close();
            }
        }
    }
}