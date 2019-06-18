using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{

    public LevelChangerScript lcs;

    private void Start()
    {
        lcs = FindObjectOfType<LevelChangerScript>();
    }
    public void ReturnMenu()
    {
        lcs.FadeToLevel("Menu");
    }

    public void PlayAgain()
    {
        lcs.FadeToLevel("Fase1");
    }
}
