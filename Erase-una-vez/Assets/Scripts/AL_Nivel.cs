using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AL_Nivel : MonoBehaviour
{
    //Provisonalmente dejo todo public, por si necesitamos leer los valores en otro script, que ahorita la neta no sé.
    public int noNivel;
    public int totalCaracteres;
    public int estrellas;
    public int caracteresCorrectos;
    public float tiempo;
    public float porcentaje;
    private float aux;

    [SerializeField] Text text;

    //Al inicializar el nivel, si dentro de PlayerPrefs existe un valor de "Estrellas" lo asigna a la variable local Estrellas.
    //Hace lo mismo con el resto de variables (tiempo, caracteresCorrectos)
    private void Start()
    {

        if (PlayerPrefs.HasKey("estrellas"+"noNivel"))
        {
            estrellas = PlayerPrefs.GetInt("estrellas"+"noNivel");
            caracteresCorrectos = PlayerPrefs.GetInt("caracteresCorrectos"+"noNivel");
            tiempo = PlayerPrefs.GetInt("tiempo"+"noNivel");

            // uso un auxiliar pa' convertir a flotantes los caracteres correctos y que se pueda hacer la división
            aux = caracteresCorrectos;
            porcentaje = aux / totalCaracteres;

            text.text = "Estrellas: " + estrellas.ToString() + " Tiempo: " + tiempo.ToString() +
                        " Correctos: " + caracteresCorrectos.ToString() + " Porcentaje: %" + porcentaje.ToString();

        }else{
            text.text = "No se ha jugado el nivel";
        }

        // Updated();
    }

    //Función de prueba para settear un valor a los PlayerPrefs
    public void ClickMeBtn()
    {
        PlayerPrefs.SetInt("estrellas"+"noNivel", noNivel);
        PlayerPrefs.SetInt("caracteresCorrectos"+"noNivel", noNivel*3);
        PlayerPrefs.SetInt("tiempo"+"noNivel", noNivel*2);
        PlayerPrefs.Save();
    }

}
