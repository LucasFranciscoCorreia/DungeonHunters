
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    private Rigidbody2D body;
    private EnemyHealth health;
    public Pathfinding.AIDestinationSetter pathfind;
    public bool rightTurned;
    private Animator animator;

    public Animator weaponAnimator;
    public GameObject target;
    public LayerMask playerLayer;
    public float timeAttack;
    public float startTimeAttack;
    public Transform attackPos;
    public float attackRangeX, attackRangeY;
    public bool isAbleAttack = true;
    public float maxDistance;
    public float minDistance;
    public int damage;

    public bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        
        this.target = GameObject.FindGameObjectWithTag("Player");
        this.body = this.GetComponent<Rigidbody2D>();
        this.health = GetComponent<EnemyHealth>();
        this.pathfind = GetComponent<Pathfinding.AIDestinationSetter>();
        var x = transform.position.x;
        var targetx = target.GetComponent<Transform>().position.x;
        Vector3 scale = transform.localScale;

        if (x - targetx > 0 && !rightTurned)
        {
            rightTurned = true;
            scale.x = -scale.x;
            transform.localScale = scale;
        }
        else if (x - targetx < 0 && rightTurned)
        {
            rightTurned = false;
            scale.x = -scale.x;
            transform.localScale = scale;
        }
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.GetComponent<Transform>().position);
        //var isAbleAttack = true;
        isWalking = false;
        if(distance < maxDistance)
        {
            Flip(target.transform);
        }

        if (timeAttack <= 0)
        {
            if (distance < minDistance && isAbleAttack)
            {
                timeAttack = startTimeAttack;
                weaponAnimator.SetBool("isAttacking", true);
            }
            else
            {
                isAbleAttack = true;
                weaponAnimator.SetBool("isAttacking", false);
            }
        }
        else
        { 
            timeAttack -= Time.deltaTime;
            isAbleAttack = false;
            weaponAnimator.SetBool("isAttacking", false);
        }
        animator.SetBool("isWalking", isWalking);
        body.velocity = new Vector2(0,0);
    }

    public void Flip(Transform target)
    {
        var x = transform.position.x;
        var targetx = target.GetComponent<Transform>().position.x;
        Vector3 scale = transform.localScale;
        if (x - targetx > 0 && !rightTurned)
        {
            rightTurned = true;
            scale.x = -scale.x;
            transform.localScale = scale;
        }
        else if (x - targetx < 0 && rightTurned)
        {
            rightTurned = false;
            scale.x = -scale.x;
            transform.localScale = scale;
        }
        pathfind.target = target.GetComponent<Transform>();
        isWalking = true;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }

    public void DealDamage()
    {
        Collider2D[] player = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, playerLayer);
        foreach (Collider2D collider in player)
        {
            collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        isAbleAttack = false;
    }
}
