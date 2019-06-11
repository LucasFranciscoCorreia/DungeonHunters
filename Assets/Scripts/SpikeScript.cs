using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D box;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        Debug.Log("Started");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("here we go");
    }
}
