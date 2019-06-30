using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject Map;
    public static bool isPaused;
    public static bool seeingMap;
    public static bool IsPaused()
    {
        return isPaused;
    }
    void Start()
    {
        isPaused = false;
        seeingMap = false;
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
                if(!seeingMap)
                    Pause();
            }
        }else if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (seeingMap)
            {
                ReturnGame();
                seeingMap = false;
            }
            else
            {
                if (!isPaused)
                {
                    SeeMap();
                    seeingMap = true;
                }
            }
        }
    }

    public void SeeMap()
    {
        Time.timeScale = 0;
        isPaused = true;
        Map.SetActive(true);
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        Map.SetActive(false);
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
