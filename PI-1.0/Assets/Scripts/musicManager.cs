using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        // Verifica se já existe uma instância do MusicManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Não destrói ao mudar de cena
        }
        else
        {
            Destroy(gameObject); // Impede duplicação de som
        }
    }
}
