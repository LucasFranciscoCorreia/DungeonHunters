using UnityEngine;

public class Fase1Script : FaseScript
{
    void Start()
    {
        lcs = FindObjectOfType<LevelChangerScript>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<hero_script>().fase = this;
        base.Start();
    }

        
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                lcs.FadeToLevel("Fase2");
                break;
        }
    }


}