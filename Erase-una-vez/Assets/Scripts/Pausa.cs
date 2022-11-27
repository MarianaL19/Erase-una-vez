using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Canvas panelPausa;
    [SerializeField] private Canvas panelAjustes;
    [SerializeField] private GameObject panelVictoria;
    [SerializeField] private Canvas panelReiniciar;
    [SerializeField] private Escritura controlJuego;
    [SerializeField] private GameObject panelReporte;
    [SerializeField] private ControlPantallaVictoria pantallaVictoria;
    //[SerializeField] private Canvas mensajePerdiste;

    void Start()
    {
        panelPausa.enabled = false;
        panelAjustes.enabled = false;
        panelVictoria.SetActive(false);
        panelReporte.SetActive(false);
        panelReiniciar.enabled = false;
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
        controlJuego.detenerTiempo();
        panelPausa.enabled = true;
    }

    public void Despausar()
    {
        controlJuego.iniciarTiempo();
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

    public void GanarNivel()
    {
        enabled = false;
        //panelVictoria.SetActive(true);
        panelVictoria.SetActive(true);
        pantallaVictoria.NivelFinalizado();
    }

    public void PerderNivel()
    {
        enabled = false;
        panelReiniciar.enabled = true;
    }
    
}
