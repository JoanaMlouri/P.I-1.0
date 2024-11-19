using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMovement : MonoBehaviour
{
    public float speed = 2.0f;  // Velocidade do movimento
    public float height = 0.5f; // Altura do movimento

    private Vector3 startPosition;

    void Start()
    {
        // Guarda a posição inicial do objeto
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula o novo valor de y usando uma função senoidal
        float newY = Mathf.Sin(Time.time * speed) * height;

        // Atualiza a posição do objeto mantendo o eixo x e z fixos
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }
}
