using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VisualizarNivel : MonoBehaviour
{
    //Objetos que se utilizan para mostrar el conjunto de nivel: bloqueado o desbloqueado
    [SerializeField] private GameObject objBloqueado;
    [SerializeField] private GameObject objDesbloqueado;

    //Objeto Pop-up
    [SerializeField] private Canvas popUpCompra;

    //Objetos del nivel desbloqueado
    [SerializeField] private GameObject objEstrellas;
    [SerializeField] private GameObject[] estrellas;
    [SerializeField] private GameObject botones;
    [SerializeField] private GameObject objBloquearAudio;
    [SerializeField] private GameObject objMedalla;

    //Objetos comunes de la visualización
    [SerializeField] private Text tituloNivel;
    [SerializeField] private Text tituloEstrellas;
    [SerializeField] private Button btnTexto;
    [SerializeField] private Button btnAudio;

    //Variables para asignar los valores del Archivo Lógico del nivel
    public int noNivel;
    public int noEstrellas;
    public bool bloqueado;
    public bool bloqueadoAudio;
    public bool varianteAudio;
    public bool audioCompletado;
    public int estrellasTotales;

    // Start is called before the first frame update
    void Start()
    {
        // cargarDatos();
        inicializarNivel();
        popUpCompra.enabled = false;
    }

    void Update(){
        inicializarNivel();
    }

    public void cargarDatos()
    {
        //Se cargan todos los datos de las PlayerPrefs
    }

    public void guardarDatos()
    {
        //Se guardan todos los datos en playerPrefs cuando se destruya la escena
    }

    public void inicializarNivel()
    {
        tituloEstrellas.text = estrellasTotales.ToString();
        objEstrellas.gameObject.SetActive(false);
        objMedalla.gameObject.SetActive(false);

        //Si el nivel seleccionado está bloqueado
        if(bloqueado == true){
            objDesbloqueado.gameObject.SetActive(false);
            btnTexto.interactable = false;
            btnAudio.interactable = false;
        }
        //Si está desbloqueado y no está en el modo de la variante audio
        else if(bloqueado == false && varianteAudio == false){
            objBloqueado.gameObject.SetActive(false);
            objDesbloqueado.gameObject.SetActive(true);
            
            objBloquearAudio.gameObject.SetActive(false);
            botones.gameObject.SetActive(true);
            btnTexto.interactable = true;
            btnAudio.interactable = true;
        }
        //Está desbloqueado y está en la variante audio
        else if(bloqueado == false && varianteAudio == true){
            if(bloqueadoAudio == true)
            {
                objBloquearAudio.gameObject.SetActive(true);
                botones.gameObject.SetActive(false);
            }else{
                botones.gameObject.SetActive(true);
                if(audioCompletado) objMedalla.gameObject.SetActive(true);
            }
        }

        inicializarInfo();
    }

    public void inicializarInfo()
    {
        tituloNivel.text = "Lvl" + noNivel.ToString();

        //Si no es una variante de audio, se muestran las estrellas
        if(varianteAudio == false){
            // botones.gameObject.SetActive(true);
            objEstrellas.gameObject.SetActive(true);

            if (noEstrellas == 0){
                estrellas[0].SetActive(false);
                estrellas[1].SetActive(false);
                estrellas[2].SetActive(false);
            }else if(noEstrellas == 1){
                estrellas[1].SetActive(false);
                estrellas[2].SetActive(false);
            }else if(noEstrellas == 2){
                estrellas[2].SetActive(false);
            }
        }
    }

    public void cambiarAAudio()
    {
        varianteAudio = true;
    }

    public void cambiarATexto()
    {
        varianteAudio = false;
        // objMedalla.gameObject.SetActive(true);
    }

    public void comprarNivelTexto()
    {
        if(estrellasTotales >= 2){
            print(estrellasTotales);
            estrellasTotales = estrellasTotales - 2;
            bloqueado = false;
        }else{
            popUpCompra.enabled = true;
        }
    }

    public void comprarNivelAudio()
    {
        if(estrellasTotales >= 2){
            print(estrellasTotales);
            estrellasTotales = estrellasTotales - 2;
            bloqueadoAudio = false;
            objBloquearAudio.gameObject.SetActive(false);
        }else{
            popUpCompra.enabled = true;
        }
    }

    public void cerrarPopUpCompra()
    {
        popUpCompra.enabled = false;
    }

}
