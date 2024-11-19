using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        // Verifica se j� existe uma inst�ncia do MusicManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // N�o destr�i ao mudar de cena
        }
        else
        {
            Destroy(gameObject); // Impede duplica��o de som
        }
    }
}
