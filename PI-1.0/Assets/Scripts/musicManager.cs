using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Faz o objeto persistir
        }
        else
        {
            Destroy(gameObject); // Remove duplicatas
        }
    }
}
