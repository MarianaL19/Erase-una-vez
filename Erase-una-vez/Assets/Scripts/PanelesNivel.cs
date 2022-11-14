using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelesNivel : MonoBehaviour
{

    [SerializeField] private GameObject panelVictoria;

    public void activarPanel()
    {
        panelVictoria.gameObject.SetActive(true);
    }

    public void desactivarPanel()
    {
        panelVictoria.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        desactivarPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
