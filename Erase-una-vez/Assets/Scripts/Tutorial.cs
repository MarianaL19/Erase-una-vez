using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject ventanaTutorial;
    [SerializeField] private Escritura escritura;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            ventanaTutorial.SetActive(false);
            escritura.iniciarTiempo();
        }
    }
}
