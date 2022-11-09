using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Reporte : MonoBehaviour
{
    //Version rudimentaria para el reporte que sale al finalizar un nivel
    //NOTA: Tener en cuenta que que puede que tenga que mandar informacion a algun
    //      lado, acerca de cada nivel para ser recuparada despues.
    //NOTA: Terminar la parte de recibir informacion de otras escenas.
    //NOTA: Implementar otra version para reporte de utlima partida.

    //Variables

    //De algun lugar tendran que venir, aun no esta implementado para que
    //lo saque del nivel

    //Nombres y variables provisionales

    //Para cambio de botonoes
    public bool prePartida = false;

    [SerializeField] private GameObject objPre;
    [SerializeField] private GameObject objPost;

    //Para Precision

    //Cantidad de aciertos por caracter
    public int aciertos = 558;
    //Cantidad de errores por caracter
    public int errores = 126;
    //Precision total
    public float precision;
    //Total de caracteres para poder calcular la precision
    public int totalCaracteres = 684;

    //Para tiempo

    //Variable de tiempo, recibe el tiempo en flotante
    public float tiempoS = 125.2654f;
    //Variable para almacenar la cantidad de minutos completos
    public int minuto = 0;
    //Variable para almacenar la cantidad de segundos sueltos
    public int segundos = 0;

    //Para palabras por minuto

    //Total de palabras, tentativamente sera el lenght del array con las
    //palabras para el nivel
    public int totalPalabras = 150;
    //Variable para almacenar el valor final de palabras por minuto
    public float palXMin;

    //Variables para los outputs en pantalla
    public TextMeshProUGUI precisionOutput;
    public TextMeshProUGUI tiempoOutput;
    public TextMeshProUGUI palXMinOutout;

    // Start is called before the first frame update
    void Start()
    {
        //Version de debug para mostrar que inicio correctamente y recorre
        //las fucniones satisfactoriamente
        Debug.Log("hola");
        Precision();
        Debug.Log("precision");
        TiempoTotal();
        Debug.Log("tTotal");
        PalabraXMinuto();
        Debug.Log("pxm");
        if(prePartida == true)
        {
            objPre.gameObject.SetActive(true);
            objPost.gameObject.SetActive(false);
        }
        else
        {
            objPre.gameObject.SetActive(false);
            objPost.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VersionReporte()
    {
        //Funcion para ver que version del reporte se va a visualizar

    }

    public void Precision()
    {
        //Provisionalmente la precision sale con una regla de tres simple
        precision = (100.0f / totalCaracteres) * aciertos;
        Debug.Log("precision: " + precision);
        precisionOutput.text = "" + precision;
    }

    public void TiempoTotal()
    {
        //Para sacar el tiempo, vamos a convertir los segundos en el
        //formato de mm:ss
        
        //Creo una variable auxiliar para poder calcular el tiempo
        int aux = (int)tiempoS;
        //El ciclo va restando de 60 en 60 (segundos) para sumar un
        //minuto mientras el auxiliar sea mayor o igual a 60, es decir que
        //completa un minuto
        while (aux >= 60) {
            minuto++;
            aux = aux - 60;
        }
        //El sobrante de aux se pasa a los segundos sueltos
        segundos = aux;
        Debug.Log("minutos: " + minuto);
        Debug.Log("segundos: " + segundos);
        //No se me ocurrio como resolver lo del formato, es una condicional que
        //concatena de manera arcaica para que salga bonito el formato del reloj
        if (segundos >= 10)
        {
            tiempoOutput.text = "" + minuto + ":" + segundos;
        }
        else
        {
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
        palXMinOutout.text = "" + palXMin;
    }
}
