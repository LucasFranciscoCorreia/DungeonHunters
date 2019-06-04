using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero_script : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private bool rightTurned;
    private Health health;
    private float timeAttack;
    private SpriteRenderer weapon;

    public int keys1_collected;
    public int keys2_collected;


    public GameObject closedDoor, openedDoor;
    public Animator weaponAnimator;
    public float speed;
    public float startTimeAttack;
    public Transform attackPos;
    public float attackRangeX, attackRangeY;
    public LayerMask enemieLayer;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        rightTurned = true;
        health = GetComponent<Health>();
        health.numHearts = 3;
        startTimeAttack = 0.3f;
        keys1_collected=0;
        keys2_collected=0;
        damage = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
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
                Vector3 scale = transform.localScale;
                if (hori > 0 && !rightTurned)
                {
                    rightTurned = true;
                    scale.x = 1;
                    transform.localScale = scale;
                    //weapon.flipX = false;
                }
                else if (hori < 0 && rightTurned)
                {
                    
                    rightTurned = false;
                    scale.x = -1;
                    transform.localScale = scale;
//a                    weapon.flipX = true;
                }
            }
            if(timeAttack <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    timeAttack = startTimeAttack;
                    isAbleAttack = false;
                    Collider2D[] enemies = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY),0, enemieLayer);
                    for(int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                    }
                    weaponAnimator.SetBool("isAttacking", true);
                }
                else
                {
                    weaponAnimator.SetBool("isAttacking", false);
                }
            }
            else
            {
                timeAttack -= Time.deltaTime;
                weaponAnimator.SetBool("isAttacking", false);
            }

            if (keys1_collected >= 2 && keys2_collected >= 2)
            {
                closedDoor.SetActive(true);
                openedDoor.SetActive(true);
            }
            animator.SetBool("isWalking", isWalking);
            body.velocity = new Vector2(0, 0);
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
        else if(collision.CompareTag("obj2"))
        {
            Destroy(collision.gameObject);
            keys2_collected++;
        }
        else if(collision.CompareTag("obj1"))
        {
            Destroy(collision.gameObject);
            keys1_collected++;
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position,new Vector3(attackRangeX, attackRangeY,1));
    }
}