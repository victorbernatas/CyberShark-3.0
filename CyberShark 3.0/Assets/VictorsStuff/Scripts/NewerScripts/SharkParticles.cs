using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem gokuVibe;



    private void OnEnable()
    {
        gokuVibe.Play(); 
    }

   
 
}
