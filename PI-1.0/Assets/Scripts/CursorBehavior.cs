using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    public Texture2D mouseOverTexture; // A nova textura do mouse quando sobre o objeto

    void OnMouseEnter()
    {
        // Altera a textura do cursor para a nova
        Cursor.SetCursor(mouseOverTexture, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        // Retorna ao cursor padrão do sistema
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
