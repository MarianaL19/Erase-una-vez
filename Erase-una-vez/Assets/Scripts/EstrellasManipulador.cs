using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellasManipulador : MonoBehaviour
{
    public GameObject[] estrellas;

    //Variables de prueba, en el entorno real seran obtenidas con los resultados del jugador
    private int tiempo;
    private int precision;
    private int palabrasXMinuto;

    //Funcion para sacar la cantidad de estrellas obtenidas
    public void estrellasObtenidas()
    {
        //Valores arbitrarios para pruebas, pueden ser cambiados
        tiempo = 100;
        precision = 85;
        palabrasXMinuto = 65;
        
        if(precision >= 70 && tiempo <= 150 && palabrasXMinuto >= 50){ //Caso en el que son obtenidas las 3 estrellas
            estrellas[0].SetActive(true);
            estrellas[1].SetActive(true);
            estrellas[2].SetActive(true);
        } else if (precision >= 70 && tiempo <= 150){ //Caso en el que son obtenidas 2 de las 3 estrellas
            estrellas[0].SetActive(true);
            estrellas[1].SetActive(true);
        } else if (precision >= 70 && palabrasXMinuto >= 50){ //Caso en el que son obtenidas 2 de las 3 estrellas
            estrellas[0].SetActive(true);
            estrellas[1].SetActive(true);
        } else if (tiempo <= 150 && palabrasXMinuto >= 50){ //Caso en el que son obtenidas 2 de las 3 estrellas
            estrellas[0].SetActive(true);
            estrellas[1].SetActive(true);
        } else if(precision >= 70 || tiempo <= 150 || palabrasXMinuto >= 50){ //Caso en el que solo una estrella es obtenida
            estrellas[0].SetActive(true);
        }
    } 
}
