using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidade do rato
    public float leftLimit = -5f; // Limite à esquerda
    public float rightLimit = 5f; // Limite à direita
    public Transform basePosition; // Arrasta a base para essa variável no Inspector
    private Rigidbody2D rb;
    private bool isMovingToBase = false; // Flag para controlar se está indo para a base
    private bool movingRight = true;

    void Start()
    {
        // Garantir que o sprite começa olhando pra esquerda
        if (transform.localScale.x > 0)
        {
            FlipSprite();
        }
        rb = GetComponent<Rigidbody2D>();

    }
   

    void Update()
    {
        
        // Verifica a direção do movimento
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightLimit)
            {
                movingRight = false; // Inverte a direção
                FlipSprite(); // Inverte o sprite
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftLimit)
            {
                movingRight = true; // Inverte a direção
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
        if (!isMovingToBase) // Só ativa se ainda não estiver indo pra base
        {
            isMovingToBase = true; // Ativa o modo de ir para a base
            StartCoroutine(MoveToBase());
        }
    }

    private System.Collections.IEnumerator MoveToBase()
    {
        // Liga a gravidade pra evitar que ele "flutue"
        rb.gravityScale = 1f;

        // Move o rato até a base, respeitando colisões
        while (Vector2.Distance(transform.position, basePosition.position) > 0.1f)
        {
            Vector2 direction = (basePosition.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y); // Mantém o eixo Y
            yield return null;
        }

        // Para o movimento ao chegar na base
        rb.velocity = Vector2.zero;
        isMovingToBase = false; // Desativa a flag depois de chegar na base
    }
}
