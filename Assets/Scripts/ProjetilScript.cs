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
    // Start is called before the first frame update
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.target = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
        this.dir = (target.position - this.transform.position).normalized;
        this.angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.time2Walk = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(time2Walk > 0)
        {
            time2Walk -= Time.deltaTime;
        }
        else
        {
            body.velocity = dir * speed;
        }
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
                GetComponent<Animator>().SetTrigger("Hit");
                break;
            case "Player":
                this.speed = 0;
                GetComponent<Animator>().SetTrigger("Hit");
                collision.GetComponent<Health>().TakeDamage(1);
                break;
        }
    }
}
