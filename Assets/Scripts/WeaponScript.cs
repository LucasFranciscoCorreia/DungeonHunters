using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool rightTurned;

    void Start()
    {
        rightTurned = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hori = 0;
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            
            if (Input.GetKey(KeyCode.A))
            {
                hori = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                hori = 1;
            }
            if (hori > 0 && !rightTurned)
            {
                sr.flipX = false;
                rightTurned = true;
            }
            else if (hori < 0 && rightTurned)
            {
                sr.flipX = true;
                rightTurned = false;
            }
        }
    }
}
