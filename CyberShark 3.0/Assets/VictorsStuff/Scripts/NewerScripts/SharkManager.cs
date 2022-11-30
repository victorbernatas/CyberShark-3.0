using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkManager : MonoBehaviour
{

    private Rigidbody playerRigidBody;
    private SharkMovement sharkMovement;


    


    [SerializeField] float impulseMagnitude;
    [SerializeField] float forceMagnitude;
    [SerializeField] float rotationSpeed;


  
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
