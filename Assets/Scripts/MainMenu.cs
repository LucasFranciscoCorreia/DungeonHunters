﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void DebugGame()
    {
        SceneManager.LoadScene("Debug");
    }
}
