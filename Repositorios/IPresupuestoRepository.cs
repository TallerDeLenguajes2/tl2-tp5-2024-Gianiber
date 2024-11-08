using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Tienda;

namespace RepositoriosTienda
{
    public interface IPresupuestoRepository
    {
        public List<Presupuestos> GetAll();
        public Presupuestos GetById(int id);
        public void Create(Presupuestos presupuesto);
        public void Remove(int id);
    }
}