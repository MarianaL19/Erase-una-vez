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
    [SerializeField] private GameObject panelVictoria;
    [SerializeField] private Escritura escritura;

    //Variable para identificar nivel
    public int numNivel;

    public bool esAudio;

    //Para Precision
    //Cantidad de aciertos por caracter, viene de script de escritura
    int aciertos; 
    //Precision total, calculado en script
    public float precision;
    //Total de caracteres, viene de base de datos
    public int totalCaracteres;
    
    //Para Tiempo
    int tiempo; 

    //Para Estrellas
    //Estrella de Precision
    public int estrellaPrecision;
    //Estrella de Tiempo
    public int estrellaTiempo;
    //Estrella de Nivel terminado
    public int estrellaTerminado;
    //Cantidad de estrellas totales en posesion del usuario
    public int estrellasTotales;
    

    public void Start()
    {

    }
    public void NivelFinalizado()
    {
        //Recibir de que nivel viene
        numNivel = PlayerPrefs.GetInt("nivelActual");

        //Verificar audio o normal
        esAudio = PlayerPrefs.GetInt("varianteAudio" + numNivel) == 1 ? true : false;

        //Recuperamos las estrellas del nivel
        estrellaPrecision = PlayerPrefs.GetInt("estrellaPrecision" + numNivel); // Recupero si la estrella de precision ya fue desbloqueada    
        estrellaTiempo = PlayerPrefs.GetInt("estrellaTiempo" + numNivel); // Recupero si la estrella de tiempo ya fue desbloqueada
        estrellaTerminado = PlayerPrefs.GetInt("estrellaTerminado" + numNivel); // Recupero si la estrella de terminar ya fue desbloqueada

        //Asignamos total de caracteres y aciertos para calcular precision
        int aciertos = escritura.getAciertos();
        Debug.Log("Aciertos totales: " + aciertos); // Muestro
        totalCaracteres = PlayerPrefs.GetInt("totalCaracteres" + numNivel);
        Debug.Log("Caracteres Totales: " + totalCaracteres); // Muestro

        //Asignamos tiempo
        int tiempo = escritura.getTiempo();

        //Logs para ver si las estrellas ya estaban desde antes
        Debug.Log("Estrella Precision Antes: " + estrellaPrecision);
        Debug.Log("Estrella Tiempo Antes: " + estrellaTiempo);
        Debug.Log("Estrella Terminado Antes: " + estrellaTerminado);

        estrellasTotales = PlayerPrefs.GetInt("noEstrellas"); // Recupero la cantidad total de estrellas
        Debug.Log("Estrellas Totales Antes:" + estrellasTotales); // Muestro la cantidad total de estrellas antes del nivel
        
        //Guardamos la estrella por completar el nivel
        PlayerPrefs.SetInt("estrellaTerminado" + numNivel, 1);

        int estrellasMostrar= 1;

        //PlayerPrefs.GetInt("varianteAudio") == 1;
        if(esAudio)
        {
            textoAudio.SetActive(true);
            estrellas.SetActive(false);
            estrella1.SetActive(false);
            estrella2.SetActive(false);
            estrella3.SetActive(false);
        }
        else
        {
            textoAudio.SetActive(false);
            estrella2.SetActive(false);
            estrella3.SetActive(false);
            estrellas.SetActive(true);
            estrella1.SetActive(true);

            //Calculamos precisión
            precision = (100.0f / totalCaracteres) * aciertos;
            Debug.Log("Precisión total: " + precision);

            if (tiempo < 300){

                //Validación para no dar la estrella de nuevo
                if(estrellaTiempo == 0){ 
                    estrellasTotales++; 
                }

                estrellasMostrar++;
                PlayerPrefs.SetInt("estrellaTiempo" + numNivel, 1);
                estrellaTiempo = PlayerPrefs.GetInt("estrellaTiempo" + numNivel); // Marco la estrella de tiempo como desbloqueada
            }
                
            if (precision > 80) {

                //Validación para no dar la estrella de nuevo
                if(estrellaPrecision == 0){
                    estrellasTotales++;
                }

                estrellasMostrar++; 
                PlayerPrefs.SetInt("estrellaPrecision" + numNivel, 1);
                estrellaPrecision = PlayerPrefs.GetInt("estrellaPrecision" + numNivel); // Marco la estrella de precision como desbloqueada    
            }

            //Validación para no dar la estrella de nuevo
            if (estrellaTerminado == 0) { 
                estrellasTotales++; 
            }
                
            if(estrellasMostrar>1){
                estrella2.SetActive(true);
            }
                
            if(estrellasMostrar>2){
                estrella3.SetActive(true);
            }

            //Logs para ver si las estrellas son otorgadas
            Debug.Log("Estrella Precision Después: " + estrellaPrecision);
            Debug.Log("Estrella Tiempo Después: " + estrellaTiempo);
            Debug.Log("Estrella Terminado Después: " + estrellaTerminado);
    
            PlayerPrefs.SetInt("noEstrellas", estrellasTotales); //Enviamos la nueva cantidad de estrellas a las PlayerPrefs

            estrellasTotales = PlayerPrefs.GetInt("noEstrellas"); // Guardo para mostrar
            Debug.Log("Estrellas Totales Después:" + estrellasTotales); // Muestro
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu_Niveles");
    }
    public void Reporte()
    {
        panelVictoria.SetActive(false);
        panelReporte.SetActive(true);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("Nivel");
    }

}
