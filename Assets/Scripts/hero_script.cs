using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero_script : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer sr;
    public bool rightTurned;
    public Health health;
    public bool isPaused;
    public float timeAttack;
    public float startTimeAttack;
    public SpriteRenderer weapon;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        rightTurned = true;
        sr = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        health.numHearts = 3;
        isPaused = false;
        startTimeAttack = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            var isWalking = false;
            var isAbleAttack = true;
            float hori = 0, vert = 0;
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {
                isWalking = true;
                if (Input.GetKey(KeyCode.A))
                {
                    hori = -1;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    hori = 1;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    vert = 1;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    vert = -1;
                }
                var move = new Vector3(hori, vert, 0);
                body.MovePosition(new Vector2((transform.position.x + move.x * speed * Time.deltaTime), (transform.position.y + move.y * speed * Time.deltaTime)));
                if (hori > 0 && !rightTurned)
                {
                    sr.flipX = false;
                    weapon.flipX = false;
                    rightTurned = true;
                }
                else if (hori < 0 && rightTurned)
                {
                    sr.flipX = true;
                    weapon.flipX = true;
                    rightTurned = false;
                }
            }
            if(timeAttack <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    timeAttack = startTimeAttack;
                    isAbleAttack = false;
                }
                else
                {
                    timeAttack = 0;
                    isAbleAttack = true;
                }
            }
            else
            {
                timeAttack -= Time.deltaTime;
                isAbleAttack = false;
            }

            if (health.health == 0)
                SceneManager.LoadScene("GameOver");

            animator.SetBool("isWalking", isWalking);
            animator.SetBool("isAbleAttack", isAbleAttack);
            animator.SetBool("isAttacking", !isAbleAttack);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthUp") && (health.numHearts < 10 || health.health < 20))
        {
            Destroy(collision.gameObject);
            health.HealthPickUp();
        }
        else if (collision.CompareTag("SmallPotion") && health.health < health.numHearts*2)
        {
            Destroy(collision.gameObject);
            health.SmallPotionPickUp();
        }
        else if (collision.CompareTag("BigPotion") && health.health < health.numHearts*2)
        {
            Destroy(collision.gameObject);
            health.BigPotionPickUp();
        }
    }
}