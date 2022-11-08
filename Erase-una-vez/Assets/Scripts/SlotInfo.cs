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

    public int noNivel;
    public int noEstrellas;
    public bool bloqueado;
    public Text tituloNivel;

    // Start is called before the first frame update
    void Start()
    {
        inicializarSlot();
    }

    public void inicializarSlot()
    {
        //Se inicializa como si el nivel SÍ ESTUVIERA bloqueado
        interactividad.interactable = false;
        objEstrellas.gameObject.SetActive(false);

        //Si no está bloqueado, se cambian algunos valores.
        if(bloqueado == false){
            tituloNivel.text = noNivel.ToString();
            bloqueo.gameObject.SetActive(false);
            objEstrellas.gameObject.SetActive(true);
            interactividad.interactable = true;

            //Evalúa qué estrellas estarán encendidas
            if (noEstrellas == 0){
                estrella1.gameObject.SetActive(false);
                estrella2.gameObject.SetActive(false);
                estrella3.gameObject.SetActive(false);
            }else if(noEstrellas == 1){
                estrella2.gameObject.SetActive(false);
                estrella3.gameObject.SetActive(false);
            }else if(noEstrellas == 2){
                estrella3.gameObject.SetActive(false);
            }
        }
    }


    public void CargarNivel()
    {
        SceneManager.LoadScene(noNivel);
    }
    
}
