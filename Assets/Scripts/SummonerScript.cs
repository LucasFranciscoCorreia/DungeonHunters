using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerScript : MonoBehaviour
{
    public GameObject summon;
    public GameObject[] summoned;
    public int length;
    void Start()
    {
        summoned = new GameObject[length];
        for(int i = 0; i < length; i++)
        {
            var x = Random.Range(-3, 3);
            var y = Random.Range(-3, 3);
            summoned[i] = Instantiate(summon, transform.position, transform.rotation);
            summoned[i].transform.position = new Vector3(transform.position.x + x, transform.position.y, 0);
            summoned[i].AddComponent<SummonScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
