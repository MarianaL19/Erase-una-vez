using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class ReportePostPartida : MonoBehaviour
{
    //Version mejorada para el reporte que sale al finalizar un nivel
    //Script para mostrar post-partida

    //VARIABLES

    //Nombres de variables

    //Objeto escritura para acceder a sus metodos
    public Escritura objEscritura;

    //Para cambio de botonoes

    //Variable para saber que reporte se esta mostrando y saber que botones va a mostrar
    public bool prePartida;

    //Objetos contenedores de los botones, para poder hacer el script que hace que aparezcan los botones que deben de aparecer dependiendo del tipo de reporte
    [SerializeField] private GameObject objPre;
    [SerializeField] private GameObject objPost;

    //Variable para identificar nivel
    public int numNivel;
    public bool audio;

    //Para Precision

    //Cantidad de aciertos por caracter, viene de escena de juego
    public int caracteresCorrectos;
    //Cantidad de aciertos por caracter en audio, viene de escena de juego
    public int caracteresCorrectosAudio;
    //Precision total, calculado en script
    public float precision;
    //Total de caracteres, viene de base de datos
    public int totalCaracteres;

    //Para tiempo

    //Variable de tiempo en segundos, viene de escena de juego
    public int tiempo;
    //Variable de tiempo en segundos del audio, viene de escena de juego
    public int tiempoAudio;
    //Variable para almacenar la cantidad de minutos completos, se calcula en script
    public int minuto = 0;
    //Variable para almacenar la cantidad de segundos sueltos, se calcula en script
    public int segundos = 0;

    //Para palabras por minuto

    //Total de palabras, viene de base de datos
    public int totalPalabras;
    //Variable para almacenar el valor final de palabras por minuto, se calcula en script
    public float palXMin;

    //Variables para sobreescrituras
    //Para hacer comparacion de precision
    public float preciTemp;
    //Variables para comparacion de tiempo, normal y de audio
    public int tiempoTemp;
    public int tiempoAudioTemp;
    //Variables para comparacion de caracteres, normal y de audio
    public int caracteresCorrectosTemp;
    public int caracteresCorrectosAudioTemp;

    //Variables para los outputs en pantalla
    public Text precisionOutput;
    public Text tiempoOutput;
    public Text palXMinOutput;

    // Start is called before the first frame update
    void Start()
    {
        //Carga informacion a la escena
        //Al ser post partida, la informacion no se recupera al instante
        //que incia la escena
        //cargarDatos();

        //Funcion para la precision
        //Precision();

        //Funcion de tiempo
        //TiempoTotal();

        //Funcion de palabras por minuto
        //PalabraXMinuto();

        //En script post partida, este esta setteado en false
        prePartida = false;

        //Funcion para decidir que botones mostrar
        //If para seleccionar que grupo de botones van a aparecer en la escena
        if (prePartida == true)
        {
            //Aparecen los botones para el reporte pre-partida
            objPre.gameObject.SetActive(true);
            objPost.gameObject.SetActive(false);
        }
        else
        {
            //Aparecen los botonoes para el reporte post-partida
            objPre.gameObject.SetActive(false);
            objPost.gameObject.SetActive(true);
        }
    }

    public void cargarDatos()
    {
        //Version de prueba
        //Carga de info provisional
        
        //Supuesto nivel
        //int nivelPrueba = 2;
        //PlayerPrefs.SetInt("nivelActual", nivelPrueba);
        //Es audio o no
        //bool audioPrueba = true;
        //PlayerPrefs.SetInt("varianteAudio" + nivelPrueba, audioPrueba ? 1 : 0);


        //prueba 1
        //normal
        //PlayerPrefs.SetInt("caracteresCorrectos" + nivelPrueba, 642);
        //PlayerPrefs.SetInt("totalCaracteres" + nivelPrueba, 951);
        //PlayerPrefs.SetInt("tiempo" + nivelPrueba, 157);
        //PlayerPrefs.SetInt("totalPalabras" + nivelPrueba, 152);
        //audio
        //PlayerPrefs.SetInt("caracteresCorrectosAudio" + nivelPrueba, 752);
        //PlayerPrefs.SetInt("totalCaracteres" + nivelPrueba, 800);
        //PlayerPrefs.SetInt("tiempoAudio" + nivelPrueba, 184);
        //PlayerPrefs.SetInt("totalPalabras" + nivelPrueba, 147);

        //Prueba 2
        //normal
        //PlayerPrefs.SetInt("caracteresCorrectos" + nivelPrueba, 600);
        //PlayerPrefs.SetInt("totalCaracteres" + nivelPrueba, 800);
        //PlayerPrefs.SetInt("tiempo" + nivelPrueba, 120);
        //PlayerPrefs.SetInt("totalPalabras" + nivelPrueba, 110);
        //audio
        //PlayerPrefs.SetInt("caracteresCorrectosAudio" + nivelPrueba, 452);
        //PlayerPrefs.SetInt("totalCaracteres" + nivelPrueba, 600);
        //PlayerPrefs.SetInt("tiempoAudio" + nivelPrueba, 160);
        //PlayerPrefs.SetInt("totalPalabras" + nivelPrueba, 110);


        //Carga informacion
        //Recibir de que nivel viene
        numNivel = PlayerPrefs.GetInt("nivelActual");

        //Verificar audio o normal
        audio = PlayerPrefs.GetInt("varianteAudio" + numNivel) == 1 ? true : false;

        //Cargar información pertinente
        if (audio == true)
        {
            //Descarga informacion de variantes de audio
            caracteresCorrectosAudio = PlayerPrefs.GetInt("caracteresCorrectosAudio" + numNivel);
            totalCaracteres = PlayerPrefs.GetInt("totalCaracteres" + numNivel);
            tiempoAudio = PlayerPrefs.GetInt("tiempoAudio" + numNivel);
            totalPalabras = PlayerPrefs.GetInt("totalPalabras" + numNivel);
        }
        else
        {
            //Descarga informacion de variantes normales
            caracteresCorrectos = PlayerPrefs.GetInt("caracteresCorrectos" + numNivel);
            totalCaracteres = PlayerPrefs.GetInt("totalCaracteres" + numNivel);
            tiempo = PlayerPrefs.GetInt("tiempo" + numNivel);
            totalPalabras = PlayerPrefs.GetInt("totalPalabras" + numNivel);
        }
    }

    public void Precision()
    {
        //Este metodo va a recuperar informacion de base de datos y del nivel jugado para comparar cual es mejor y guardar el mejor
        //Recuperacion de datos para calcular precision

        //La precision se calcula con una regla de tres
        //El 100% se divide entre el total de caracteres, y es multiplicado por la cantidad de caracteres correctos

        //Carga informacion
        //Recibir de que nivel viene
        numNivel = PlayerPrefs.GetInt("nivelActual");

        //Verificar audio o normal
        audio = PlayerPrefs.GetInt("varianteAudio" + numNivel) == 1 ? true : false;

        //Verificar procedencia, audio o normal
        if (audio == true)
        {
            //Settea en base al valor de audio

            //Recuperar desde el juego
            caracteresCorrectosAudioTemp = objEscritura.getAciertos();
            Debug.Log("caracteresCorrectos desde nivel: " + caracteresCorrectosAudioTemp);
            //Recupera de base de datos
            caracteresCorrectosAudio = PlayerPrefs.GetInt("caracteresCorrectosAudio" + numNivel);
            totalCaracteres = PlayerPrefs.GetInt("totalCaracteres" + numNivel);

            //Calcular precision temporal, salida del juego
            preciTemp = (100.0f / totalCaracteres) * caracteresCorrectosAudioTemp;
            //Calcula precision de base de datos
            precision = (100.0f / totalCaracteres) * caracteresCorrectosAudio;
        }
        else
        {
            //Settea en base al valor normal

            //Recuperacion de informacion desde el juego
            caracteresCorrectosTemp = objEscritura.getAciertos();
            Debug.Log("caracteresCorrectos desde nivel: " + caracteresCorrectosTemp);
            //Recuepera de base de datos
            caracteresCorrectos = PlayerPrefs.GetInt("caracteresCorrectos" + numNivel);
            totalCaracteres = PlayerPrefs.GetInt("totalCaracteres" + numNivel);
            Debug.Log("Total de caracteres de playerprefs: " + totalCaracteres);

            //Calcular precision temporal, salida del juego
            preciTemp = (100.0f / totalCaracteres) * caracteresCorrectosTemp;
            //Calcula precision de base de datos
            precision = (100.0f / totalCaracteres) * caracteresCorrectos;
        }

        //Para hacer que aparezcan menos decimales, primero se convierte en un string y se especifica la longitud de caracteres
        string pres = preciTemp.ToString("G3");
        //Despues se regresa a flotante
        preciTemp = Single.Parse(pres);
        //Y el resultado se envia a la variable para el output
        precisionOutput.text = "" + preciTemp + "%";
        //Muestra la temporal en el reporte, mas adelante se revisa si esa temporal se guarda como la mejor o no
    }

    public void TiempoTotal()
    {
        //Para sacar el tiempo, vamos a convertir los segundos en el formato de mm:ss

        //Carga informacion
        //Recibir de que nivel viene
        numNivel = PlayerPrefs.GetInt("nivelActual");

        //Verificar audio o normal
        audio = PlayerPrefs.GetInt("varianteAudio" + numNivel) == 1 ? true : false;

        //Creo una variable auxiliar para poder calcular el tiempo
        int aux;

        //Verificar procedencia, audio o normal
        if (audio == true)
        {
            //Settea en base valores de audio

            //Recuepera desde el juego
            tiempoAudioTemp = objEscritura.getTiempo();
            Debug.Log("Tiempo del nivel: " + tiempoAudioTemp);
            //Recuepera desde la BD
            tiempoAudio = PlayerPrefs.GetInt("tiempoAudio" + numNivel);

            //Asigna tiempo temporal
            aux = tiempoAudioTemp;
            //El tiempo de BD no se asigna al auxiliar porque no se va a mostrar en el reporte, solo se usara para el calculo del mejor resultado
        }
        else
        {
            //Settea en base valores normal

            //Recupera desde el juego
            tiempoTemp = objEscritura.getTiempo();
            Debug.Log("Tiempo del nivel: " + tiempoTemp);
            //Recupera desde la BD
            tiempo = PlayerPrefs.GetInt("tiempo" + numNivel);

            //Asigna tiempo temporal a auxiliar
            aux = tiempoTemp;
            //El tiempo de BD no se asigna al auxiliar porque no se va a mostrar en el reporte, solo se usara para el calculo del mejor resultado
        }
        
        //El ciclo va restando de 60 en 60 (segundos) para sumar un minuto mientras el auxiliar sea mayor o igual a 60, es decir que completa un minuto
        while (aux >= 60)
        {
            minuto++;
            aux = aux - 60;
        }
        //El sobrante de aux se pasa a los segundos sueltos
        segundos = aux;
        //Para resolver lo del formato, es una condicional que concatena de manera para que salga bonito el formato del reloj
        if (segundos >= 10)
        {
            //Por si los segundos salen con dos digitos
            //El resultado se envia a la variable para el output
            tiempoOutput.text = "" + minuto + ":" + segundos;
        }
        else
        {
            //Por si los segundos solo salen con un digito
            //El resultado se envia a la variable para el output
            tiempoOutput.text = "" + minuto + ":0" + segundos;
        }
    }

    public void PalabraXMinuto()
    {
        //Aqui se queda asi, porque recibe el total de palabras de la base de datos, ya se calculo el tiempo en minutos y segundos
        //antes, entonces se opera igual para poder mostrar el resultado en el reporte, sin necesidad de comparar con algo mas, o algo que llegue del nivel

        //Carga informacion
        //Recibir de que nivel viene
        numNivel = PlayerPrefs.GetInt("nivelActual");

        //Verificar audio o normal
        audio = PlayerPrefs.GetInt("varianteAudio" + numNivel) == 1 ? true : false;

        //Cargar información pertinente
        totalPalabras = PlayerPrefs.GetInt("totalPalabras" + numNivel);

        Debug.Log("Palabras totales desde playerprefs: "+totalPalabras);
        Debug.Log("Numero de nivel: " + numNivel);
        
        //Constante para agregar los segundos sobrantes en su equivalente a un minuto para el calculo
        float temp = (segundos / 60.0f);
        //El valor en minutos de los segundos, se suma a los minutos completos
        temp = temp + minuto;
        //Calculo de las palabras por minuto
        palXMin = totalPalabras / temp;
        //Para hacer que aparezcan menos decimales, primero se convierte en un string y se especifica la longitud de caracteres
        string pres = palXMin.ToString("G2");
        //Despues se regresa a flotante
        palXMin = Single.Parse(pres);
        //Y el resultado se envia a la variable para el output
        palXMinOutput.text = "" + palXMin;
    }

    public void SobreEscribir()
    {
        //Carga informacion
        //Recibir de que nivel viene
        numNivel = PlayerPrefs.GetInt("nivelActual");

        //Verificar audio o normal
        audio = PlayerPrefs.GetInt("varianteAudio" + numNivel) == 1 ? true : false;

        //Sobreescribe la mejor partida si el precision/tiempo es mayor que la almacenada en BD
        if ((preciTemp / tiempoTemp) > (precision / tiempo))
        {
            //Sobreescribir si precision/tiempo que vienen del juego son mayores
            if (audio == true)
            {
                //Cambia informacion de variantes de audio
                PlayerPrefs.SetInt("caracteresCorrectosAudio" + numNivel, caracteresCorrectosTemp);
                PlayerPrefs.SetInt("tiempoAudio" + numNivel, tiempoTemp);
            }
            else
            {
                //Cambia informacion de variantes normales
                PlayerPrefs.SetInt("caracteresCorrectos" + numNivel, caracteresCorrectosTemp);
                PlayerPrefs.SetInt("tiempo" + numNivel, tiempoTemp);
            }
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("NO hubo cambio");
        }
    }

    public void GenerarReporte()
    {
        Precision();
        SobreEscribir();
        PalabraXMinuto();
        TiempoTotal();
    }
}