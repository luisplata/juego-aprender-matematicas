using UnityEngine;

public class LogicaDeRuleta
{
    private IRuletaMono logicaMono;
    private int numeroMin, numeroMax;
    private int numeroAnterior;
    private int cantidadDeIntentosDeControl;
    public LogicaDeRuleta(IRuletaMono ruleta)
    {
        logicaMono = ruleta;
        numeroMin = 1;
        numeroMax = 10;
        numeroAnterior = 0;
        cantidadDeIntentosDeControl = 5;
    }

    public void CalcularNumeroDeRuleta()
    {
        var numeroRandom = 0;
        var control = 0;
        do
        {
            numeroRandom = ServiceLocator.Instance.GetService<ICalculosGenerales>().CalcularintRandom(numeroMin, numeroMax);
            control++;
        } while (numeroRandom == numeroAnterior && control <= cantidadDeIntentosDeControl);

        numeroAnterior = numeroRandom;

        ServiceLocator.Instance.GetService<IManejoDeDatosDelJuego>().GuardarTablaDeMultiplicar(numeroRandom);

        logicaMono.MostrarResultadoEnLaPantalla(numeroRandom);
    }
}