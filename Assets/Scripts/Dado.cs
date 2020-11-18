using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dado : MonoBehaviour, IDadoMono
{
    private LogicaDeDado logica;
    [SerializeField] private Button boton;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private List<GameObject> cosasPorActivar;
    void Start()
    {
        logica = new LogicaDeDado(this);
        boton.onClick.AddListener(delegate { logica.CalcularElNumeroDelDado(); });
        texto.text = "Lanza el dado";
    }
    
    public void AsignarResultadoDelDadoEnPantalla(int resultado)
    {
        texto.text = $"Dado {resultado}";
        boton.gameObject.SetActive(false);
        foreach(GameObject ob in cosasPorActivar)
        {
            ob.SetActive(true);
        }
    }
}
