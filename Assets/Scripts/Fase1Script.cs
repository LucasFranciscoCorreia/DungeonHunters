using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase1Script : MonoBehaviour
{
    public int keys1;
    public int keys2;

    public GameObject[] keys;
    private int i;
    public GameObject closedDoor, openedDoor;
    public BoxCollider2D collider;

    public LevelChangerScript lcs;
    void Start()
    {
        i = 0;
        keys1 = 0;
        keys2 = 0;
        for (int i = 1; i < keys.Length; i++) {
            keys[i].SetActive(false);
        }
        collider.enabled = false;
        lcs = FindObjectOfType<LevelChangerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(keys1 >= 2 && keys2 >= 2)
        {
            closedDoor.SetActive(true);
            openedDoor.SetActive(true);
            collider.enabled = true;
        }
    }

    public void GotKey1()
    {
        this.keys1++;
        if(i < 3)
            keys[++i].SetActive(true);    
    }

    public void GotKey2()
    {
        this.keys2++;
        if (i < 3)
            keys[++i].SetActive(true);
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
