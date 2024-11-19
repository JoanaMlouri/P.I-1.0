using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnClick : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasFallen = false; // Flag para verificar se j� caiu

    void Start()
    {
        // Obt�m o componente Rigidbody2D (que ser� adicionado se n�o existir)
        rb = GetComponent<Rigidbody2D>();

        // Se o Rigidbody2D n�o estiver presente, adiciona-o
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        // Desativa o Rigidbody2D inicialmente para que o objeto n�o caia
        rb.isKinematic = true;
    }

    void OnMouseDown()
    {
        // Verifica se o objeto j� caiu
        if (hasFallen)
            return;

        // Ativa o Rigidbody2D, fazendo o objeto cair
        rb.isKinematic = false;

        hasFallen = true; // Marca que o objeto j� caiu
    }
}
