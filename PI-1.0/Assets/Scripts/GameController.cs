using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public string text;
    public List<ObjetoClicavel> clickableObjects = new List<ObjetoClicavel>();
    public float points;
    void Start()
    {
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void RegisterClickableObject(ObjetoClicavel clickableObject)
    {
        clickableObjects.Add(clickableObject);
    }

    public void ObjectClicked(ObjetoClicavel clickableObject)
    {
        clickableObjects.Remove(clickableObject);
        if (clickableObjects.Count == 0)
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        // Substitua "NextSceneName" pelo nome da cena que você deseja carregar
        
        if(points >= 11) 
        {
            SceneManager.LoadScene("Segunda fase");

        }
    }
}
