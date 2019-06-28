using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase3Script : FaseScript
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(75f, 20f, 0f);
        player.GetComponent<hero_script>().fase = this;
        GameObject camera = GameObject.FindGameObjectWithTag("CinemachineConfiner");
        camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = player.transform;
        lcs = FindObjectOfType<LevelChangerScript>();
        base.Start();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                //lcs.FadeToLevel("Fase4");
                Debug.Log("Fase 4");
                break;
        }
    }
}
