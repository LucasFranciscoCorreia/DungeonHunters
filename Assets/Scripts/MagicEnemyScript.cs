using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEnemyScript : MonoBehaviour
{

    private Rigidbody2D body;
    private EnemyHealth health;
    private Pathfinding.AIDestinationSetter pathfind;
    private bool rightTurned;
    private Animator animator;
    private GameObject target;

    public GameObject spell;
    public GameObject currentSpell;
    public LayerMask playerLayer;
    public float timeAttack;
    public float startTimeAttack;
    public Transform attackPos;
    public bool isAbleAttack = true;
    public float maxDistance;
    public float minDistance;

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
        var isWalking = false;
    
        if (distance < maxDistance && distance > minDistance)
        {
            pathfind.target = target.GetComponent<Transform>();
            isWalking = true;
        }
        else
        {
            pathfind.target = null;
        }

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

        if (timeAttack <= 0)
        {
            if (distance <= minDistance && this.currentSpell == null)
            {
                timeAttack = startTimeAttack;
                this.currentSpell = Instantiate(spell, attackPos.position, attackPos.rotation);
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


        body.velocity = new Vector2(0, 0);
    }
}
