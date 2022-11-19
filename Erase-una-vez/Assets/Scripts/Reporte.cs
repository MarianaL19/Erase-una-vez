using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class Reporte : MonoBehaviour
{
    //Version mejorada para el reporte que sale al finalizar un nivel
    //NOTA: Tener en cuenta que que puede que tenga que mandar informacion a algun
    //      lado, acerca de cada nivel para ser recuparada despues.
        //RESPUESTA: Aqui solo se recibe informacion y se calculan los derivados
        //           para mostrarse en pantalla, nada se envia a otro lado
    //NOTA: Terminar la parte de recibir informacion de otras escenas.
    //NOTA: Implementar otra version para reporte de utlima partida.
        //RESPUESTA: Ya se implemento con un condicional.
    //NOTA: Implementar como saber de que ventana viene el jugador para saber que
    //      tipo de reporte mostrar.

    //VARIABLES

    //De algun lugar tendran que venir, aun no esta implementado para que
    //lo saque de 'base de datos'

    //Nombres y variables provisionales

    //Para cambio de botonoes

    //Variable para saber que reporte se esta mostrando y saber que botones
    //va a mostrar
    public bool prePartida = false;

    //Objetos contenedores de los botones, para poder hacer el script que
    //hace que aparezcan los botones que deben de aparecer dependiendo
    //del tipo de reporte
    [SerializeField] private GameObject objPre;
    [SerializeField] private GameObject objPost;

    //Para Precision

    //Cantidad de aciertos por caracter, viene de base de datos
    public int caracteresCorrectos = 558;
    //Precision total, calculado en script
    public float precision;
    //Total de caracteres, viene de base de datos
    //Se usa para poder calcular la precision
    public int totalCaracteres = 684;

    //Para tiempo

    //Variable de tiempo en segundos, recibe el tiempo en flotante, viene de base
    //de datos
    public float tiempo = 125.2654f;
    //Variable para almacenar la cantidad de minutos completos, se calcula en script
    public int minuto = 0;
    //Variable para almacenar la cantidad de segundos sueltos, se calcula en script
    public int segundos = 0;

    //Para palabras por minuto

    //Total de palabras, viene de base de datos
    public int totalPalabras = 150;
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
        //las fucniones satisfactoriamente
        Debug.Log("Hola, comenzamos");
        Precision();
        Debug.Log("Precision() termino correctamente");
        TiempoTotal();
        Debug.Log("TiempoTotal() termino correctamente");
        PalabraXMinuto();
        Debug.Log("PalabraXMinuto() termino correctamente");
        
        //Aqui tentaticamente iria la funcion para saber que botones mostrar

        //If para seleccionar que grupo de botones van a aparecer en la escena
        if(prePartida == true)
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

    // Update is called once per frame
    void Update()
    {
        //No se usa, aun
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
