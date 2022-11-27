using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject ventanaTutorial;
    [SerializeField] public Escritura escritura;

    void Update()
    {
        
        if (Input.anyKeyDown)
        {    
            escritura.iniciarTiempo();
            ventanaTutorial.SetActive(false);
        }
    }
}
