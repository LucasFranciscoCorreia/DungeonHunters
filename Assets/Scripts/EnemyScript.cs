using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    private Rigidbody2D body;
    private EnemyHealth health;
    private Pathfinding.AIDestinationSetter pathfind;
    private bool rightTurned;
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

    // Start is called before the first frame update
    void Start()
    {
    
        target = GameObject.FindGameObjectWithTag("Player");
        body = this.GetComponent<Rigidbody2D>();
        this.health = GetComponent<EnemyHealth>();
        pathfind = GetComponent<Pathfinding.AIDestinationSetter>();
        health.numHearts = 2;
        var x = transform.position.x;
        var targetx = target.GetComponent<Transform>().position.x;
        Vector3 scale = transform.localScale;

        if (x - targetx > 0 && !rightTurned)
        {
            rightTurned = true;
            scale.x = -1;
            transform.localScale = scale;
        }
        else if (x - targetx < 0 && rightTurned)
        {
            rightTurned = false;
            scale.x = 1;
            transform.localScale = scale;
        }
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.GetComponent<Transform>().position);
        var isWalking = false;
        //var isAbleAttack = true;
        if(distance < maxDistance && distance > 1.5)
        {
            var x = transform.position.x;
            var targetx = target.GetComponent<Transform>().position.x;
            Vector3 scale = transform.localScale;
            if (x - targetx > 0 && !rightTurned)
            {
                rightTurned = true;
                scale.x = -1;
                transform.localScale = scale;
            }
            else if(x-targetx < 0 && rightTurned)
            {
                rightTurned = false;
                scale.x = 1;
                transform.localScale = scale;
            }
            pathfind.target = target.GetComponent<Transform>();
            isWalking = true;
        }
        else
        {
            pathfind.target = null;
        }

        if (timeAttack <= 0)
        {
            if (distance < 1.5 && isAbleAttack)
            {
                timeAttack = startTimeAttack;
                Collider2D[] player = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, playerLayer);
                player[0].GetComponent<Health>().TakeDamage(1);
                isAbleAttack = false;
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
