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
        PlayerPrefs.DeleteKey("currentXp");
    }
    public void ReturnMenu()
    {
        Destroy(FindObjectOfType<VolumeScript>().gameObject);
        lcs.FadeToLevel("Menu");
    }

    public void PlayAgain()
    {
        lcs.FadeToLevel("Fase1");
    }
}
