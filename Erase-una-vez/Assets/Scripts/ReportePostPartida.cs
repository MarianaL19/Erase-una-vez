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

    //Variable para saber que reporte se esta mostrando y saber que botones
    //va a mostrar
    public bool prePartida;

    //Objetos contenedores de los botones, para poder hacer el script que
    //hace que aparezcan los botones que deben de aparecer dependiendo
    //del tipo de reporte
    [SerializeField] private GameObject objPre;
    [SerializeField] private GameObject objPost;

    //Para Precision

    //Cantidad de aciertos por caracter, viene de escena de juego
    public int caracteresCorrectos;
    //Precision total, calculado en script
    public float precision;
    //Total de caracteres, viene de base de datos
    //Se usa para poder calcular la precision
    public int totalCaracteres;

    //Para tiempo

    //Variable de tiempo en segundos, recibe el tiempo en flotante, viene de
    //escena de juego
    public int tiempo;
    //Variable para almacenar la cantidad de minutos completos, se calcula en script
    public int minuto = 0;
    //Variable para almacenar la cantidad de segundos sueltos, se calcula en script
    public int segundos = 0;

    //Para palabras por minuto

    //Total de palabras, viene de base de datos
    public int totalPalabras;
    //Variable para almacenar el valor final de palabras por minuto, se calcula
    //en script
    public float palXMin;

    //Variables para sobreescrituras
    public float preciTemp;
    public int tiempoTemp;

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
        int numNivel = PlayerPrefs.GetInt("nivelActual");

        //Verificar audio o normal
        bool audio = PlayerPrefs.GetInt("varianteAudio" + numNivel) == 1 ? true : false;

        //Cargar información pertinente
        if (audio == true)
        {
            //Descarga informacion de variantes de audio
            caracteresCorrectos = PlayerPrefs.GetInt("caracteresCorrectosAudio" + numNivel);
            totalCaracteres = PlayerPrefs.GetInt("totalCaracteres" + numNivel);
            tiempo = PlayerPrefs.GetInt("tiempoAudio" + numNivel);
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


    /// <summary>
    /// acceso a los metodos
    /// hago comparaciones
    /// dejar carga datos en public en nuevo script
    /// en nueveo scirot lo que venia de base de datos y se recyoera de la escena, se recupera con los metodos nuevos
    /// </summary>


    public void Precision()
    {
        //Este metodo va a recuperar informacion de base de datos y del nivel jugado para comparar cual es mejor y guardar el mejor
        //Recuperacion de datos para calcular precision
        
        //Recuperacion de informacion desde el juego
        int caracteresCorrectosTemp = objEscritura.getAciertos();
        Debug.Log("caracteresCorrectos desde nivel: " + caracteresCorrectosTemp);

        //Recuperacion de informacion desde BD
        //Definir numero de nivel y tipo de nivel
        int nivel = PlayerPrefs.GetInt("nivelActual");
        bool tipoAudio = PlayerPrefs.GetInt("varianteAudio" + nivel) == 1 ? true : false;
        //Conseguir informacion del nivel
        if (tipoAudio == true)
        {
            caracteresCorrectos = PlayerPrefs.GetInt("caracteresCorrectosAudio" + nivel);
            totalCaracteres = PlayerPrefs.GetInt("totalCaracteres" + nivel);
        }
        else
        {
            caracteresCorrectos = PlayerPrefs.GetInt("caracteresCorrectos" + nivel);
            totalCaracteres = PlayerPrefs.GetInt("totalCaracteres" + nivel);
        }

        //Calcular presicion de juego, esto es lo que debe de salir en el reporte, se compara mas adelante para ver si se sobreescribe o no
        preciTemp = (100.0f / totalCaracteres) * caracteresCorrectosTemp;

        //Calcular precision de BD
        //La precision se calcula con una regla de tres
        //El 100% se divide entre el total de caracteres, y es multiplicado por la cantidad de caracteres correctos
        precision = (100.0f / totalCaracteres) * caracteresCorrectos;
        //Para hacer que aparezcan menos decimales, primero se convierte en un string y se especifica la longitud de caracteres
        string pres = preciTemp.ToString("G3");
        //Despues se regresa a flotante
        preciTemp = Single.Parse(pres);
        //Y el resultado se envia a la variable para el output
        precisionOutput.text = "" + preciTemp + "%";
    }

    public void TiempoTotal()
    {
        //Recuperamos el tiempo del juego y de BD
        
        //Recuperamos del nivel
        tiempoTemp = objEscritura.getTiempo();
        Debug.Log("Tiempo del nivel: " + tiempoTemp);
        
        //Recuperamos de la base de datos
        //Definir numero de nivel y tipo de nivel
        int nivel = PlayerPrefs.GetInt("nivelActual");
        bool tipoAudio = PlayerPrefs.GetInt("varianteAudio" + nivel) == 1 ? true : false;
        //Conseguir informacion del nivel
        if (tipoAudio == true)
        {
            tiempo = PlayerPrefs.GetInt("tiempoAudio" + nivel);
        }
        else
        {
            tiempo = PlayerPrefs.GetInt("tiempo" + nivel);
        }

        //Usa la temp para que sea la que se muestre en el reporte, aunque no sea la mejor, mas adelante se guarda si el criterio de mejor se cumple

        //Para sacar el tiempo, vamos a convertir los segundos en el
        //formato de mm:ss
        //Creo una variable auxiliar para poder calcular el tiempo
        int aux = tiempoTemp;
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

        //Definir numero de nivel y tipo de nivel
        int nivel = PlayerPrefs.GetInt("nivelActual");
        bool tipoAudio = PlayerPrefs.GetInt("varianteAudio" + nivel) == 1 ? true : false;

        //Cargar información pertinente
        if (tipoAudio == true)
        {
            //Descarga informacion de variantes de audio
            totalPalabras = PlayerPrefs.GetInt("totalPalabras" + nivel);
        }
        else
        {
            //Descarga informacion de variantes normales
            totalPalabras = PlayerPrefs.GetInt("totalPalabras" + nivel);
        }

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
        //Sobreescribe la mejor partida si el precision/tiempo es mayor
        if ((preciTemp / tiempoTemp) > (precision / tiempo))
        {
            //sobreescribe
        }
        else
        {
            //nada
        }
    }
}