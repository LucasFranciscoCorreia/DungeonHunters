using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int numHearts;
    public int health;
    public AudioManager audio;
    public GameObject[] drops;
    public EnemySpawnScript spawn;
    public bool isRespawnable;
    public bool isSummoner;

    private void Start()
    {
        health = 2 * numHearts;
        spawn = FindObjectOfType<EnemySpawnScript>();
    }

    private void Update()
    {
        if(health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("inimigoMorre");
            var randomNumber = Random.Range(1, 101);
            var pos = this.transform.position;

            if(randomNumber <= 5)
            {
                drops[2].transform.position = pos;
                Instantiate(drops[2]);
            }else if(randomNumber <= 25)
            {
                drops[1].transform.position = pos;
                Instantiate(drops[1]);
            }else if(randomNumber <= 80)
            {
                drops[0].transform.position = pos;
                Instantiate(drops[0]);
            }
            if (isRespawnable)
            {
                spawn.CallNewOne(this.gameObject);
            }
            else
            {
                if(!isSummoner)
                    GetComponent<SummonScript>().summoner.FreeSpace(GetComponent<SummonScript>().index);
            }
            //Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
            health -= damage;  
    }
}