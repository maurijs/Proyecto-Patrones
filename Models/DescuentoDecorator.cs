public class DescuentoDecorator : IProducto
{
    private IProducto wrappee;
    private double descuento; // Valor entre 0 y 100

    public DescuentoDecorator(IProducto producto, double descuento)
    {
        this.wrappee = producto;
        this.descuento = descuento;
    }

    public string GetNombre() => wrappee.GetNombre();
    public string GetDescripcion() => wrappee.GetDescripcion();
    public string GetCodigo() => wrappee.GetCodigo();

    public double GetPrecio()
    {
        double total = wrappee.GetPrecio();
        return total - (total * descuento / 100);
    }

    public void CambiarStock(int cantidad)
    {
        wrappee.CambiarStock(cantidad);
    }

    public string Resumen()
    {
        return wrappee.Resumen();
    }
}
