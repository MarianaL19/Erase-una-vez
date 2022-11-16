using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escritura : MonoBehaviour
{
    //Salidas de texto de unity, una para tener el texto normal y otra para guardar las letras que ya pasaron
    public Text wordOutput = null;
    public Text textoPasado = null;

    private const int MAX_ERRORES_SEGUIDOS = 20;

    private string palabraRestante = string.Empty;
    //hay que poner todo el texto en minusculas porque todos los inputs se leen as�
    private string palabraActual;
    //hay que poner todo el texto en minusculas porque todos los inputs se leen as�
    //Hay que guardar en una variable el texto que vayamos escribiendo
    private string palabraPasada = string.Empty;

    //variables para guardar aciertos, y contar errores y cambiar el color del texto  
    private int aciertos;
    private int errores;
    private int erroresSeguidos;
    private bool errorActual;

    //Guardamos los colores que se usan para el texto normal, aciertos y errores
    private string[] colorLetra = new string[3];
    private string[] texto = new string[30];
    int numLineaActual = 0;
    int totalLineas = 0;

    //Accedemos al script de configuraci�n para leer datos de �l
    public Configuracion configuracion;
    public PanelesNivel panelesNivel;

    void Start()
    {
        //leemos de configuracion el color de la letra y el tama�o del texto
        colorLetra = configuracion.getColorLetra();
        wordOutput.fontSize = configuracion.getTamanioLetra();
        textoPasado.fontSize = configuracion.getTamanioLetra();

        erroresSeguidos = 0;

        //Leo todas las lineas del archivo y las almaceno en un arreglo        
        foreach (string line in System.IO.File.ReadLines(@"Assets/Scripts/PruebaTexto.txt"))
        {
            texto[totalLineas] = line;
            totalLineas++;
        }

        SetPalabraActual();
    }
    private void SetPalabraActual()
    {
        //Aqui reiniciamos el texto cuando se termina de escribir una palabra, puede usarse para leer lineas
        if(numLineaActual == totalLineas)
        {
            Debug.Log("Ya acabaste al chile");
        }
        else
        {
            SetPalabraRestante(texto[numLineaActual], "");
            numLineaActual++;
        }
    }

    private void SetPalabraRestante(string palabraActualizada, string palabraAntigua)
    {
        //Aqu� actualizamos lo que se muestra en cada text 
        palabraRestante =  palabraActualizada;
        string palabraMostrar = "<color=\"" + colorLetra[0] + "\">" + palabraActualizada + "</color>";
        wordOutput.text = palabraMostrar;

        palabraPasada = palabraAntigua;
        textoPasado.text = palabraPasada;
    }

    private void Update()
    {
        //Leemos los valores de configuraci�n para detectar 
        wordOutput.fontSize = configuracion.getTamanioLetra();
        textoPasado.fontSize = configuracion.getTamanioLetra();
        colorLetra = configuracion.getColorLetra();

        //Aqu� habr�a una funci�n para reiniciar el nivel si se superan los errores seguidos
        if(erroresSeguidos > MAX_ERRORES_SEGUIDOS)
        {
            Debug.Log("Perdiste al chile");
        }

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
            errorActual = false;
            aciertos++;
        }
        else
        {
            errorActual = true;
            errores++;
        }
        QuitarLetra();
        if (palabraRestante.Length == 0){
            SetPalabraActual();
            //panelesNivel.activarPanel();
        }
            
    }

    private void QuitarLetra()
    {
        if (errorActual)
        {
            erroresSeguidos++;
            palabraPasada += "<color=\"" + colorLetra[1] + "\">" + palabraRestante.Substring(0, 1) + "</color>";
            //"<color=\"" + colorLetra[0] + "\">" + palabraActualizada + "</color>";
        }
        else
        {
            erroresSeguidos = 0;
            palabraPasada += "<color=\"" + colorLetra[2] + "\">" + palabraRestante.Substring(0, 1) + "</color>";
        }

        string newString = palabraRestante.Remove(0, 1);
        SetPalabraRestante(newString, palabraPasada);
    }

}
