using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Canvas panelPausa;
    [SerializeField] private Canvas panelAjustes;
    //[SerializeField] private Canvas mensajePerdiste;

    void Start()
    {
        panelPausa.enabled = false;
        panelAjustes.enabled = false;
        //mensajePerdiste.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pausar();
        }
    }

    public void Pausar()
    {
        panelPausa.enabled = true;
    }

    public void Despausar()
    {
        panelPausa.enabled = false;
    }

    public void controlarAjustes()
    {
        panelAjustes.enabled = true;
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("Nivel");
    }
    public void QuitarNivel()
    {
        SceneManager.LoadScene("Visualizar_Nivel");

    }

    
}
