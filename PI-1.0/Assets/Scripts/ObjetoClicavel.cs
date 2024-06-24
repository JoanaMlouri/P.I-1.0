using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoClicavel : MonoBehaviour
{
    public int points = 10; // Pontos adicionados por clique
    private GameController gameController;
    private Collider2D objectCollider;

    void Start()
    {
        // Encontrar o GameController na cena
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        // Obter o componente Collider do objeto
        objectCollider = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        // Quando o objeto é clicado, adicione pontos e desative o collider
        if (gameController != null && objectCollider != null)
        {
            gameController.AddPoints(points);
            objectCollider.enabled = false; // Desativar o collider para impedir cliques futuros
        }
    }
}
