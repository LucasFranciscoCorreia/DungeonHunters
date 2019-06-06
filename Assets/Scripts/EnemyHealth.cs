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

    private void Start()
    {

        health = 2 * numHearts;
        spawn = FindObjectOfType<EnemySpawnScript>();
    }

    private void Update()
    {
        if(health <= 0)
        {
            //audio.Play("inimigoMorre");
            var randomNumber = Random.Range(1, 101);
            var pos = this.transform.position;

            if(randomNumber <= 5)
            {
                drops[2].transform.position = pos;
                Instantiate(drops[2]);
            }else if(randomNumber <= 20)
            {
                drops[1].transform.position = pos;
                Instantiate(drops[1]);
            }else if(randomNumber <= 50)
            {
                drops[0].transform.position = pos;
                Instantiate(drops[0]);
            }

            Destroy(gameObject);
            spawn.CallNewOne();
        }
    }

    public void TakeDamage(int damage)
    {
            health -= damage;  
    }
}