public class Sistema
{
    private List<IProducto> catalogo;

    public Sistema(List<IProducto> productos)
    {
        catalogo = productos;
    }

    public void MostrarCatalogo()
    {
        foreach (var p in catalogo)
            Console.WriteLine(p.Resumen());
    }

    public void MostrarCarrito(Usuario usuario)
    {
        usuario.GetCarrito().Resumen();
    }

    public void AgregarProductoCarrito(Usuario usuario, IProducto producto)
    {
        usuario.GetCarrito().AgregarProducto(producto, 1);
    }

    public void PagarCarrito(Usuario usuario)
    {
        usuario.GetCarrito().Pagar(usuario.GetPagoStrategy());
    }

    public void CancelarCarrito(Usuario usuario)
    {
        usuario.GetCarrito().Cancelar();
    }
}
