using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int numHearts;
    public int health;

    private void Start()
    {
        health = 2 * numHearts;
    }

    private void Update()
    {
        if(health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("inimigoMorreu");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
            health -= damage;  
    }
}