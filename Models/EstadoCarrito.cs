public interface IEstadoCarrito
{
    void AgregarProducto(Carrito carrito, IProducto producto, int cantidad);
    void Cancelar(Carrito carrito);
    void Pagar(Carrito carrito, PagoStrategy pago);
}


public class EstadoActivo : IEstadoCarrito
{
    private static EstadoActivo instancia;

    private EstadoActivo() { }

    public static EstadoActivo GetInstancia()
    {
        if (instancia == null)
            instancia = new EstadoActivo();
        return instancia;
    }

    public void AgregarProducto(Carrito carrito, IProducto producto, int cantidad)
    {
        carrito.GetCarrito().Add(producto);
        carrito.SumarMonto(producto.GetPrecio() * cantidad);
    }

    public void Cancelar(Carrito carrito)
    {
        carrito.GetCarrito().Clear();
        carrito.CambiarEstado(EstadoCancelado.GetInstancia());
    }

    public void Pagar(Carrito carrito, PagoStrategy pago)
    {
        if (carrito.ProcesarPago(pago))
        {
            carrito.ActualizarStock();
            carrito.CambiarEstado(EstadoPagado.GetInstancia());
        }
    }

}

public class EstadoPagado : IEstadoCarrito
{
    private static EstadoPagado instancia;

    private EstadoPagado() { }

    public static EstadoPagado GetInstancia()
    {
        if (instancia == null)
            instancia = new EstadoPagado();
        return instancia;
    }

    public void AgregarProducto(Carrito carrito, IProducto producto, int cantidad)
    {
        // No se puede agregar productos
    }

    public void Cancelar(Carrito carrito)
    {
        // No se puede cancelar
    }

    public void Pagar(Carrito carrito, PagoStrategy pago)
    {
        // Ya está pagado
    }
}

public class EstadoCancelado : IEstadoCarrito
{
    private static EstadoCancelado instancia;

    private EstadoCancelado() { }

    public static EstadoCancelado GetInstancia()
    {
        if (instancia == null)
            instancia = new EstadoCancelado();
        return instancia;
    }

    public void AgregarProducto(Carrito carrito, IProducto producto, int cantidad)
    {
        carrito.CambiarEstado(EstadoActivo.GetInstancia());
        carrito.AgregarProducto(producto, cantidad);
    }

    public void Cancelar(Carrito carrito)
    {
        // Ya está cancelado
    }

    public void Pagar(Carrito carrito, PagoStrategy pago)
    {
        // No se puede pagar un carrito cancelado
    }
}
