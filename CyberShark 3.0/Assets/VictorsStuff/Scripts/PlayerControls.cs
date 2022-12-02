using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    private Rigidbody playerRigidBody;
    private SharkMovement sharkMovement;
    private Camera mainCamera;




    [SerializeField] float impulseMagnitude;
    [SerializeField] float forceMagnitude;


   
    

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        sharkMovement = new SharkMovement();
        sharkMovement.Shark.Enable();
        sharkMovement.Shark.Movement.performed += Movement_performed;
    }
    void FixedUpdate()
    {
        Vector2 inputVector = sharkMovement.Shark.Movement.ReadValue<Vector2>();
        playerRigidBody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * forceMagnitude * Time.deltaTime, ForceMode.Force);

       
       

    }

    private void Update()
    {
        KeepPlayerOnScreen();
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        
        Vector2 inputVector = context.ReadValue<Vector2>();
        playerRigidBody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * impulseMagnitude * Time.deltaTime, ForceMode.Force);

        
    }




    private void KeepPlayerOnScreen()


    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x >= 0.98)
        {
            newPosition.x = newPosition.x - 0.05f;
        }

        if (viewportPosition.x <= 0.02)
        {
            newPosition.x = newPosition.x + 0.05f;
        }

        if (viewportPosition.y >= 0.98)
        {
            newPosition.z = newPosition.z - 0.05f;
        }

        if (viewportPosition.y <= 0.02)
        {
            newPosition.z = newPosition.z + 0.05f;
        }

        transform.position = newPosition;
    }


}
