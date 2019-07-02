using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase4Script : FaseScript
{

    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(5f, -10f, 0f);
        var fase = player.GetComponent<hero_script>().fase;

        this.quest1Scratch = fase.quest1Scratch;
        this.quest1 = fase.quest1;
        this.quest1_1 = fase.quest1_1;
        this.quest1_2 = fase.quest1_2;
        this.quest2 = fase.quest2;
        this.quest3 = fase.quest3;
        this.quest3Scratch = fase.quest3Scratch;
        this.quest3.gameObject.SetActive(false);
        this.showDoor = fase.showDoor;

        this.quest1Scratch.SetActive(false);
        this.quest1_1.SetActive(false);
        this.quest1_2.SetActive(false);
        this.quest2.gameObject.SetActive(false);

        this.quest1.GetComponent<Text>().text = "Defeat the Demon";
  

        player.GetComponent<hero_script>().fase = this;
        GameObject camera = GameObject.FindGameObjectWithTag("CinemachineConfiner");
        camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = player.transform;

        lcs = FindObjectOfType<LevelChangerScript>();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(boss == null)
        {
            lcs.FadeToLevel("Credits");
        }
    }
}
