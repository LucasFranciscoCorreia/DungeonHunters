using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public Transform[] spots;
    public float patrolTime;
    public float startPatrolTime;
    public EnemyScript script;

    public int spot;
    void Start()
    {
        script = GetComponent<EnemyScript>();
        spot = Random.Range(0, spots.Length);
        this.transform.position = spots[spot].position;
        patrolTime = startPatrolTime;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(this.transform.position, script.target.transform.position);
        if(distance > script.maxDistance)
        {
            distance = Vector3.Distance(transform.position, spots[spot].transform.position);
            if (distance > 2)
            {
                script.pathfind.target = spots[spot];
                script.Flip(spots[spot]);
            }
            else
            {
                if(patrolTime > 0)
                {
                    patrolTime -= Time.deltaTime;
                }
                else
                {
                    int i = spot;
                    do
                    {
                        i = Random.Range(0, spots.Length);
                    } while (i == spot);
                    spot = i;
                    Debug.Log(i);
                    patrolTime = startPatrolTime;
                }
            }
        }
    }
}
