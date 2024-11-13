using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SimpleCutscene : MonoBehaviour
{
    public Image image1; // Primeira imagem
    public Image image2; // Segunda imagem
    public float timeBetweenImages = 3f; // Tempo entre as imagens
    public GameObject cutscenePanel; // Painel com as imagens
    public Button nextButton; // Botão para avançar para a fase
    public string sceneToLoad; // Nome da cena que será carregada após a cutscene

    void Start()
    {
        // Inicialmente desativa o botão
        nextButton.gameObject.SetActive(false);
        // Opcional: Desativa a cutscene no início
        cutscenePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Função chamada pelo botão da fase para iniciar a cutscene
    public void StartCutscene()
    {
        cutscenePanel.SetActive(true);
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        // Exibe a primeira imagem
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);

        // Espera o tempo definido antes de passar para a próxima imagem
        yield return new WaitForSeconds(timeBetweenImages);

        // Exibe a segunda imagem
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(true);

        // Espera mais alguns segundos antes de terminar a cutscene
        yield return new WaitForSeconds(timeBetweenImages);

        // Ativa o botão para ir para a fase
        nextButton.gameObject.SetActive(true);
    }

    // Função chamada pelo botão para carregar a fase
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}