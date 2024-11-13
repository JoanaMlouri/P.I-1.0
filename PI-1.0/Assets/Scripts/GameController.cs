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
    public string nextSceneName; // Nome da cena para trocar
    public UnityEngine.UI.Button nextButton; // Refer�ncia para o bot�o que aparece quando as pe�as estiverem encaixadas
    void Start()
    {
        UpdateScoreText();
        nextButton.gameObject.SetActive(false);
        Time.timeScale = 1;
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
        if (clickableObjects.Count == 11)
        {
            ShowNextButton();
        }
    }
    void ShowNextButton()
    {
        // Ativa o bot�o
        nextButton.gameObject.SetActive(true);
    }
    public void NextButton()
    {

        SceneManager.LoadScene("Segunda fase");
    }
}
