using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu;

    public void Pause()
    {
        Time.timeScale = 0;
        Pausemenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Pausemenu.SetActive(false);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
