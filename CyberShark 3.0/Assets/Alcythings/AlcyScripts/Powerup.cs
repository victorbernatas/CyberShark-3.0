using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public float multiplier = 1.4f;


   /* private void OnDisable()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //i'm aware this is to collide with enemies but we just gotta think how to change it
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //speed effect
        PlayerControls stats = player.GetComponent<PlayerControls>();
        stats.impulseMagnitude *= multiplier;
        stats.forceMagnitude *= multiplier;
        stats.maxVelocity *= multiplier;

        Destroy(gameObject);
    }*/
}
