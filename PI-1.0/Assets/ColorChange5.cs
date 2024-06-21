using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange5 : MonoBehaviour
{
    // Defina as cores para alternar
    public Color color1 = Color.red;
    public Color color2 = Color.white;

    private Renderer objectRenderer;
    private bool isColor1 = true;

    void Start()
    {
        // Obt�m o Renderer do objeto
        objectRenderer = GetComponent<Renderer>();
        // Define a cor inicial
        objectRenderer.material.color = color1;
    }
    private void OnMouseUp()
    {
        //Quando solta o clique // Alterna a cor do objeto quando for clicado
        if (isColor1)
        {
            objectRenderer.material.color = color2;
        }
        else
        {
            objectRenderer.material.color = color1;
        }

        isColor1 = !isColor1;
    }
}