﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    LevelChangerScript lcs;
    
    public void Start()
    {
        PlayerPrefs.DeleteKey("currentXp");
        lcs = FindObjectOfType<LevelChangerScript>();
    }

    public void PlayGame()
    {
        lcs.FadeToLevel("Fase1");
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void Credits()
    {
        lcs.FadeToLevel("Credits");
    }
}
