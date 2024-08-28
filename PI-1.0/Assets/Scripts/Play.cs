
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Nome da cena que você quer carregar
    public string sceneName;

    // Função que será chamada ao pressionar o botão
    public void Jogar()
    {
        SceneManager.LoadScene(sceneName);
    }
}
