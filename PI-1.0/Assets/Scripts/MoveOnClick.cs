using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    public float moveDistance = 1.0f; // Distância que o objeto vai se mover
    public float speed = 2.0f; // Velocidade de movimento
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool hasMoved = false; // Flag para verificar se já moveu

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        // Verifica se o objeto está se movendo e continua o movimento
        if (isMoving)
        {
            // Move o objeto na direção da posição alvo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Verifica se o objeto chegou à posição alvo
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    void OnMouseDown()
    {
        // Verifica se o objeto já foi movido
        if (hasMoved)
            return;

        // Define a nova posição alvo para frente (eixo Y)
        targetPosition += transform.up * moveDistance;
        isMoving = true;
        hasMoved = true; // Marca que o objeto já se moveu
    }
}
