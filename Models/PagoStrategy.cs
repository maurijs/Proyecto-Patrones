using System;
using System.Collections.Generic;
public abstract class PagoStrategy
{
    public List<PagoObserver> observadores;
    public void Notificar(double monto, List<string> resumen)
    {
        if (observadores.Count() > 0)
        {
            foreach (var o in observadores)
            {
                o.Notificar(monto, resumen);
            }
        }
    }
    public bool ProcesarPago(double monto, List<string> Resumen)
    {
        if (Pagar(monto))
        {
            Notificar(monto, Resumen);
            return true;
        }
        return false;
    }

    public void AgregarObservador(PagoObserver obs) => observadores.Add(obs);
    public void QuitarObservador(PagoObserver obs)
    {
        var observador = observadores.FirstOrDefault(o => o.GetType == obs.GetType);
        if(observador != null) observadores.Remove(observador);
    }
    public abstract bool Pagar(double monto);
}

public class PagoPayPal : PagoStrategy
{
    string datosPaypal;
    public override bool Pagar(double monto)
    {
        Console.WriteLine("[Paypal] Pagando: " + monto);
        return true;
    }
}

public class PagoTarjetaCredito : PagoStrategy
{
    public string titular;
    public string numeroTarjeta;
    public string Tarjeta;
    public int codigoSeguridad; 
    public int cantidadCuotas; 
    public override bool Pagar(double monto)
    {
        Console.WriteLine("[Tarjeta de crebdto] Pagando: " + monto);
        return true;
    }
}

public class PagoTarjetaDebito : PagoStrategy
{
    public string titular;
    public int codigoSeguridad;
    public string numeroTarjeta;
    public string Tarjeta;
    public override bool Pagar(double monto)
    {
        Console.WriteLine("[Tarjeta de debito] Pagando" + monto);
        return true;
    }
}

public class PagoMercadoPago : PagoStrategy
{
    public string titular;
    public string cvu;
    public string alias;
    public override bool Pagar(double monto)
    {
        Console.WriteLine("[MercadoPago] Pagando" + monto);
        return true;
    }
}
