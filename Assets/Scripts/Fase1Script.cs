using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase1Script : FaseScript
{

    void Start()
    {
        lcs = FindObjectOfType<LevelChangerScript>();
        base.Start();
    }

        
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                lcs.FadeToLevel("Fase2");
                break;
        }
    }
}

