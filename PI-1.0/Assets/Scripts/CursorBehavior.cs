using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    public Texture2D cursorTexture; // Textura do novo cursor
    public Vector2 hotSpot = Vector2.zero; // Ponto ativo do cursor (pode ser ajustado)

    void OnMouseEnter()
    {
        // Muda o cursor para a nova textura quando o mouse passa sobre o objeto
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        // Restaura o cursor para o padrão do sistema quando o mouse sai do objeto
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
