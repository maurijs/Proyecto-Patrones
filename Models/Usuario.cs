public class Usuario
{
    private int id;
    private string nombre;
    private string documento;
    private string contraseña;
    private string telefono;
    private string correo;

    private Carrito carrito;
    private PagoStrategy pagoStrategy;

    public Usuario(int id, string nombre, string doc, string pass, string telefono, string correo)
    {
        this.id = id;
        this.nombre = nombre;
        this.documento = doc;
        this.contraseña = pass;
        this.telefono = telefono;
        this.correo = correo;
        this.carrito = new Carrito();
    }
    public string GetNombre() => nombre;
    public string GetCorreo() => correo;
    public string GetTelefono() => telefono;

    public Carrito GetCarrito() => carrito;
    public PagoStrategy GetPagoStrategy() => pagoStrategy;
    public void SetPagoStrategy(PagoStrategy p) => pagoStrategy = p;

    public void NotificarCompraWpp() => pagoStrategy.AgregarObservador(new WhatsappObs(this));
    public void NotificarCompraMail() => pagoStrategy.AgregarObservador(new MailObs(this));
    public void QuitarNotificacionMail() => pagoStrategy.QuitarObservador(new MailObs(this));
    public void QuitarNotificacionWpp() => pagoStrategy.QuitarObservador(new WhatsappObs(this));
}
