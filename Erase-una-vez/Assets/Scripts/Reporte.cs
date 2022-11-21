using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class Reporte : MonoBehaviour
{
    //Version mejorada para el reporte que sale al finalizar un nivel

    //NOTA: Terminar la parte de recibir informacion de otras escenas.
    //NOTA: Implementar como saber de que ventana viene el jugador para saber que
    //      tipo de reporte mostrar.

    //VARIABLES

    //Nombres de variables

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

    //Cantidad de aciertos por caracter, viene de base de datos
    public int caracteresCorrectos;
    //Precision total, calculado en script
    public float precision;
    //Total de caracteres, viene de base de datos
    //Se usa para poder calcular la precision
    public int totalCaracteres;

    //Para tiempo

    //Variable de tiempo en segundos, recibe el tiempo en flotante, viene de base
    //de datos
    public float tiempo;
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

    //Variables para los outputs en pantalla
    public Text precisionOutput;
    public Text tiempoOutput;
    public Text palXMinOutput;

    // Start is called before the first frame update
    void Start()
    {
        //Version de debug para mostrar que inicio correctamente y recorre
        //las funciones satisfactoriamente
        Debug.Log("Comienza carga de datos");
        cargarDatos();
        Debug.Log("Los datos se cargaron");
        Debug.Log("Hola, comenzamos");
        Precision();
        Debug.Log("Precision() termino correctamente");
        TiempoTotal();
        Debug.Log("TiempoTotal() termino correctamente");
        PalabraXMinuto();
        Debug.Log("PalabraXMinuto() termino correctamente");

        //Se va a setear en esta funcion
        prePartida = true;

        //Aqui tentaticamente iria la funcion para saber que botones mostrar
        //If para seleccionar que grupo de botones van a aparecer en la escena
        if (prePartida == true)
        {
            //Aparecen los botones para el reporte pre-partida
            Debug.Log("Mostrar prepartida");
            objPre.gameObject.SetActive(true);
            objPost.gameObject.SetActive(false);
        }
        else
        {
            //Aparecen los botonoes para el reporte post-partida
            Debug.Log("Mostrar postpartida");
            objPre.gameObject.SetActive(false);
            objPost.gameObject.SetActive(true);
        }
        Debug.Log("Estado de prepartida: " + prePartida);
    }

    // Update is called once per frame
    void Update()
    {
        //No se usa, aun
    }

    //Se cargan todos los datos de las PlayerPrefs
    public void cargarDatos()
    {
        int numNivel = 1;
        //Version de prueba
        //VERSION DE PRUEBA GUARDA Y LEE AQUI MISMO
        PlayerPrefs.SetInt("caracteresCorrectos" + numNivel, 600);
        Debug.Log("se subio caracteresCorrectos");
        PlayerPrefs.SetInt("totalCaracteres" + numNivel, 600);
        Debug.Log("se subio totalCaracteres");
        PlayerPrefs.SetFloat("tiempo" + numNivel, 120.0000f);
        Debug.Log("se subio tiempo");
        PlayerPrefs.SetInt("totalPalabras" + numNivel, 12000);
        Debug.Log("se subio totalPalabras");
        Debug.Log("Los datos se cargaron en playerpref");

        //Lectura de datos desde playerprefs
        caracteresCorrectos = PlayerPrefs.GetInt("caracteresCorrectos" + numNivel);
        Debug.Log("se descargo caracteresCorrectos");
        totalCaracteres = PlayerPrefs.GetInt("totalCaracteres" + numNivel);
        Debug.Log("se descargo totalCaracteres");
        tiempo = PlayerPrefs.GetFloat("tiempo" + numNivel);
        Debug.Log("se descargo tiempo");
        totalPalabras = PlayerPrefs.GetInt("totalPalabras" + numNivel);
        Debug.Log("se descargo totalPalabras");
    }

    public void Precision()
    {
        //La precision se calcula con una regla de tres
        //El 100% se divide entre el total de caracteres, y es multiplicado por la
        //cantidad de caracteres correctos
        precision = (100.0f / totalCaracteres) * caracteresCorrectos;
        Debug.Log("precision: " + precision);
        //Para hacer que aparezcan menos decimales, primero se convierte en un string
        //y se especifica la longitud de caracteres
        string pres = precision.ToString("G3");
        Debug.Log("prueba: " + pres);
        //Despues se regresa a flotante
        precision = Single.Parse(pres);
        Debug.Log("precision: " + precision);
        //Y el resultado se envia a la variable para el output
        precisionOutput.text = "" + precision + "%";
    }

    public void TiempoTotal()
    {
        //Para sacar el tiempo, vamos a convertir los segundos en el
        //formato de mm:ss
        
        //Creo una variable auxiliar para poder calcular el tiempo
        int aux = (int)tiempo;
        //El ciclo va restando de 60 en 60 (segundos) para sumar un
        //minuto mientras el auxiliar sea mayor o igual a 60, es decir que
        //completa un minuto
        while (aux >= 60) {
            minuto++;
            aux = aux - 60;
            Debug.Log("un minuto mas: " + minuto);
        }
        //El sobrante de aux se pasa a los segundos sueltos
        segundos = aux;
        Debug.Log("minutos: " + minuto);
        Debug.Log("segundos: " + segundos);
        //Para resolver lo del formato, es una condicional que concatena de
        //manera para que salga bonito el formato del reloj
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
        //Constante para agregar los segundos sobrantes en su equivalente a un
        //minuto para el calculo
        float temp = (segundos / 60.0f);
        Debug.Log("segundos en minutos: " + temp);
        //El valor en minutos de los segundos, se suma a los minutos completos
        temp = temp + minuto;
        Debug.Log("dios ya: " + temp);
        //Calculo de las palabras por minuto
        palXMin = totalPalabras / temp;
        Debug.Log("palxmin: " + palXMin);
        //Para hacer que aparezcan menos decimales, primero se convierte en un string
        //y se especifica la longitud de caracteres
        string pres = palXMin.ToString("G2");
        Debug.Log("plm: " + pres);
        //Despues se regresa a flotante
        palXMin = Single.Parse(pres);
        Debug.Log("plm: " + palXMin);
        //Y el resultado se envia a la variable para el output
        palXMinOutput.text = "" + palXMin;
    }
}
