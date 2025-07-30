class Program
{
    static void Main(string[] args)
    {
        var usuario = new Usuario("Mauricio");

        var whatsappObs = new WhatsappObs(usuario, "+5491112345678");
        var mailObs = new MailObs(usuario, "mauricio@email.com");

        var pago = new Pago(new PagoMercadoPago());
        pago.AgregarObservador(whatsappObs);
        pago.AgregarObservador(mailObs);

        string resumen = "Compra de productos tecnológicos";
        pago.ProcesarPago(1200.0, resumen);

        Console.WriteLine("--- Quitando observador WhatsApp ---");
        pago.QuitarObservador(new WhatsappObs(usuario, ""));

        pago.ProcesarPago(500.0, "Compra adicional");
    }
}
