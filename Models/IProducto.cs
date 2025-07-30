public interface IProducto
{
    string GetNombre();
    string GetDescripcion();
    double GetPrecio();
    string GetCodigo();
    string Resumen();
    void CambiarStock(int cantidad);
}
