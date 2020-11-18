public class LogicaDeDado
{
    private IDadoMono logicaMono;
    private int numeroMin, numeroMax;

    public LogicaDeDado(IDadoMono dado)
    {
        logicaMono = dado;
        numeroMin = 1;
        numeroMax = 10;
        CantidadDeIntentosDeControl = 5;
    }

    public int CantidadDeIntentosDeControl { get; set; }
    public int NumeroAnterior { get; set; }

    public void CalcularElNumeroDelDado()
    {
        var numeroRandom = 0;
        var control = 0;
        do
        {
            numeroRandom = ServiceLocator.Instance.GetService<ICalculosGenerales>().CalcularintRandom(numeroMin, numeroMax);
            control++;
        } while (numeroRandom == NumeroAnterior && control <= CantidadDeIntentosDeControl);

        NumeroAnterior = numeroRandom;

        ServiceLocator.Instance.GetService<IManejoDeDatosDelJuego>().GuardarNumeroDeLaOperacion(numeroRandom);

        logicaMono.AsignarResultadoDelDadoEnPantalla(numeroRandom);
    }
}