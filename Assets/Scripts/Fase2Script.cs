using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase2Script : MonoBehaviour
{

    public int keys1;
    public int keys2;

    public GameObject closedDoor, openedDoor;
    public BoxCollider2D collider;

    public GameObject[] keys;
    public int i;

    public Transform[] spots;
    public List<int> positions;
    public Text key1;
    public Text key2;

    public LevelChangerScript lcs;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        keys1 = 0;
        keys2 = 0;
        while(positions.Count < 4)
        {
            int i = Random.Range(0, spots.Length);
            if(positions.Contains(i))
            {
                positions.Add(i);
            }
        }

        for(int i = 0; i < keys.Length; i++)
        {
            keys[i].transform.position = spots[positions[i]].position;
        }

        collider.enabled = false;

        lcs = FindObjectOfType<LevelChangerScript>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(39, -4.5f, 0);
        GameObject camera = GameObject.FindGameObjectWithTag("CinemachineConfiner");
        camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
