using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    //Manda a llamar la función de Estrellas
    void Start()
    {
        GetComponent<EstrellasManipulador>().estrellasObtenidas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
