using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    // Defina a posição de destino para onde o objeto será movido
    public Vector3 targetPosition;
    // Defina a velocidade do movimento
    public float moveSpeed = 5f;

    private bool isMoving = false;

    void Update()
    {
        // Verifica se o objeto está se movendo
        if (isMoving)
        {
            // Move o objeto em direção à posição de destino
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Verifica se o objeto chegou à posição de destino
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false; // Para o movimento
            }
        }
    }

    // Este método será chamado quando o objeto for clicado
    void OnMouseDown()
    {
        isMoving = true; // Inicia o movimento do objeto
    }
}
