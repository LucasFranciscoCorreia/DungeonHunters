using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public Transform[] pos;
    public GameObject[] enemies;
    public List<GameObject> spawns;
    public int n;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < n; i++)
        {
            var j = Random.Range(0, enemies.Length);
            var x = Random.Range(0, 2);
            var y = Random.Range(0, 2);
            spawns.Add(Instantiate(enemies[j], pos[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
