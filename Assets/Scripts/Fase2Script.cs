using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase2Script : MonoBehaviour
{

    public GameObject closedDoor, openedDoor;
    public BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
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
