using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public Transform[] pos;
    public GameObject[] enemies;
    public GameObject[] spawns;
    
    public int n;

    // Start is called before the first frame update
    void Start()
    {
        spawns = new GameObject[n];
        for (int i = 0; i < n; i++)
        {
            var j = Random.Range(0, enemies.Length);
            var x = Random.Range(-2, 2);
            var y = Random.Range(-2, 2);
            Debug.Log(pos[i].position);
            spawns[i] = Instantiate(enemies[j],pos[i]);
            spawns[i].GetComponent<EnemyHealth>().isRespawnable = true;
        }
    }

    public void CallNewOne()
    {
        for(int i = 0; i < n; i++)
        {
            if(spawns[i] == null)
            {
                var j = Random.Range(0, enemies.Length);
                spawns[i] = Instantiate(enemies[j], pos[i]);
                spawns[i].GetComponent<EnemyHealth>().isRespawnable = true;
            }
        }
    }
}
