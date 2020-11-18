using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ControladorDeRespuestas : MonoBehaviour, IControladorRespuestasMono
{
    private LogicaDeRespuestas logica;
    [SerializeField] private Button botonParaMostrarRespuesta;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private TextMeshProUGUI dondeVanLasRespuestas;
    [SerializeField] private List<GameObject> cosasPorActivar, cosasPorDesactivar;

    private void Start()
    {
        logica = new LogicaDeRespuestas(this);
        botonParaMostrarRespuesta.onClick.AddListener(delegate {
            CalcularOperacion();
        });
        dondeVanLasRespuestas.text = "";
    }

    private void CalcularOperacion()
    {
        try
        {
            var numeroConvertido = logica.ConvertStringToInt(input.text);
            var tablaDeMultiplicar = ServiceLocator.Instance.GetService<IManejoDeDatosDelJuego>().ObtenerTablaDeMultiplicar();
            var numeroActual = ServiceLocator.Instance.GetService<IManejoDeDatosDelJuego>().ObtnerNumeroParaLaOperacion();
            Debug.Log("numeroConvertido " + numeroConvertido + " _ tablaDeMultiplicar " + tablaDeMultiplicar + " _ numeroActual " + numeroActual);
            logica.CalcularResultadoDeOperacionActual(numeroConvertido, tablaDeMultiplicar, numeroActual);
        }
        catch (FormatoDeDatoIngresadoNoEsValido e)
        {
            MostrarMensajeDeError(e.Message);
        }
    }

    private void MostrarMensajeDeError(string message)
    {
        CambiarContenidoDeLaRespuesta(message);
    }

    public void RespuestaCorrecta(string resultado)
    {
        CambiarContenidoDeLaRespuesta("Correcto!");
        foreach(GameObject o in cosasPorActivar)
        {
            o.SetActive(true);
        }
        foreach (GameObject o in cosasPorDesactivar)
        {
            o.SetActive(false);
        }
    }

    public void RespuestaIncorrecta(string resultado)
    {
        CambiarContenidoDeLaRespuesta("Incorrecto");
    }

    private void CambiarContenidoDeLaRespuesta(string respuesta)
    {
        dondeVanLasRespuestas.text = respuesta;
    }
}
