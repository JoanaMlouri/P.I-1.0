using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    public float moveDistance = 1.0f; // Dist�ncia que o objeto vai se mover
    public float speed = 2.0f; // Velocidade de movimento
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool hasMoved = false; // Flag para verificar se j� moveu

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        // Verifica se o objeto est� se movendo e continua o movimento
        if (isMoving)
        {
            // Move o objeto na dire��o da posi��o alvo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Verifica se o objeto chegou � posi��o alvo
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    void OnMouseDown()
    {
        // Verifica se o objeto j� foi movido
        if (hasMoved)
            return;

        // Define a nova posi��o alvo para frente (eixo Y)
        targetPosition += transform.up * moveDistance;
        isMoving = true;
        hasMoved = true; // Marca que o objeto j� se moveu
    }
}
