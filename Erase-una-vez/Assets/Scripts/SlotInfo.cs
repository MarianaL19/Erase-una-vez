using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlotInfo : MonoBehaviour
{
    [SerializeField] private GameObject bloqueo;
    [SerializeField] private Button interactividad;
    [SerializeField] private GameObject objEstrellas;
    [SerializeField] private GameObject estrella1;
    [SerializeField] private GameObject estrella2;
    [SerializeField] private GameObject estrella3;
    [SerializeField] private GameObject medalla;

    public int noNivel;
    private int estrellas;
    private bool bloqueado;
    private bool audioCompletado;
    // private Text tituloNivel;

    // Start is called before the first frame update
    void Start()
    {
        cargarDatos();
        inicializarSlot();
    }

    public void inicializarSlot()
    {
        //Se inicializa como si el nivel SÍ ESTUVIERA bloqueado
        objEstrellas.gameObject.SetActive(false);
        medalla.gameObject.SetActive(false);

        //Si no está bloqueado, se cambian algunos valores.
        if(bloqueado == false){
            // tituloNivel.text = noNivel.ToString();
            bloqueo.gameObject.SetActive(false);
            objEstrellas.gameObject.SetActive(true);

            //Evalúa qué estrellas estarán encendidas
            if (estrellas == 0){
                estrella1.gameObject.SetActive(false);
                estrella2.gameObject.SetActive(false);
                estrella3.gameObject.SetActive(false);
            }else if(estrellas == 1){
                estrella2.gameObject.SetActive(false);
                estrella3.gameObject.SetActive(false);
            }else if(estrellas == 2){
                estrella3.gameObject.SetActive(false);
            }

            //Si el audio NO está completado, oculte la medalla.
            if(audioCompletado == true){
                medalla.gameObject.SetActive(true);
            }
        }
    }
    public void cargarDatos()
    {
        //Usuario
        estrellas = PlayerPrefs.GetInt("estrellas" + noNivel);

        //Nivel
        estrellas = PlayerPrefs.GetInt("estrellas" + noNivel);
        bloqueado = PlayerPrefs.GetInt("bloqueado" + noNivel)==1?true:false;
        audioCompletado = PlayerPrefs.GetInt("audioCompletado" + noNivel)==1?true:false;

    }

    public void guardarDatos()
    {
        PlayerPrefs.SetInt("nivelActual", noNivel);
        PlayerPrefs.Save();
    }

    public void visualizarNivel()
    {
        guardarDatos();
        SceneManager.LoadScene("Visualizar_Nivel");
    }
    
}
