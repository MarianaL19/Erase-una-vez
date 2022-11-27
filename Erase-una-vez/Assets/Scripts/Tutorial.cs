using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject ventanaTutorial;
    [SerializeField] public Escritura escritura;

    bool iniciado = false;

    void Update()
    {
        if (Input.anyKeyDown && !iniciado)
        {
            iniciado = true;
            escritura.iniciarTiempo();
            ventanaTutorial.SetActive(false);
        }
    }
}
