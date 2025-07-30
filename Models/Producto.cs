public class Producto : IProducto
{
    private string nombre;
    private string descripcion;
    private double precio;
    private string codigo;
    private int stock;

    public Producto(string nombre, string descripcion, double precio)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.precio = precio;
        this.codigo = Guid.NewGuid().ToString();
        this.stock = 10; // Valor por defecto para probar
    }

    public void CambiarStock(int cantidad)
    {
        if (stock - cantidad <= 0)
            stock = 0;
        else
            stock -= cantidad;
    }

    public string GetCodigo()
    {
        return codigo;
    }

    public string GetDescripcion()
    {
        return descripcion;
    }

    public string GetNombre()
    {
        return nombre;
    }

    public double GetPrecio()
    {
        return precio;
    }

    public string Resumen()
    {
        // a modo de ejemplo
        return nombre + descripcion;
    }
}
