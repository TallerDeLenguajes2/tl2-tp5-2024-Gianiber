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
                DateTime fechaEntrada = DateTime.Now;
                var consulta = $@"INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES ('{presupuesto.NombreDestinatario}',{fechaEntrada});";
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
                var consulta = @"SELECT * FROM Presupuestos;";
                SqliteCommand comando = new SqliteCommand(consulta,sqliteconex);
                SqliteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Presupuestos presupuestoNew = new Presupuestos();
                    presupuestoNew.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    presupuestoNew.NombreDestinatario = reader["NombreDestinatario"].ToString();
                    presupuestoNew.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    presupuestos.Add(presupuestoNew);
                }
                sqliteconex.Close();
            }
            return presupuestos;
        }

        public Presupuestos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}