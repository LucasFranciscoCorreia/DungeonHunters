using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }
}
