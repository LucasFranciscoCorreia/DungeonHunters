using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 1.5)
        {
            body.MovePosition(Vector2.MoveTowards(body.position, target.position, speed * Time.deltaTime));
        }
        //transform.position = Vector2.MoveTowards(body.position, target.position, speed * Time.deltaTime);
    }
}
