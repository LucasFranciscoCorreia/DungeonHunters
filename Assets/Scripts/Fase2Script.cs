using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase2Script : FaseScript
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(39, -4.5f, 0);
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
                lcs.FadeToLevel("Fase3");
                break;
        }
    }

}
