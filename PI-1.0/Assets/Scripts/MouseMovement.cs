using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidade do rato
    public float leftLimit = -5f; // Limite � esquerda
    public float rightLimit = 5f; // Limite � direita
    public Transform basePosition; // Arraste a base para essa vari�vel no Inspector
    public ParticleSystem movementParticles; // Arraste o ParticleSystem aqui no Inspector
    private bool movingRight = true;
    private bool isMovingToBase = false; // Vari�vel para controlar o movimento de vaiv�m
    private Rigidbody2D rb;
    private Animator animator; // Para controlar a anima��o

    void Start()
    {
        // Garantir que o sprite come�a olhando pra esquerda
        if (transform.localScale.x > 0)
        {
            FlipSprite(); // Garante que o rato come�a virado para a esquerda
        }

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Obt�m o componente Animator

        if (movementParticles != null)
        {
            movementParticles.Play(); // Certifique-se de que as part�culas comecem ao iniciar
        }
    }

    void Update()
    {
        // S� movimenta de um lado para o outro se n�o estiver indo para a base
        if (!isMovingToBase)
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
        isMovingToBase = true; // Desativa o movimento de vaiv�m
        if (movementParticles != null)
        {
            movementParticles.Stop(); // Para as part�culas enquanto ele se move para a base
        }

        if (animator != null)
        {
            animator.speed = 0; // Para a anima��o enquanto se move para a base
        }

        // Move o rato at� a base, respeitando colis�es
        while (Vector2.Distance(transform.position, basePosition.position) > 0.1f)
        {
            Vector2 direction = (basePosition.position - transform.position).normalized;
            rb.velocity = direction * speed;
            yield return null;
        }

        rb.velocity = Vector2.zero; // Para de se mover quando chega na base

        // Quando chegar na base, pare as part�culas e a anima��o
        if (movementParticles != null)
        {
            movementParticles.Stop(); // Para as part�culas
        }

        if (animator != null)
        {
            animator.speed = 0; // Mant�m a anima��o parada na base
        }

        // Garantir que o rato sempre vire para a esquerda
        if (transform.localScale.x < 0) // Se ele estiver virado para a direita
        {
            FlipSprite(); // Vira o rato para a esquerda
        }
    }
}