using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escritura : MonoBehaviour
{
    public Text wordOutput = null;
    public Text textoPasado = null;

    private string palabraRestante = string.Empty;
    //hay que poner todo el texto en minusculas porque todos los inputs se leen así
    private string palabraActual = "prueba texto";
    private string palabraPasada = string.Empty;
    private int aciertos;
    private int errores;
    private bool red;
    private string[] colorLetra = new string[3];

    public Configuracion configuracion;

    void Start()
    {
        colorLetra = configuracion.getColorLetra();
        wordOutput.fontSize = configuracion.getTamanioLetra();
        textoPasado.fontSize = configuracion.getTamanioLetra();

        SetPalabraActual();
    }
    private void SetPalabraActual()
    {
        //Aqui reiniciamos el texto cuando se termina de escribir una palabra, puede usarse para leer lineas
        SetPalabraRestante(palabraActual, "");
        Debug.Log("Aciertos" + aciertos);
        Debug.Log("Errores" + errores);
        aciertos = 0;
        errores = 0;
    }

    private void SetPalabraRestante(string palabraActualizada, string palabraAntigua)
    {
        //Aquí actualizamos lo que se muestra en cada text 
        palabraRestante =  palabraActualizada;
        string palabraMostrar = "<color=\"" + colorLetra[0] + "\">" + palabraActualizada + "</color>";
        wordOutput.text = palabraMostrar;

        palabraPasada = palabraAntigua;
        textoPasado.text = palabraPasada;
    }

    private void Update()
    {
        //Leemos en cada frame los valores de configuración para detectar cambios
        wordOutput.fontSize = configuracion.getTamanioLetra();
        textoPasado.fontSize = configuracion.getTamanioLetra();
        colorLetra = configuracion.getColorLetra();

        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                CompararCaracter(keysPressed);
            }
        }

    }

    private void CompararCaracter(string typedLetter)
    {
        if (palabraRestante.IndexOf(typedLetter) == 0)
        {
            red = false;
            aciertos++;
        }
        else
        {
            red = true;
            errores++;
        }
        QuitarLetra();
        if (palabraRestante.Length == 0)
            SetPalabraActual();
    }

    private void QuitarLetra()
    {
        if(red)
            palabraPasada += "<color=\"" + colorLetra[1] + "\">" + palabraRestante.Substring(0, 1) + "</color>";
            //"<color=\"" + colorLetra[0] + "\">" + palabraActualizada + "</color>";
        else
            palabraPasada += "<color=\"" + colorLetra[2] + "\">" + palabraRestante.Substring(0, 1) + "</color>";

        string newString = palabraRestante.Remove(0, 1);
        SetPalabraRestante(newString, palabraPasada);
    }

}
