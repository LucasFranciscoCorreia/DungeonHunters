﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int numHearts;
    public int health;
    public GameObject[] drops;
    public EnemySpawnScript spawn;
    public bool isRespawnable;
    public bool isSummoner;
    public int baseXp;
    private void Start()
    {
        health = 2 * numHearts;
        spawn = FindObjectOfType<EnemySpawnScript>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("inimigoMorre");
            var randomNumber = Random.Range(1, 101);
            var pos = this.transform.position;
            if (isRespawnable)
            {
                if (randomNumber <= 3)
                {
                    drops[2].transform.position = pos;
                    Instantiate(drops[2]);
                }
                else if (randomNumber <= 20)
                {
                    drops[1].transform.position = pos;
                    Instantiate(drops[1]);
                }
                else if (randomNumber <= 60)
                {
                    drops[0].transform.position = pos;
                    Instantiate(drops[0]);
                }
                spawn.CallNewOne(this.gameObject);
            }
            else
            {
                if (!isSummoner && GetComponent<SummonScript>() != null)
                {
                    if (randomNumber < 10)
                    {
                        drops[0].transform.position = pos;
                        Instantiate(drops[0]);

                    }
                    GetComponent<SummonScript>().summoner.FreeSpace(GetComponent<SummonScript>().index);
                }
            }
            Destroy(gameObject);
            FindObjectOfType<FaseScript>().EnemieKilled();
            hero_script.AddXp(baseXp);
            int max = PlayerPrefs.GetInt("maxScore");
            if (hero_script.GetCurrentXp() > max)
            {
                PlayerPrefs.SetInt("maxScore", hero_script.GetCurrentXp());
            }
        }
    }

    public void TakeDamage(int damage)
    {
            health -= damage;  
    }
}