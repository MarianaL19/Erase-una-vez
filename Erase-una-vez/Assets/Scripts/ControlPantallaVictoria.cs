using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPantallaVictoria : MonoBehaviour
{
    [SerializeField] private GameObject textoAudio;
    [SerializeField] private GameObject estrellas;
    [SerializeField] private GameObject estrella1;
    [SerializeField] private GameObject estrella2;
    [SerializeField] private GameObject estrella3;
    [SerializeField] private GameObject panelReporte;
    [SerializeField] private Escritura escritura;

    public void Start()
    {
        textoAudio.SetActive(false);
        estrellas.SetActive(false);
        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);
    }
    public void NivelFinalizado()
    {
        bool audio = false;
        int estrellasMostrar= 1; 
        //PlayerPrefs.GetInt("varianteAudio") == 1;
        if(audio)
        {
            textoAudio.SetActive(true);
        }
        else
        {
            estrellas.SetActive(true);
            estrella1.SetActive(true);
            int tiempo = escritura.getTiempo();
            int aciertos = escritura.getAciertos();
            if (tiempo < 50)
                estrellasMostrar++;
            if (aciertos > 50)
                estrellasMostrar++;
            if(estrellasMostrar>1)
                estrella2.SetActive(true);
            if(estrellasMostrar>2)
                estrella3.SetActive(true);
        }

    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu_Niveles");
    }
    public void Reporte()
    {
        panelReporte.SetActive(true);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("Nivel");
    }
}
