using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Initialization
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // GetType() will get type of class in current script aka MusicPlayer, just for more generic coding purposes
        if (FindObjectsOfType(GetType()).Length>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
