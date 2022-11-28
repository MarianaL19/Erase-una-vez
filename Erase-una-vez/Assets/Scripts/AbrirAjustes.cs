using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirAjustes : MonoBehaviour
{
    [SerializeField] private GameObject ajustes;


    public void abrirAjustes()
    {
        ajustes.gameObject.SetActive(true);
    }

    public void cerrarAjustes()
    {
        ajustes.gameObject.SetActive(false);
    }
}
