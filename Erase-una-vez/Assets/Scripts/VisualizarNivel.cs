using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VisualizarNivel : MonoBehaviour
{
    //Objetos para reporte y Pop-up
    [SerializeField] private Canvas popUpCompra;
    [SerializeField] private Canvas canvasReporte;

    //Objetos que se utilizan para mostrar el conjunto de nivel: bloqueado o desbloqueado
    [SerializeField] private GameObject objBloqueado;
    [SerializeField] private GameObject objDesbloqueado;

    //Objetos del nivel desbloqueado
    [SerializeField] private GameObject objEstrellas;
    [SerializeField] private GameObject[] arregloEstrellas;
    [SerializeField] private GameObject botones;
    [SerializeField] private GameObject objBloquearAudio;
    [SerializeField] private GameObject objMedalla;

    //Objetos comunes de la visualización
    [SerializeField] private Text tituloEstrellas;
    [SerializeField] private GameObject btnTexto;
    [SerializeField] private GameObject btnAudio;

    //Objetos que contienen los botones de Audio y Texto (incluyendo su versión presionada y sin presionar)
    [SerializeField] private GameObject objBtnAudio;
    [SerializeField] private GameObject objBtnTexto;

    //GameObject para bloquear la interacción con los botones cuando esté bloqueado
    [SerializeField] private GameObject bloquearPanelBotones;


    //Variables para asignar los valores del Archivo Lógico del nivel

    private int nivelActual;
    private int estrellas; // Estrellas del nivel
    private bool bloqueado;
    private bool bloqueadoAudio;
    private bool varianteAudio;
    private bool audioCompletado;
    private bool trabalenguas;
    private int noEstrellas; //estrellas del usuario

    //Bandera para establecer el estado del reporte
    private bool reporteAbierto;

    // Start is called before the first frame update
    void Awake()
    {
        cargarDatos();
    }
    
    void Start()
    {
        inicializarNivel();
        btnTexto.gameObject.SetActive(false);
        btnAudio.gameObject.SetActive(false);
        popUpCompra.enabled = false;
        canvasReporte.enabled = false;
        reporteAbierto = false;
    }

    void Update(){
        inicializarNivel();
    }

    void OnDestroy()
    {
        guardarDatos();
        Debug.Log("OnDestroy1");
    }

    //Se cargan todos los datos de las PlayerPrefs
    public void cargarDatos()
    {
        //Usuario
        nivelActual = PlayerPrefs.GetInt("nivelActual");
        noEstrellas = PlayerPrefs.GetInt("noEstrellas");

        //Nivel
        estrellas = PlayerPrefs.GetInt("estrellas" + nivelActual);
        bloqueado = PlayerPrefs.GetInt("bloqueado" + nivelActual)==1?true:false;
        bloqueadoAudio = PlayerPrefs.GetInt("bloqueadoAudio" + nivelActual)==1?true:false;
        varianteAudio = PlayerPrefs.GetInt("varianteAudio" + nivelActual)==1?true:false;
        audioCompletado = PlayerPrefs.GetInt("audioCompletado" + nivelActual)==1?true:false;
        trabalenguas = PlayerPrefs.GetInt("trabalenguas"+ nivelActual)==1?true:false;
    }

    public void guardarDatos()
    {
        //Se guardan todos los datos en playerPrefs cuando se destruya la escena

        //Usuario
        PlayerPrefs.SetInt("noEstrellas", noEstrellas);

        //Nivel
        PlayerPrefs.SetInt("bloqueado"+ nivelActual, bloqueado?1:0);
        PlayerPrefs.SetInt("bloqueadoAudio"+ nivelActual, bloqueadoAudio?1:0);
        PlayerPrefs.SetInt("varianteAudio"+ nivelActual, varianteAudio?1:0);
        PlayerPrefs.Save();
    }

    public void inicializarNivel()
    {
        tituloEstrellas.text = noEstrellas.ToString();
        objEstrellas.gameObject.SetActive(false);
        objMedalla.gameObject.SetActive(false);
        bloquearPanelBotones.gameObject.SetActive(false);
        botones.gameObject.SetActive(false);
        objBloquearAudio.gameObject.SetActive(false);
        objBloqueado.gameObject.SetActive(false);

        //Inicializamos esto en true para preever un bug xd
        objDesbloqueado.gameObject.SetActive(true);
        objBtnTexto.gameObject.SetActive(true);
        objBtnAudio.gameObject.SetActive(true);

        //Si el nivel seleccionado está bloqueado
        if(bloqueado == true){
            objBloqueado.gameObject.SetActive(true);
            botones.gameObject.SetActive(false);
            objDesbloqueado.gameObject.SetActive(false);
            bloquearPanelBotones.gameObject.SetActive(true);
        }
        //Si está desbloqueado y no está en el modo de la variante audio
        else if(bloqueado == false && varianteAudio == false){
            objBloqueado.gameObject.SetActive(false);
            objDesbloqueado.gameObject.SetActive(true);
            
            // objBloquearAudio.gameObject.SetActive(false);
            botones.gameObject.SetActive(true);
            bloquearPanelBotones.gameObject.SetActive(false);

            btnTexto.gameObject.SetActive(true);
            btnAudio.gameObject.SetActive(false);
        }
        //Está desbloqueado y está en la variante audio
        else if(bloqueado == false && varianteAudio == true){
            //Si la variante de audio está bloqueada
            if(bloqueadoAudio == true)
            {
                objBloquearAudio.gameObject.SetActive(true);
                botones.gameObject.SetActive(false);
            }
            //Si la variante audio está desbloqueada
            else{
                botones.gameObject.SetActive(true);
                if(audioCompletado) objMedalla.gameObject.SetActive(true);
            }

            btnTexto.gameObject.SetActive(false);
            btnAudio.gameObject.SetActive(true);
        }

        //Si el reporte está abierto desactiva la vista del nivel
        if(reporteAbierto == true && bloqueado == false)
        {
            objDesbloqueado.gameObject.SetActive(false);
            objBtnTexto.gameObject.SetActive(false);
            objBtnAudio.gameObject.SetActive(false);
        }

        //Si el nivel es un trabalenguas desactiva el botón de audio
        if(trabalenguas == true){
        objBtnAudio.gameObject.SetActive(false);
        }

        //Calcula las estrellas activas en el nivel
        inicializarInfo();
    }

    public void inicializarInfo()
    {
        //Si no es una variante de audio, se muestran las estrellas
        if(varianteAudio == false){
            // botones.gameObject.SetActive(true);
            objEstrellas.gameObject.SetActive(true);

            if (estrellas == 0){
                arregloEstrellas[0].SetActive(false);
                arregloEstrellas[1].SetActive(false);
                arregloEstrellas[2].SetActive(false);
            }else if(estrellas == 1){
                arregloEstrellas[1].SetActive(false);
                arregloEstrellas[2].SetActive(false);
            }else if(estrellas == 2){
                arregloEstrellas[2].SetActive(false);
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
        if(noEstrellas >= 2){
            print(noEstrellas);
            noEstrellas = noEstrellas - 2;
            bloqueado = false;
        }else{
            popUpCompra.enabled = true;
        }
    }

    public void comprarNivelAudio()
    {
        if(noEstrellas >= 3){
            print(noEstrellas);
            noEstrellas = noEstrellas - 3;
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

    public void abrirReporte()
    {
        reporteAbierto = true;
        canvasReporte.enabled = true;
    }

    public void cerrarReporte()
    {
        reporteAbierto = false;
        canvasReporte.enabled = false;
    }
}
