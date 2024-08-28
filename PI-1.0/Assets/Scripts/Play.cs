
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Nome da cena que voc� quer carregar
    public string sceneName;

    // Fun��o que ser� chamada ao pressionar o bot�o
    public void Jogar()
    {
        SceneManager.LoadScene(sceneName);
    }
}
