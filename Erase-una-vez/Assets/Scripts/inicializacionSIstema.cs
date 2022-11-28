using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicializacionSIstema : MonoBehaviour
{
    public int[] arregloTotalCaracteres = new int[5];
    public int[] arregloTotalPalabras = new int[5];
    public int[] arregloNoErrores = new int[5];
    public int[] arregloTiempoCompletado = new int[5];
    public int[] arregloTrabalenguas = new int[5];


    void Awake()
    {
        //comportamiento de inicialización de los archivos lógicos
        if (!PlayerPrefs.HasKey("primeraEjecucion"))
        {
            Debug.Log("Entro al if");

            //El for comienza en el 1 para el nivel 1 hasta el 5
            for(int numNivel = 1; numNivel < 6; numNivel++)
            {
                //Valores fijos por nivel
                PlayerPrefs.SetInt("noNivel" + numNivel, numNivel);
                PlayerPrefs.SetInt("totalCaracteres" + numNivel, arregloTotalCaracteres[numNivel-1]);
                PlayerPrefs.SetInt("totalPalabras" + numNivel, arregloTotalPalabras[numNivel-1] );
                PlayerPrefs.SetInt("noErrores" + numNivel, arregloNoErrores[numNivel-1] );
                PlayerPrefs.SetInt("tiempoCompletado" + numNivel, arregloTiempoCompletado[numNivel-1] );
                PlayerPrefs.SetInt("trabalenguas" + numNivel, arregloTrabalenguas[numNivel-1]);

                //Variables del nivel 
                // Para los valores booleanos: 1->bloqueado y 0->desbloqueado
                PlayerPrefs.SetInt("caracteresCorrectos" + numNivel, 0);
                PlayerPrefs.SetInt("tiempo" + numNivel, 0);
                PlayerPrefs.SetInt("caracteresCorrectosAudio" + numNivel, 0);
                PlayerPrefs.SetInt("tiempoAudio" + numNivel, 0);
                PlayerPrefs.SetInt("estrellas" + numNivel, 0);
                //Si está en la variante de audio o no
                PlayerPrefs.SetInt("varianteAudio" + numNivel, 0);
                PlayerPrefs.SetInt("bloqueado" + numNivel, (numNivel==1 | numNivel==2) ? 0 : 1);
                PlayerPrefs.SetInt("bloqueadoAudio" + numNivel, 1);
                PlayerPrefs.SetInt("estrellaPrecision" + numNivel, 0);
                PlayerPrefs.SetInt("estrellaTiempo" + numNivel, 0);
                PlayerPrefs.SetInt("estrellaTerminado" + numNivel, 0);
                PlayerPrefs.SetInt("audioCompletado" + numNivel, 0);

                //Creamos esta key para instanciar que ya se ejecutó por primera vez                
            }

            //Variables de ajustes
            PlayerPrefs.SetFloat("volumen", 0.5f);
            PlayerPrefs.SetInt("sizeTexto", 40);
            PlayerPrefs.SetInt("color", 1);

            //Variables de jugador
            PlayerPrefs.SetInt("noEstrellas", 0);
            PlayerPrefs.SetInt("nivelActual", 0);
            PlayerPrefs.SetInt("primeraEjecucion", 1);
            
            //Guardamos las preferencias
            PlayerPrefs.Save();

        }else{
            Debug.Log("Entro al else");
            for(int numNivel = 1; numNivel < 6; numNivel++)
            {
                // Debug.Log(PlayerPrefs.GetInt("noNivel" + numNivel));
                // Debug.Log("Bloqueado: ");
                // Debug.Log(PlayerPrefs.GetInt("bloqueado" + numNivel));
            }
        }
    }

}
