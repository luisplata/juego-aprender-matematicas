using UnityEngine;
public class AdapterSave : IGuardarData, IObtenerData, IManejoDeDatosDelJuego
{
    public void GuardarBool(string clave, bool dato)
    {
        PlayerPrefs.SetInt(clave, dato ? 1 : 0);
    }

    public void GuardarInt(string clave, int dato)
    {
        PlayerPrefs.SetInt(clave, dato);
    }

    public void GuardarNumeroDeLaOperacion(int numero)
    {
        GuardarInt("NumeroOperar", numero);
    }

    public void GuardarString(string clave, string dato)
    {
        PlayerPrefs.SetString(clave, dato);
    }

    public void GuardarTablaDeMultiplicar(int tabla)
    {
        GuardarInt("TablaMultiplicar", tabla);
    }

    public bool ObtenerBool(string clave)
    {
        return PlayerPrefs.GetInt(clave) == 1;
    }

    public int ObtenerInt(string clave)
    {
        return PlayerPrefs.GetInt(clave);
    }

    public string ObtenerString(string clave)
    {
        return PlayerPrefs.GetString(clave);
    }

    public int ObtenerTablaDeMultiplicar()
    {
        return ObtenerInt("TablaMultiplicar");
    }

    public int ObtnerNumeroParaLaOperacion()
    {
        return ObtenerInt("NumeroOperar");
    }
}
    