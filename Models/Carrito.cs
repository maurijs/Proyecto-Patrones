public class Carrito
{
    private List<IProducto> productos = new();
    private double montoTotal = 0;
    private IEstadoCarrito estado = EstadoActivo.GetInstancia();

    public void AgregarProducto(IProducto producto, int cantidad)
    {
        estado.AgregarProducto(this, producto, cantidad);
    }

    public void Cancelar()
    {
        estado.Cancelar(this);
    }

    public void Pagar(PagoStrategy pago)
    {
        estado.Pagar(this, pago);
    }

    public void CambiarEstado(IEstadoCarrito nuevo)
    {
        estado = nuevo;
    }
    public List<IProducto> GetCarrito() => productos;

    public void SumarMonto(double monto) => montoTotal += monto;

    public double GetMontoTotal() => montoTotal;

    public bool ProcesarPago(PagoStrategy pago)
    {
        if (pago.ProcesarPago(GetMontoTotal(), Resumen()))
            foreach (var p in productos)
            {
                p.Resumen();
            }
            return true;
        return false;
    }

    public void ActualizarStock()
    {
        foreach (var p in productos)
            p.CambiarStock(1);
    }

    public List<string> Resumen()
    {
        var resumen = new List<string>();
        foreach (var p in productos)
        {
            resumen.Add(p.Resumen());
        }
        return resumen;
    }
}
