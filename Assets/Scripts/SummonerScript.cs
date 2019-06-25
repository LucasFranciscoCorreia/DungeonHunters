using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerScript : MonoBehaviour
{
    public GameObject summon;
    public GameObject[] summoned;
    public bool[] avaliable;
    public int length;
    public EnemyHealth health;
    private int tam;
    public float time2Spawn;
    public float startTime2Spawn;
    public MagicEnemyScript script;

    public Transform spot;
    void Start()
    {
        summoned = new GameObject[length];
        avaliable = new bool[length];
        for(int i = 0; i < length; i++)
        {
            var x = Random.Range(-3, 3);
            var y = Random.Range(-3, 3);
            summoned[i] = Instantiate(summon, transform.position, transform.rotation);
            summoned[i].transform.position = new Vector3(transform.position.x + x, transform.position.y+y, 0);
            summoned[i].AddComponent<SummonScript>();
            summoned[i].GetComponent<SummonScript>().summoner = this;
            summoned[i].GetComponent<SummonScript>().index = i;
            avaliable[i] = false;
        }
        health = GetComponent<EnemyHealth>();
        script = GetComponent<MagicEnemyScript>();
        tam = length;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(this.transform.position,script.target.GetComponent<Transform>().position);
        switch (health.health)
        {
            case 1:
                health.isRespawnable = false;
                health.isSummoner = true;
                break;
            default:
                break;
        }

        if (distance > 10 && this.transform.position.x != spot.position.x && spot.position.y != transform.position.y)
        {
            this.transform.position = spot.position;
            foreach (GameObject summon in summoned)
            {
                if (summon != null)
                {
                    var x = Random.Range(-3, 3);
                    var y = Random.Range(-3, 3);
                    summon.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, 0);
                }
            }
        }

        if(length < tam)
        {
            if (time2Spawn <= 0)
            {
                for (int i = 0; i < tam; i++)
                {
                    if (avaliable[i])
                    {
                        var x = Random.Range(-3, 3);
                        var y = Random.Range(-3, 3);
                        summoned[i] = Instantiate(summon, transform.position, transform.rotation);
                        summoned[i].transform.position = new Vector3(transform.position.x + x, transform.position.y, 0);
                        summoned[i].AddComponent<SummonScript>();
                        summoned[i].GetComponent<SummonScript>().summoner = this;
                        avaliable[i] = false;
                        time2Spawn = startTime2Spawn;
                        break;
                    }
                }
            }
            else
            {
                time2Spawn -= Time.deltaTime;
            }
        }
    }

    public void FreeSpace(int index)
    {
        length--;
        avaliable[index] = true;
    }
}
