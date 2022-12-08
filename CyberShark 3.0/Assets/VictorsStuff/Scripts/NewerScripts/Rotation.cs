using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity != Vector3.zero)
        {
            RotateToFaceVelocity();
        }

        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }


    private void RotateToFaceVelocity()
    {
        // these lines are for lerping

        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.back);

        targetRotation.x = 0;
        targetRotation.z = 0;


        // used to multiply by delta.deltaTime instead of 0.1f but it gave me errors if the quaternion equaled 0 (very rarely, but still) don't forget to look into it
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * 0.1f);




    }
}
