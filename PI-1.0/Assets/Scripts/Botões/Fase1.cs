using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase1 : MonoBehaviour
{
    public SimpleCutscene cutsceneScript; // Arraste o script da cutscene aqui
    public string sceneToLoad; // Nome da cena da fase a ser carregada
    public void fase1()
    {
        SceneManager.LoadScene("PrimeiraFase");
    }
    public void OnPhaseButtonClicked()
    {
        // Define o nome da cena que será carregada após a cutscene
        cutsceneScript.sceneToLoad = sceneToLoad;
        // Inicia a cutscene
        cutsceneScript.StartCutscene();
    }
}
