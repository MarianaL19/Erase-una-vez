using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    void Start()
    {
        SetPalabraActual();
        aciertos = 0;
        errores = 0;

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
        palabraRestante = palabraActualizada;
        wordOutput.text = palabraRestante;

        palabraPasada = palabraAntigua;
        textoPasado.text = palabraPasada;
    }

    private void Update()
    {
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
            palabraPasada +=  "<color=\"red\">" + palabraRestante.Substring(0, 1) + "</color>";
        else
            palabraPasada += "<color=\"green\">" + palabraRestante.Substring(0, 1) + "</color>";

        string newString = palabraRestante.Remove(0, 1);

        SetPalabraRestante(newString, palabraPasada);
    }

}
