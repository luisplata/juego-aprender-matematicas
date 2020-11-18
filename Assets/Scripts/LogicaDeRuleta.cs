using UnityEngine;

public class LogicaDeRuleta
{
    private IRuletaMono logicaMono;
    private int numeroMin, numeroMax;
    public LogicaDeRuleta(IRuletaMono ruleta)
    {
        logicaMono = ruleta;
        numeroMin = 1;
        numeroMax = 10;
        NumeroAnterior = 0;
        CantidadDeIntentosDeControl = 5;
    }

    public int NumeroAnterior { get; set; }
    public int CantidadDeIntentosDeControl { get; set; }

    public void CalcularNumeroDeRuleta()
    {
        var numeroRandom = 0;
        var control = 0;
        do
        {
            numeroRandom = ServiceLocator.Instance.GetService<ICalculosGenerales>().CalcularintRandom(numeroMin, numeroMax);
            control++;
        } while (numeroRandom == NumeroAnterior && control <= CantidadDeIntentosDeControl);

        NumeroAnterior = numeroRandom;

        ServiceLocator.Instance.GetService<IManejoDeDatosDelJuego>().GuardarTablaDeMultiplicar(numeroRandom);

        logicaMono.MostrarResultadoEnLaPantalla(numeroRandom);
    }
}