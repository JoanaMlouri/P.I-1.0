using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    // Defina a posi��o de destino para onde o objeto ser� movido
    public Vector3 targetPosition;
    // Defina a velocidade do movimento
    public float moveSpeed = 5f;

    private bool isMoving = false;

    void Update()
    {
        // Verifica se o objeto est� se movendo
        if (isMoving)
        {
            // Move o objeto em dire��o � posi��o de destino
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Verifica se o objeto chegou � posi��o de destino
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false; // Para o movimento
            }
        }
    }

    // Este m�todo ser� chamado quando o objeto for clicado
    void OnMouseDown()
    {
        isMoving = true; // Inicia o movimento do objeto
    }
}
