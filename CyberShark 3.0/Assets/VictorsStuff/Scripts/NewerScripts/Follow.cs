using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform follow;

    [SerializeField] GameObject avoid1;
    [SerializeField] GameObject avoid2;

    [SerializeField] float maxDistance;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), avoid1.GetComponent<Collider>());
        Physics.IgnoreCollision(GetComponent<Collider>(), avoid2.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        // Change this object position only if the distance is greater than maxDistance
        float actualDistance = Vector3.Distance(transform.position, follow.position);
        if(actualDistance > maxDistance)
        {
            var followToCurrent = (transform.position - follow.position).normalized;
            followToCurrent.Scale(new Vector3(maxDistance, maxDistance, maxDistance));

            //set the new position
            transform.position = follow.position + followToCurrent;

            //Determine Which direction to rotate
            Vector3 targetDirection = follow.position - transform.position;
            // the step size is equal to speed * frame rate
            float singleStep = speed * Time.deltaTime;
            //rotate the forward Vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            
        }
    }
}
