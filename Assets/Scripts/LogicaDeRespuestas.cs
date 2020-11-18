using System;

public class LogicaDeRespuestas
{
    private IControladorRespuestasMono controladorRespuestasMono;

    public LogicaDeRespuestas(IControladorRespuestasMono controladorRespuestasMono)
    {
        this.controladorRespuestasMono = controladorRespuestasMono;
    }

    public void CalcularResultadoDeOperacionActual(int numeroIngresado, int tabla, int numeroActual)
    {
        var resultado = CalcularResultadoDeLaOpeacionPrincipalDeLaLudica(tabla, numeroActual);
        if(resultado == numeroIngresado)
        {
            controladorRespuestasMono.RespuestaCorrecta(resultado.ToString()); 
        }
        else
        {
            controladorRespuestasMono.RespuestaIncorrecta(resultado.ToString());
        }
    }

    public int ConvertStringToInt(string text)
    {
        if (int.TryParse(text, out var result))
        {
            return result;
        }
        throw new FormatoDeDatoIngresadoNoEsValido($"El dato {text}, no es valido como respuesta");
    }

    public int CalcularResultadoDeLaOpeacionPrincipalDeLaLudica(int tabla, int numeroActual)
    {
        var multiplicacion = tabla * numeroActual;
        var primerNumero = multiplicacion / 10;
        var segudoNumero = multiplicacion % 10;
        return primerNumero + segudoNumero;
    }
}