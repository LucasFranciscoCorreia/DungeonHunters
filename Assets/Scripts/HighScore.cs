using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI maxScore;

    // Start is called before the first frame update
    void Start()
    {
        maxScore.text = PlayerPrefs.GetInt("maxScore").ToString();
    }


    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        maxScore.text = PlayerPrefs.GetInt("maxScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
