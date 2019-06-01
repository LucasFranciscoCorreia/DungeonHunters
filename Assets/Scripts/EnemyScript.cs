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

    public GameObject target;

    public LayerMask playerLayer;
    public float timeAttack;
    public float startTimeAttack;

    public Transform attackPos;
    public float attackRangeX, attackRangeY;

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
        if(distance < 10 && distance > 1.5)
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
            if(distance < 1.5)
            {
                if(timeAttack <= 0)
                {
                    timeAttack = startTimeAttack;
                    Collider2D[] player = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, playerLayer);
                    player[0].GetComponent<Health>().TakeDamage(1);
                }  
                else
                {
                    timeAttack -= Time.deltaTime;
                }
            }
            pathfind.target = null;
        }
        animator.SetBool("isWalking", isWalking);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
