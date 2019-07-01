using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
    public Animator animator;
    private string levelName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

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
