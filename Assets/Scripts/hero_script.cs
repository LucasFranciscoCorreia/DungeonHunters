using UnityEngine;
using UnityEngine.UI;
public class hero_script : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private bool rightTurned;
    private Health health;
    private float timeAttack;
    private SpriteRenderer weapon;

    public static hero_script instance;

    public FaseScript fase;

    public Animator weaponAnimator;
    private float speed;
    public float startTimeAttack;
    public Transform attackPos;
    public float attackRangeX, attackRangeY;
    public LayerMask enemieLayer;
    public int damage;

    public float maxStamina;
    public float runCostStamina;
    public float currentStamina;
    
    public UIController UI;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        speed = 2.5f;
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
        if (!PauseMenu.isPaused)
        {
            UI.SetStamina(maxStamina, currentStamina);
            var isWalking = false;
            var isAbleAttack = true;
            float hori = 0, vert = 0;
            var value = 1f;

            if (!Input.GetKey(KeyCode.LeftShift) && currentStamina < maxStamina)
            {
                currentStamina += Time.deltaTime;
            }
            if (currentStamina < 0)
            {
                currentStamina = 0;
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {

                isWalking = true;
                if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
                {
                    value = 1.5f;
                    currentStamina -= 2 * Time.deltaTime;
                }

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
                body.MovePosition(new Vector2((transform.position.x + hori * speed * value * Time.deltaTime), (transform.position.y + vert * speed * value * Time.deltaTime)));
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
            if (timeAttack <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isAbleAttack = false;
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
            weaponAnimator.SetBool("isAttacking", !isAbleAttack);
            body.velocity = new Vector2(0, 0);
        }
    }

    public void DealDamage()
    {
        timeAttack = startTimeAttack;
        FindObjectOfType<AudioManager>().Play("porrada");
        Collider2D[] enemies = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemieLayer);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);
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

    public static void AddXp(float xp)
    {
        float newXp = GetCurrentXp() + xp;
        PlayerPrefs.SetFloat("currentXp", newXp); 
    }

    public static float GetCurrentXp()
    {
        return PlayerPrefs.GetFloat("currentXp");
    }
}