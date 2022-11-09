using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Configuracion : MonoBehaviour
{
    private float volumen;
    private int tamLetra;
    private int colorSet;
    private string[] colores = new string[3];

    public AudioSource audioSource;

    [SerializeField] private Slider sliderVolumen;
    [SerializeField] private Slider sliderSizeText;
    [SerializeField] private TMP_Dropdown dropColores;
    [SerializeField] private Canvas ajustes;


    void Start()
    {
        colorSet = PlayerPrefs.GetInt("SetColor");
        tamLetra = PlayerPrefs.GetInt("SizeTexto");
        volumen = PlayerPrefs.GetFloat("Volumen");

        sliderVolumen.value = volumen;
        sliderSizeText.value = tamLetra;
        dropColores.value = colorSet;

        audioSource.volume = volumen;
    }

    void Update()
    {
        audioSource.volume = volumen;
        sliderVolumen.value = volumen;
        sliderSizeText.value = tamLetra;
        dropColores.value = colorSet;

    }

    public string[] getColorLetra()
    {
        switch (colorSet)
        {
            //la posicion 1 del arreglo es para el que esta mal, la 2 para el que esta bien
            case 0:
                colores[0] = "black";
                colores[1] = "red";
                colores[2] = "green";
                break;
            case 1:
                colores[0] = "black";
                colores[1] = "#FF009C";
                colores[2] = "#0FFF00";
                break;
            case 2:
                //3 green: #FEDC18 red: #01A1FF
                colores[0] = "black";
                colores[1] = "#01A1FF";
                colores[2] = "#FEDC18";
                break;
            case 3:
                //4 green: #FEDC18 red: #DBEEFF
                colores[0] = "black";
                colores[1] = "#DBEEFF";
                colores[2] = "#FEDC18";
                break;
            case 4:
                //5 green: #66F0F0 red: #FF0046
                colores[0] = "black";
                colores[1] = "#FF0046";
                colores[2] = "#66F0F0";
                break;
            case 5:
                //6 green: #66F0F0 red: #FB3559
                colores[0] = "black";
                colores[1] = "#FB3559";
                colores[2] = "#66F0F0";
                break;
            default:
                colores[0] = "black";
                colores[1] = "red";
                colores[2] = "green";
                break;
        }
        return colores;
    }

    public int getTamanioLetra()
    {
        return tamLetra;
    }

    public void cambiarTamanioLetra(float newTamLetra)
    {
        tamLetra = (int)newTamLetra;
        PlayerPrefs.SetInt("SizeTexto", tamLetra);
        PlayerPrefs.Save();
        Debug.Log("Sirve esta madre");
    }

    public void cambiarVolumen(float newVolumen)
    {
        volumen = newVolumen;
        PlayerPrefs.SetFloat("Volumen", volumen);
        PlayerPrefs.Save();
    }

    public void cambiarColorTexto(int newColorSet)
    {
        colorSet = newColorSet;
        PlayerPrefs.SetInt("SetColor", colorSet);
        PlayerPrefs.Save();
    }

    public void salirAjustes()
    {
        ajustes.enabled = false;
    }

    public void subirVolumen()
    {
        volumen += .1f;
    }
    public void bajarVolumen()
    {
        volumen -= .1f;
    }

    public void aumentarFuente()
    {
        tamLetra += 10;
    }
    public void reducirFuente()
    {
        tamLetra -= 10;
    }
}
