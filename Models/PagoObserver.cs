public abstract class PagoObserver
{
    public string nombreUsuario;
    public abstract void Notificar(double monto, List<string> resumen);
    public abstract string CrearMensaje(double monto, List<string> resumen);
    public abstract bool EnviarMensaje(string mensaje);
}

public class WhatsappObs : PagoObserver
{
    private string telefono;
    public WhatsappObs(Usuario usuario)
    {
        this.nombreUsuario = usuario.GetNombre();
        this.telefono = usuario.GetTelefono();
    }

    public override string CrearMensaje(double monto, List<string> resumen)
    {
        string resumenSalida = "";
        foreach (var r in resumen)
        {
            resumenSalida += r;
            resumenSalida += "--Mas datos \n";
        }
        return resumenSalida;
    }

    public override bool EnviarMensaje(string mensaje)
    {
          // usando alguna api
        throw new NotImplementedException();
    }

    public override void Notificar(double monto, List<string> resumen)
    {
        string mensaje = CrearMensaje(monto, resumen);
        EnviarMensaje(mensaje);
        // API real para enviar el mensaje
    }
}

public class MailObs : PagoObserver
{
    private string correo;

    public MailObs(Usuario usuario)
    {
        this.nombreUsuario = usuario.GetNombre();
        this.correo = usuario.GetCorreo();
    }

    public override string CrearMensaje(double monto, List<string> resumen)
    {
        string resumenSalida = "";
        foreach (var r in resumen)
        {
            resumenSalida += r;
            resumenSalida += "--Mas datos \n";
        }
        return resumenSalida;
    }

    public override bool EnviarMensaje(string mensaje)
    {
        // usando alguna api
        throw new NotImplementedException();
    }

    public override void Notificar(double monto, List<string> resumen)
    {
        string mensaje = CrearMensaje(monto, resumen);
        EnviarMensaje(mensaje);
        // Aquí podrías usar un cliente SMTP real
    }
}
