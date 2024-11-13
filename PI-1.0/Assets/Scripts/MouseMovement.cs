using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidade do rato
    public float leftLimit = -5f; // Limite à esquerda
    public float rightLimit = 5f; // Limite à direita
    public Transform basePosition; // Arraste a base para essa variável no Inspector
    public ParticleSystem movementParticles; // Arraste o ParticleSystem aqui no Inspector
    private bool movingRight = true;
    private bool isMovingToBase = false; // Variável para controlar o movimento de vaivém
    private Rigidbody2D rb;
    private Animator animator; // Para controlar a animação

    void Start()
    {
        // Garantir que o sprite começa olhando pra esquerda
        if (transform.localScale.x > 0)
        {
            FlipSprite(); // Garante que o rato começa virado para a esquerda
        }

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Obtém o componente Animator

        if (movementParticles != null)
        {
            movementParticles.Play(); // Certifique-se de que as partículas comecem ao iniciar
        }
    }

    void Update()
    {
        // Só movimenta de um lado para o outro se não estiver indo para a base
        if (!isMovingToBase)
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
        isMovingToBase = true; // Desativa o movimento de vaivém
        if (movementParticles != null)
        {
            movementParticles.Stop(); // Para as partículas enquanto ele se move para a base
        }

        if (animator != null)
        {
            animator.speed = 0; // Para a animação enquanto se move para a base
        }

        // Move o rato até a base, respeitando colisões
        while (Vector2.Distance(transform.position, basePosition.position) > 0.1f)
        {
            Vector2 direction = (basePosition.position - transform.position).normalized;
            rb.velocity = direction * speed;
            yield return null;
        }

        rb.velocity = Vector2.zero; // Para de se mover quando chega na base

        // Quando chegar na base, pare as partículas e a animação
        if (movementParticles != null)
        {
            movementParticles.Stop(); // Para as partículas
        }

        if (animator != null)
        {
            animator.speed = 0; // Mantém a animação parada na base
        }

        // Garantir que o rato sempre vire para a esquerda
        if (transform.localScale.x < 0) // Se ele estiver virado para a direita
        {
            FlipSprite(); // Vira o rato para a esquerda
        }
    }
}