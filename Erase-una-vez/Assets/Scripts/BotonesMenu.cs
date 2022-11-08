using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesMenu : MonoBehaviour
{
    [SerializeField] Text texto;
    [SerializeField] private Button ajustes;
    [SerializeField] private Button salir;

    public int noEstrellas;

    // Start is called before the first frame update
    void Start()
    {
        noEstrellas = PlayerPrefs.GetInt("noEstrellas");
        texto.text = noEstrellas.ToString();
    }

    public void irAjustes()
    {
        //Falta modificarlo para que se vaya a la escena de ajustes
        //SceneManager.LoadScene(0);

        //Dejaré este set de noEstrellas para poder testear
        PlayerPrefs.SetInt("noEstrellas", 10);
        PlayerPrefs.Save();
    }

    public void salirJuego()
    {
        Application.Quit();
        Debug.Log("salio del juego");

    }
}
