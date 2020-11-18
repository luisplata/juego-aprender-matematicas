using UnityEngine;

public class ServiceLocatorInstaller : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        var calculos = new CalculosGenerales();
        ServiceLocator.Instance.RegisterService<ICalculosGenerales>(calculos);
        var almacenamientoDeDatos = new AdapterSave();
        ServiceLocator.Instance.RegisterService<IGuardarData>(almacenamientoDeDatos);
        ServiceLocator.Instance.RegisterService<IObtenerData>(almacenamientoDeDatos);
        ServiceLocator.Instance.RegisterService<IManejoDeDatosDelJuego>(almacenamientoDeDatos);
    }
}