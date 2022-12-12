using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHazard : MonoBehaviour
{
    public float multiplier = 0f;

   /* void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            Stun(other);
        }
    }

    /void Stun(Collider player)
    {
        PlayerControls stats = player.GetComponent<PlayerControls>();
        stats.impulseMagnitude *= multiplier;
        stats.forceMagnitude *= multiplier;
        stats.maxVelocity *= multiplier;
    } */
}
