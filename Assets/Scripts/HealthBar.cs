using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Health heroHealth;

    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Sprite fullHeart;
    public int health;
    public int numHearts;
    // Start is called before the first frame update
    void Start() {
        heroHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update() {
        health = heroHealth.health;
        numHearts = heroHealth.numHearts;
        for(int i = 0; i < hearts.Length; i++) {
            if (i < health/2) {
                hearts[i].sprite = fullHeart;
            } else if (i < health/2+1 && health % 2 == 1) {
                hearts[(health / 2)].sprite = halfHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }
        }

        for (int i = 0; i < hearts.Length; i++) {
            if (i < numHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }


}
