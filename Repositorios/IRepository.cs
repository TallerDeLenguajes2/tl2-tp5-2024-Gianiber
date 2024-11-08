using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Tienda;

namespace RepositoriosTienda
{
    public interface IProductosRepository
    {
        public List<Producto> GetAll();
        public Producto GetById(int id);
        public void Create(Producto producto);
        public void Remove(int id);
        public void Update(int id,Producto producto);
    }
}