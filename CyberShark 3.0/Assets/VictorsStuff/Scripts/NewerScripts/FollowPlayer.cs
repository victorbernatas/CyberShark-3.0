using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public float speed = 4f;
    private Rigidbody rb;


    [SerializeField] private float rotationSpeed;

    private Quaternion lookRotation;
    private Vector3 direction;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.Find("SharkHead").GetComponent<Transform>();

        
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


    }

}
