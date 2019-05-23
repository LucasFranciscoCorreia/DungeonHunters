using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    public int numHearts;
    public int health;

    private void Start()
    {
        health = 2 * numHearts;
        //health = 1;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (health - damage > 0)
            health -= damage;
        else
            health = 0;
    }

    public void HealthPickUp()
    {
        if (numHearts < 10)
        {
            numHearts++;
            health += 2;
        }
        else
        {
            if (health + 2 < 20)
                health += 2;
            else
                health = 20;
        }
    }

    public void SmallPotionPickUp()
    {
        if(health+1 < numHearts*2)
        {
            health += 1;
        }
        else
        {
            health = numHearts*2;
        }
    }

    public void BigPotionPickUp()
    {
        if (health+2 < numHearts*2)
        {
            health += 2;
        }
        else
        {
            health = numHearts*2;
        }
    }
}
