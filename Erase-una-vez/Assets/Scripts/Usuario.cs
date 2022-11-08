using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usuario : MonoBehaviour
{
    [SerializeField] private int NoEstrellas, NivelActual;

    // Instancia de la clase
    public static Usuario Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(this);
        }
        else
        {
            Instancia = this;
            DontDestroyOnLoad(this);
        }
    }
}
