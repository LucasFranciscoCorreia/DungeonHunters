using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int numHearts;
    public int health;
    public float time;
    public float damageTime;

    private LevelChangerScript lcs;

    private void Start()
    {
        health = 2 * numHearts;
        damageTime = 1;
        lcs = FindObjectOfType<LevelChangerScript>();
    }

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamage(int damage)
    {
        if (time <= 0)
        {
            if (health - damage > 0)
                health -= damage;
            else
                health = 0;

            time = damageTime;
        }
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
