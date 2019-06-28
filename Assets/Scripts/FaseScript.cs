using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaseScript : MonoBehaviour
{

    public int keys1;
    public int keys2;

    public GameObject closedDoor, openedDoor;
    public BoxCollider2D collider;

    public LevelChangerScript lcs;

    public GameObject[] keys;

    public Transform[] spots;
    public List<int> positions;
    public Text key1;
    public Text key2;
    public Text showDoor;

    public void Start()
    {
        keys1 = 0;
        keys2 = 0;
        showDoor.enabled = false;
        while (positions.Count < 4)
        {
            int i = Random.Range(0, spots.Length);
            if (!positions.Contains(i))
            {
                positions.Add(i);
            }
        }
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].transform.position = spots[positions[i]].position;
        }
        collider.enabled = false;
    }

    void FixedUpdate()
    {
        if (keys1 >= 2 && keys2 >= 2)
        {
            closedDoor.SetActive(true);
            openedDoor.SetActive(true);
            collider.enabled = true;
            showDoor.enabled = true;
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
}
