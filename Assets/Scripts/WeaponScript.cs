using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var res = false;
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
            res = true;
            this.enabled = true;
        }
        if(res == false)
        {
            this.enabled = false;
        }
        animator.SetBool("isAttacking", res);
    }
}
