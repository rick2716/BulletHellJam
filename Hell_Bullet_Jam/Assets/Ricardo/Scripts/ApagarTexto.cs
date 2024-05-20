using ND_VariaBULLET;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarTexto : MonoBehaviour
{
    public OnScreenDisplay texto;
    // Update is called once per frame
    void Update()
    {
        texto = GameObject.FindObjectOfType<OnScreenDisplay>();
        if(texto != null)
        {
            texto.enabled = false;
        }
        else if(texto == null)
        {
            return;
        }
    }
}
