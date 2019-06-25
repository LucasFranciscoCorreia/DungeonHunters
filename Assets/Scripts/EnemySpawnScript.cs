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
        if (n < pos.Length)
            n = pos.Length;
        int i;
        spawns = new GameObject[n];
        for (i = 0; i < pos.Length; i++)
        {
            var j = Random.Range(0, enemies.Length);
            var x = Random.Range(-2, 2);
            var y = Random.Range(-2, 2);
            spawns[i] = (Instantiate(enemies[j], new Vector3(pos[i].position.x + x, pos[i].position.y + y, 0), pos[i].rotation));
            spawns[i].GetComponent<EnemyHealth>().isRespawnable = true;
        }
        for (; i < n; i++)
        {
            var j = Random.Range(0, enemies.Length);
            var k = Random.Range(0, pos.Length);
            var x = Random.Range(-2, 2);
            var y = Random.Range(-2, 2);
            spawns[i] = (Instantiate(enemies[j], new Vector3(pos[k].position.x + x, pos[k].position.y + y, 0), pos[k].rotation));
            spawns[i].GetComponent<EnemyHealth>().isRespawnable = true;

        }
    }

    public void CallNewOne(GameObject obj)
    {
        int i;
        for(i = 0; i < spawns.Length;i++)
        {
            if (spawns[i] == obj)
            {
                spawns[i] = null; ;
                Destroy(obj);
                break;
            }
        }
        var x = Random.Range(-2, 2);
        var y = Random.Range(-2, 2);
        var j = Random.Range(0, enemies.Length);
        var k = Random.Range(0, pos.Length);
        var enemie = Instantiate(enemies[j], new Vector3(pos[k].position.x + x, pos[k].position.y + y, 0), pos[k].rotation);
        enemie.GetComponent<EnemyHealth>().isRespawnable = true;
        spawns[i] = enemie;
        Debug.Log("Enemy spawned at position " + k);

    }
}

