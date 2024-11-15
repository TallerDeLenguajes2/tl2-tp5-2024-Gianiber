namespace Tienda
{
    public class Presupuestos
    {
        private int idPresupuesto;
        private string nombreDestinatario;
        private List<PresupuestosDetalle> detalle;
        private DateTime fechaCreacion;

        public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
        public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
        public List<PresupuestosDetalle> Detalle { get => detalle; set => detalle = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }

        public Presupuestos(){}

        public Presupuestos(string nombreDestinatario)
        {
            this.NombreDestinatario = nombreDestinatario;
        }
        public int MontoPresupuesto(){
            int monto = 0;
            foreach (PresupuestosDetalle detalleX in detalle)
            {
                monto += detalleX.Producto.Precio * detalleX.Cantidad;
            }
            return monto;
        }
        public double MontoPresupuestoConIva(){
            double monto = 0;
            double iva = 1.15;
            foreach (PresupuestosDetalle detalleX in detalle)
            {
                monto += detalleX.Producto.Precio * iva * detalleX.Cantidad;
            }
            return monto;
        }
        public int CantidadProductos(){
            int cant = 0;
            foreach (PresupuestosDetalle detalleX in detalle)
            {
                cant += detalleX.Cantidad;
            }
            return cant;
        }
    }
}