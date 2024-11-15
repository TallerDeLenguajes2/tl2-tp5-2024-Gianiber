using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Data.Sqlite;
using Tienda;

namespace RepositoriosTienda
{
    public class PresupuestosRepository : IPresupuestoRepository
    {
        private string cadenaConexion = "Data Source=Database/Tienda.db;Cache=Shared";

        public void Create(Presupuestos presupuesto)
        {
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                string fechaEntrada = DateTime.Now.ToString("yyyy'-'MM'-'dd");
                var consulta = $@"INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES ('{presupuesto.NombreDestinatario}','{fechaEntrada}');";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                int reader = comando.ExecuteNonQuery();
                sqliteconex.Close();
            }
        }

        public List<Presupuestos> GetAll()
        {
            List<Presupuestos> presupuestos = new List<Presupuestos>();
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                var consulta = @"SELECT * FROM Presupuestos INNER JOIN PresupuestosDetalle USING (idPresupuesto);";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                SqliteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Presupuestos presupuestoNew = new Presupuestos();
                    presupuestoNew.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    presupuestoNew.NombreDestinatario = reader["NombreDestinatario"].ToString();
                    presupuestoNew.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    var consulta2 = $@"SELECT p.idPresupuesto,p.idProducto,Cantidad,Descripcion,Precio FROM PresupuestosDetalle p INNER JOIN Productos USING (idProducto) WHERE idPresupuesto = {presupuestoNew.IdPresupuesto};";
                    SqliteCommand comando2 = new SqliteCommand(consulta2,sqliteconex);
                    SqliteDataReader reader2 = comando2.ExecuteReader();
                    while (reader2.Read())
                    {
                        PresupuestosDetalle detalleNew = new PresupuestosDetalle();
                        Producto prod = new Producto();
                        List<PresupuestosDetalle> lista = new List<PresupuestosDetalle>();
                        prod.Idproducto = Convert.ToInt32(reader2["idProducto"]);
                        prod.Descripcion = reader2["Descripcion"].ToString();
                        prod.Precio = Convert.ToInt32(reader2["Precio"]);
                        detalleNew.Producto = prod;
                        detalleNew.Cantidad = Convert.ToInt32(reader2["Cantidad"]);
                        lista.Add(detalleNew);
                        presupuestoNew.Detalle = lista;
                    }
                    presupuestos.Add(presupuestoNew);
                }
                sqliteconex.Close();
            }
            return presupuestos;
        }

        public Presupuestos GetById(int id)
        {
            Presupuestos presupuesto = new Presupuestos();
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                var consulta = $@"SELECT * FROM Presupuestos WHERE idPresupuesto = {id};";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                SqliteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    presupuesto.IdPresupuesto = Convert.ToInt32(reader["IdPresupuesto"]);
                    presupuesto.NombreDestinatario = reader["NombreDestinatario"].ToString();
                    presupuesto.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                }
                sqliteconex.Close();
            }
            return presupuesto;
        }

        public void Remove(int id)
        {
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                var consulta = $@"DELETE FROM Presupuestos WHERE idPresupuesto = {id};";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                int reader = comando.ExecuteNonQuery();
                sqliteconex.Close();
            }
        }
        public void Add(int id,Producto prod,int cant)
        {
            using (SqliteConnection sqliteconex = new SqliteConnection(cadenaConexion))
            {
                sqliteconex.Open();
                var consulta = $@"INSERT INTO PresupuestosDetalle (idPresupuesto, idProducto, Cantidad) VALUES ('{id}','{prod.Idproducto}','{cant}');";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                int reader = comando.ExecuteNonQuery();
                sqliteconex.Close();
            }
        }
    }
}