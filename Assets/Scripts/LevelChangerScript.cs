using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
    public Animator animator;
    private string levelName;

    public void FadeToLevel(string levelName)
    {
        this.levelName = levelName;
        animator.SetTrigger("fadeout");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelName);
    }
}
