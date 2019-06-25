using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour
{

    public float speed;
    public float time2Walk;
    private float velocity;
    private Transform target;
    private Rigidbody2D body;
    private Vector2 dir;
    private float angle;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.dir = (target.position - this.transform.position).normalized;
        this.angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(dir*speed);
    }

    public void DestroySpell()
    {
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                this.speed = 0;
                this.body.velocity = new Vector2(0,0);
                GetComponent<Animator>().SetTrigger("Hit");
                break;
            case "Player":
                this.speed = 0;
                this.body.velocity = new Vector2(0, 0);
                GetComponent<Animator>().SetTrigger("Hit");
                collision.GetComponent<Health>().TakeDamage(damage);
                break;
        }
    }

    public void Walk()
    {
        this.speed = 2;
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
