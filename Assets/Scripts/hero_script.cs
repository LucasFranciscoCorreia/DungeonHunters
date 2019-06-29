using UnityEngine;

public class hero_script : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private bool rightTurned;
    private Health health;
    private float timeAttack;
    private SpriteRenderer weapon;
    
    public FaseScript fase;

    public Animator weaponAnimator;
    private float speed;
    public float speedWalk;
    public float speedRun;
    public float startTimeAttack;
    public Transform attackPos;
    public float attackRangeX, attackRangeY;
    public LayerMask enemieLayer;
    public int damage;

    public float maxStamina;
    //public float attackCostStamina;
    public float runCostStamina;
    private float currentStamina;

    public UIController UI;

    // Start is called before the first frame update
    void Start()
    {
        //speed = 2.5f;
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        rightTurned = true;
        health = GetComponent<Health>();
        health.numHearts = 3;
        startTimeAttack = 0.5f;
        damage = 1;
        currentStamina = maxStamina;
    }

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //UI.SetStamina(maxStamina, currentStamina);
        if (!PauseMenu.isPaused)
        {
            var isWalking = false;
            var isAbleAttack = true;
            var isRunning = false;
            var value = 1f;
            float hori = 0, vert = 0;
            if (Input.GetKey(KeyCode.RightShift) && currentStamina > 0)
            {
                isRunning = true;
                speed = speedRun;
                value = 1.5f;
                currentStamina -= runCostStamina;
            }
            if (currentStamina < 0)
            {
                currentStamina = 0;
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {
                if (!isRunning)
                {
                    isWalking = true;
                    isRunning = false;
                    speed = speedWalk;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    hori = -value;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    hori = value;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    vert = value;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    vert = -value;
                }
                var move = new Vector3(hori, vert, 0);
                body.MovePosition(new Vector2((transform.position.x + move.x * speed * Time.deltaTime), (transform.position.y + move.y * speed * Time.deltaTime)));
                Vector3 scale = transform.localScale;
                if (hori > 0 && !rightTurned)
                {
                    rightTurned = true;
                    scale.x = 1;
                    transform.localScale = scale;
                }
                else if (hori < 0 && rightTurned)
                {
                    
                    rightTurned = false;
                    scale.x = -1;
                    transform.localScale = scale;
                }
            }
            if(timeAttack <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    timeAttack = startTimeAttack;
                    isAbleAttack = false;
                    FindObjectOfType<AudioManager>().Play("porrada");
                    Collider2D[] enemies = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY),0, enemieLayer);
                    for(int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                    }
                }
                else
                {
                   
                    isAbleAttack = true;
                }
            }
            else
            {
                timeAttack -= Time.deltaTime;
                isAbleAttack = false;
            }

            animator.SetBool("isWalking", isWalking);
            animator.SetBool("isAbleAttack", isAbleAttack);
            animator.SetBool("isRunning", isRunning);
            body.velocity = new Vector2(0, 0);
            animator.SetBool("isAttacking", !isAbleAttack);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "HealthUp":
                if (health.health < health.numHearts*2 || health.numHearts<10)
                {
                    Destroy(collision.gameObject);
                    health.HealthPickUp();
                }
                break;
            case "SmallPotion":
                if (health.health < health.numHearts*2)
                {
                    Destroy(collision.gameObject);
                    health.SmallPotionPickUp();
                }
                break;
            case "BigPotion":
                if (health.health < health.numHearts*2)
                {
                    Destroy(collision.gameObject);
                    health.BigPotionPickUp();
                }
                break;
            case "obj1":
                Destroy(collision.gameObject);
                this.fase.GotKey1();
                break;
            case "obj2":
                Destroy(collision.gameObject);
                this.fase.GotKey2();
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position,new Vector3(attackRangeX, attackRangeY,1));
    }
}