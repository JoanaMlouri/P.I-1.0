using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    public Texture2D mouseOverTexture; // A nova textura do mouse quando sobre o objeto
    public Vector2 hotspot = Vector2.zero; // Ponto de foco da textura do cursor

    void OnMouseEnter()
    {
        // Altera a textura do cursor para a nova
        if (mouseOverTexture != null)
        {
            Cursor.SetCursor(mouseOverTexture, hotspot, CursorMode.Auto);
        }
    }

    void OnMouseExit()
    {
        // Retorna ao cursor padrão do sistema
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
