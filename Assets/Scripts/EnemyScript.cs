using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Rigidbody2D body;
    public EnemyHealth health;
    public Pathfinding.AIDestinationSetter pathfind;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        body = this.GetComponent<Rigidbody2D>();
        this.health = GetComponent<EnemyHealth>();
        pathfind = GetComponent<Pathfinding.AIDestinationSetter>();
        health.numHearts = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) < 10 && Vector3.Distance(transform.position, target.position) > 1.5)
        {
         //   pathfind.target = target;
        }
        else 
        {
           // pathfind.target = null;
        }
    }

}
