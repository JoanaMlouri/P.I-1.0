using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidade do rato
    public float leftLimit = -5f; // Limite � esquerda
    public float rightLimit = 5f; // Limite � direita
    public Transform basePosition; // Arrasta a base para essa vari�vel no Inspector
    private bool movingRight = true;
    private Rigidbody2D rb;
    void Start()
    {
        // Garantir que o sprite come�a olhando pra esquerda
        if (transform.localScale.x > 0)
        {
            FlipSprite();
        }
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica a dire��o do movimento
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightLimit)
            {
                movingRight = false; // Inverte a dire��o
                FlipSprite(); // Inverte o sprite
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftLimit)
            {
                movingRight = true; // Inverte a dire��o
                FlipSprite(); // Inverte o sprite
            }
        }
    }

    void FlipSprite()
    {
        // Inverte o eixo X do objeto para virar o sprite
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void OnMouseDown()
    {
        StartCoroutine(MoveToBase());
    }

    private System.Collections.IEnumerator MoveToBase()
    {
        // Move o rato at� a base, respeitando colis�es
        while (Vector2.Distance(transform.position, basePosition.position) > 0.1f)
        {
            Vector2 direction = (basePosition.position - transform.position).normalized;
            rb.velocity = direction * speed;
            yield return null;
        }
        rb.velocity = Vector2.zero; // Para de se mover quando chega na base
    }
}

