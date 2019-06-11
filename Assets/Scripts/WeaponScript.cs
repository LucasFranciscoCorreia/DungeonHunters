using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject owner;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage()
    {
        owner.GetComponent<EnemyScript>().DealDamage();
    }
}
