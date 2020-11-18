using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ruleta : MonoBehaviour, IRuletaMono
{
    private LogicaDeRuleta logica;
    [SerializeField] private Button botonRuleta;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private List<GameObject> cosasPorActivar;
    // Start is called before the first frame update
    void Start()
    {
        logica = new LogicaDeRuleta(this);
        botonRuleta.onClick.AddListener(delegate { logica.CalcularNumeroDeRuleta(); });
        texto.text = "Lanza la ruleta";
    }
     
    public void MostrarResultadoEnLaPantalla(int resultado)
    {
        texto.text = $"Multiplicar por {resultado}";
        botonRuleta.gameObject.SetActive(false);
        foreach(GameObject objeto in cosasPorActivar)
        {
            objeto.SetActive(true);
        }
    }
    
}
