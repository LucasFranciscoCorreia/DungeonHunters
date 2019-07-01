using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase2Script : FaseScript
{

    public GameObject miniboss;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(39, -4.5f, 0);
        var fase = player.GetComponent<hero_script>().fase;

        this.key1 = fase.key1;
        this.key2 = fase.key2;
        this.showDoor = fase.showDoor;

        this.key1.text = "0/2";
        this.key2.text = "0/2";

        this.keys1 = 0;
        this.keys2 = 0;

        this.quest1Scratch = fase.quest1Scratch;
        this.quest1_1Scratch = fase.quest1_1Scratch;
        this.quest1_2Scratch = fase.quest1_2Scratch;
        this.quest2Scratch = fase.quest2Scratch;

        this.quest1Scratch.SetActive(false);
        this.quest1_1Scratch.SetActive(false);
        this.quest1_2Scratch.SetActive(false);

        this.quest2 = fase.quest2;
        this.quest2.text = "Defeat the Necromancer";

        this.showDoor = fase.showDoor;
        player.GetComponent<hero_script>().fase = this;
        GameObject camera = GameObject.FindGameObjectWithTag("CinemachineConfiner");
        camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = player.transform;
        lcs = FindObjectOfType<LevelChangerScript>();
        base.Start();
    }

    public void Update()
    {
        if(miniboss == null)
        {
            quest2Scratch.SetActive(true);
        }
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
