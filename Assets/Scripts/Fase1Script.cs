using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1Script : MonoBehaviour
{
    public int keys1;
    public int keys2;

    public GameObject closedDoor, openedDoor;
    
    void Start()
    {
        keys1 = 0;
        keys2 = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(keys1 >= 2 && keys2 >= 2)
        {
            closedDoor.SetActive(true);
            openedDoor.SetActive(true);
        }
    }

    public void GotKey1()
    {
        this.keys1++;
    }

    public void GotKey2()
    {
        this.keys2++;
    }
}
