using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase1Script : MonoBehaviour
{
    public int keys1;
    public int keys2;

    public GameObject closedDoor, openedDoor;
    public BoxCollider2D collider;

    public GameObject[] keys;
    private int i;

    public Transform[] spots;
    public List<int> positions;
    public Text key1;
    public Text key2;

    public LevelChangerScript lcs;
    void Start()
    {
        i = 0;
        keys1 = 0;
        keys2 = 0;
        while(positions.Count < 4)
        {
            int i = Random.Range(0, spots.Length);
            if (!positions.Contains(i))
            {
                positions.Add(i);
            }
        }
        for (int i = 0; i < keys.Length; i++) {
            keys[i].transform.position = spots[positions[i]].position;
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
        switch (keys1)
        {
            case 1:
                key1.text = "1/2";
                break;
            case 2:
                key1.text = "2/2";
                break;
        }
    }

    public void GotKey2()
    {
        this.keys2++;
        switch (keys2)
        {
            case 1:
                key2.text = "1/2";
                break;
            case 2:
                key2.text = "2/2";
                break;
        }
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

