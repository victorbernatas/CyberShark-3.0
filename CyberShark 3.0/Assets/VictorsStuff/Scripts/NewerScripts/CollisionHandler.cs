using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private GameObject avoid;
    private SharkManager sharkManager;

    
 
    void Start()
    {
        sharkManager = GameObject.Find("Shark").GetComponent<SharkManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            sharkManager.CollisionHandler();
            Destroy(gameObject);
        }
        
    }
}
