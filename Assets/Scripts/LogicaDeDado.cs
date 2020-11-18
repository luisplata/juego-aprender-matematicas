public class LogicaDeDado
{
    private IDadoMono logicaMono;
    private int numeroMin, numeroMax, numeroAnterior;
    private int cantidadDeIntentosDeControl;
    public LogicaDeDado(IDadoMono dado)
    {
        logicaMono = dado;
        numeroMin = 1;
        numeroMax = 10;
    }
    public void CalcularElNumeroDelDado()
    {
        var numeroRandom = 0;
        var control = 0;
        do
        {
            numeroRandom = ServiceLocator.Instance.GetService<ICalculosGenerales>().CalcularintRandom(numeroMin, numeroMax);
            control++;
        } while (numeroRandom == numeroAnterior && control <= cantidadDeIntentosDeControl);

        numeroAnterior = numeroRandom;

        ServiceLocator.Instance.GetService<IManejoDeDatosDelJuego>().GuardarNumeroDeLaOperacion(numeroRandom);

        logicaMono.AsignarResultadoDelDadoEnPantalla(numeroRandom);
    }
}