using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public string text;
    public List<ObjetoClicavel> clickableObjects = new List<ObjetoClicavel>();

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
        SceneManager.LoadScene("Segunda fase");
    }
}
