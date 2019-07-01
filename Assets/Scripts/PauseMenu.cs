using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu, Optionsmenu;
    public Slider slider;
    public GameObject Map;
    public static bool isPaused;

    public static bool IsPaused()
    {
        return isPaused;
    }

    void Awake()
    {
        isPaused = false;
        slider.value = FindObjectOfType<VolumeScript>().volume;
        Pausemenu.SetActive(false);
        Optionsmenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Pausemenu.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Pausemenu.SetActive(false);
        Optionsmenu.SetActive(false);
        isPaused = false;
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
        isPaused = false;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
