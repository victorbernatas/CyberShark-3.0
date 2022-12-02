using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private SharkManager sharkManager;
 
    void Start()
    {
        sharkManager = GameObject.Find("Shark").GetComponent<SharkManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sharkManager.CollisionHandler();
        Destroy(gameObject);
    }
}