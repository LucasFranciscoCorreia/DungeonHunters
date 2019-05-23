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
    public GameObject PauseMenu;
    public bool isPaused;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        rightTurned = true;
        sr = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        var isWalking = false;
        float hori;
        if ((hori = Input.GetAxis("Horizontal")) != 0 || Input.GetAxis("Vertical") != 0)
        {
            isWalking = true;
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            //transform.position += move * speed * Time.deltaTime;
            body.MovePosition(new Vector2((transform.position.x + move.x * speed * Time.deltaTime), (transform.position.y + move.y * speed * Time.deltaTime)));
            if(hori > 0 && !rightTurned) {
                sr.flipX = false;
                rightTurned = true;
            }else if(hori < 0 && rightTurned) {
                sr.flipX = true;
                rightTurned = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
            health.TakeDamage(1);
        if (Input.GetKeyDown(KeyCode.Q))
            health.HealthPickUp();
        if (health.health == 0)
                SceneManager.LoadScene("GameOver");

        animator.SetBool("isWalking", isWalking);
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