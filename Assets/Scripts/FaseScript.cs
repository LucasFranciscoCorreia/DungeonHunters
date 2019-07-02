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

    public GameObject quest1, quest1_1, quest1_2;
    public GameObject quest1Scratch, quest1_1Scratch, quest1_2Scratch;
    public GameObject quest2Scratch;
    public GameObject quest3Scratch;
    public Text quest2;
    public Text quest3;

    public int defeated;
    public int numEnemies;
    public bool isFinalLevel;

    public int numKeys;

    public void Start()
    {
        defeated = 0;
        keys1 = 0;
        keys2 = 0;

        showDoor.enabled = false;

        while (positions.Count < numKeys)
        {
            int i = Random.Range(0, spots.Length);
            if (!positions.Contains(i))
            {
                positions.Add(i);
            }
        }

        for (int i = 0; i < numKeys; i++)
        {
            keys[i].transform.position = spots[positions[i]].position;
        }

        quest3.text = "Defeat " + numEnemies + " Enemies [0/" + numEnemies + "]";

        if (!isFinalLevel)
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
            quest1Scratch.SetActive(true);
        }
        if(defeated == numEnemies)
        {
            FindObjectOfType<hero_script>().damage++;
            quest3Scratch.SetActive(true);
            defeated++;
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
                quest1_1Scratch.SetActive(true);
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
                quest1_2Scratch.SetActive(true);
                break;
        }
    }

    public void EnemieKilled()
    {
        defeated++;
        if(defeated < numEnemies)
        {
            quest3.text = "Defeat " + numEnemies + " Enemies[" + defeated + "/" + numEnemies + "]";
        }
        else
        {
            quest3.text = "Defeat " + numEnemies + " Enemies[" + numEnemies + "/" + numEnemies + "]";
        }
    }
}
