using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManeger : MonoBehaviour
{
    private static MusicManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Faz o objeto persistir
            Debug.Log("MusicManager iniciado e persistente!");
        }
        else
        {
            Debug.Log("Duplicata do MusicManager encontrada e destruída!");
            Destroy(gameObject); // Remove duplicatas
        }
    }
}
