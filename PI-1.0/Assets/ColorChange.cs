using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Defina as cores para alternar
    public Color color1 = Color.red;
    public Color color2 = Color.white;

    private Renderer objectRenderer;
    private bool isColor1 = true;

    void Start()
    {
        // Obtém o Renderer do objeto
        objectRenderer = GetComponent<Renderer>();
        // Define a cor inicial
        objectRenderer.material.color = color1;
    }

    void OnMouseDown()
    {
        // Alterna a cor do objeto quando for clicado
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
