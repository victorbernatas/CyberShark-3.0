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

    private Vector2 smoothInputVelocity;
    private Vector2 currentInput;
    [SerializeField] float smoothInputSpeed = 0.2f;

    [SerializeField] float lerpFloat;

    [SerializeField] float maxVelocity;


    [SerializeField] bool hasPowerUp;


   
    

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

        Swimming();
       

    }

    private void Update()
    {
        //KeepPlayerOnScreen();

       
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        //slerp
        if (playerRigidBody != null)
        {

            Vector2 inputVector = sharkMovement.Shark.Movement.ReadValue<Vector2>().normalized;

            currentInput = Vector3.Slerp(Vector2.zero, inputVector, Time.deltaTime).normalized;

            playerRigidBody.AddForce(new Vector3(currentInput.x, 0, currentInput.y) * forceMagnitude, ForceMode.Acceleration);

            playerRigidBody.velocity = Vector3.ClampMagnitude(playerRigidBody.velocity, maxVelocity);


            //Lerp
            /*Vector2 inputVector = sharkMovement.Shark.Movement.ReadValue<Vector2>().normalized;

            currentInput = Vector2.Lerp(Vector2.zero, inputVector, lerpFloat).normalized;

            playerRigidBody.AddForce(new Vector3(currentInput.x, 0, currentInput.y) * forceMagnitude * Time.deltaTime, ForceMode.Force);  */



            //smooth damp
            /* Vector2 inputVector = sharkMovement.Shark.Movement.ReadValue<Vector2>().normalized;
             Debug.Log(inputVector);

            currentInput = Vector2.SmoothDamp(currentInput, inputVector, ref smoothInputVelocity, smoothInputSpeed);

            playerRigidBody.AddForce(new Vector3(currentInput.x, 0, currentInput.y) * forceMagnitude * Time.deltaTime, ForceMode.Force);   */


        }







    }

    private void Swimming()
    {
        if (playerRigidBody != null)
        {
            //slerp
            Vector2 inputVector = sharkMovement.Shark.Movement.ReadValue<Vector2>().normalized;

            currentInput = Vector3.Slerp(Vector2.zero, inputVector, Time.deltaTime).normalized;

            playerRigidBody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * forceMagnitude, ForceMode.Acceleration);
            playerRigidBody.velocity = Vector3.ClampMagnitude(playerRigidBody.velocity, maxVelocity);

            //Debug.Log(playerRigidBody.velocity);

            //lerp
            /*
            Vector2 inputVector = sharkMovement.Shark.Movement.ReadValue<Vector2>().normalized;

            currentInput = Vector2.Lerp(Vector2.zero, inputVector, lerpFloat).normalized;

            playerRigidBody.AddForce(new Vector3(currentInput.x, 0, currentInput.y) * forceMagnitude * Time.deltaTime, ForceMode.Force);

            Debug.Log(inputVector);*/

            //smoothdamp
            /*Vector2 inputVector = sharkMovement.Shark.Movement.ReadValue<Vector2>().normalized;

            currentInput = Vector2.SmoothDamp(currentInput, inputVector, ref smoothInputVelocity, smoothInputSpeed).normalized;

            playerRigidBody.AddForce(new Vector3(currentInput.x, 0, currentInput.y) * forceMagnitude * Time.deltaTime, ForceMode.Force);

            Debug.Log(inputVector);*/

        }
    }

    private void OnDisable()
    {
        sharkMovement.Shark.Disable();
        sharkMovement.Shark.Movement.performed -= Movement_performed;
    }




    /*private void KeepPlayerOnScreen()


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
    }*/


}
