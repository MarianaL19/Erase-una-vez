using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VisualizarNivel : MonoBehaviour
{
    [SerializeField] private GameObject objBloqueado;
    [SerializeField] private GameObject objDesbloqueado;
    [SerializeField] private GameObject objEstrellas;
    [SerializeField] private GameObject[] estrellas;
    [SerializeField] private Text tituloNivel;

    public int noNivel;
    public int noEstrellas;
    public bool bloqueado;
    public bool varianteAudio;

    // Start is called before the first frame update
    void Start()
    {
        inicializarNivel();
    }

    void Update(){
        inicializarNivel();
    }

    public void cargarDatos()
    {
        //Se cargan todos los datos de las PlayerPrefs
    }

    public void inicializarNivel()
    {
        objEstrellas.gameObject.SetActive(false);
        //Si el nivel seleccionado está bloqueado
        if(bloqueado == true){
            objDesbloqueado.gameObject.SetActive(false);
        }else{
            objBloqueado.gameObject.SetActive(false);
        }

        inicializarInfo();
    }

    public void inicializarInfo()
    {
        tituloNivel.text = "Lvl" + noNivel.ToString();

        //Si no es una variante de audio, se muestran las estrellas
        if(varianteAudio == false){
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

    public void cambiarAudio()
    {
        varianteAudio = !varianteAudio;
        print(varianteAudio.ToString());
        // SceneManager.LoadScene("Visualizar_Nivel");
        // SceneManager.LoadScene(3);

    }

}
