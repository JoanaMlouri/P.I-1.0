using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoClicavel : MonoBehaviour
{
    public int points = 1; // Pontos adicionados por clique
    private GameController gameController;
    private Collider2D objectCollider;

    void Start()
    {
        // Encontrar o GameController na cena
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        // Obter o componente Collider do objeto
        objectCollider = GetComponent<Collider2D>();
        // Adicionar este objeto à lista de objetos clicáveis no GameController
        gameController.RegisterClickableObject(this);
    }

    void OnMouseDown()
    {
        // Quando o objeto é clicado, adicione pontos, desative o collider e notifique o GameController
        if (gameController != null && objectCollider != null)
        {
            gameController.AddPoints(points);
            objectCollider.enabled = false; // Desativar o collider para impedir cliques futuros
            gameController.ObjectClicked(this); // Notificar o GameController
        }
    }
}
