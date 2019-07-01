using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWeaponScript : MonoBehaviour
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
        owner.GetComponent<hero_script>().DealDamage();
    }
}
