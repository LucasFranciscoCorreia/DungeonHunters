using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonScript : MonoBehaviour
{

    public Transform pos;
    private Animator anim;
    private EnemyHealth health;
    public SummonerScript summoner;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform;
        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        var target = GetComponent<EnemyScript>().target;
        var rightTurned = GetComponent<EnemyScript>().rightTurned;
        var pathfind = GetComponent<EnemyScript>().pathfind;
        if(target == null)
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
            pathfind.target = pos;
            anim.SetBool("isWalking",true);
        }
        switch (health.health)
        {
            case 1:
                health.isRespawnable = false;
                break;
        }
    }
}
