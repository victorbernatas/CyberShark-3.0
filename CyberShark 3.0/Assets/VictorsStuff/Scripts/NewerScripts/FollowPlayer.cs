using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float speed;
    private Rigidbody rb;


     private float rotationSpeed;

    private Quaternion lookRotation;
    private Vector3 direction;

    [SerializeField] bool isSlowed;

    private float slowedDownSpeed = 0.8f;
    [SerializeField]
    private float normalSpeed = 2f;

    [SerializeField]
    private float normalRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.Find("SharkHead").GetComponent<Transform>();
        speed = normalSpeed;
        rotationSpeed = normalRotationSpeed;
        
    }

  
   
    private void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        rb.MovePosition(pos);

        //transform.LookAt(player);


        //Vector3 forward = transform.TransformDirection(Vector3.forward);

        direction = (player.position - transform.position).normalized;

        lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        SlowDown();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            isSlowed = true;

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            isSlowed = false;
        }
    }

    private void SlowDown()
    {
        if (isSlowed == true)
        {
            Debug.Log(speed);
            speed = slowedDownSpeed;
            rotationSpeed = 0;
            
            
        }

        else
        {
            speed = normalSpeed;
            rotationSpeed = normalRotationSpeed;
        }


    }

}
