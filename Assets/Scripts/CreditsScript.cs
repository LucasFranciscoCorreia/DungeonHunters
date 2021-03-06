﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    LevelChangerScript levelChanger;
    void Start()
    {
        levelChanger = FindObjectOfType<LevelChangerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ReturnMainMenu();
        }       
    }

    void ReturnMainMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        levelChanger.FadeToLevel("Menu");
    }
}
