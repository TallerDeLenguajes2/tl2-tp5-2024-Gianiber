namespace Tienda
{
    public class PresupuestosDetalle
    {
        private Producto producto;
        private int cantidad;

        public PresupuestosDetalle(){}

        public PresupuestosDetalle(Producto producto, int cantidad)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
        }

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public Producto Producto { get => producto; set => producto = value; }
    }
}