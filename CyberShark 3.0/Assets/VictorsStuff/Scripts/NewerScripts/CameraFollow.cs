using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(46,21,0);
    [SerializeField] float distanceDamp;

    Transform myT;

    public Vector3 velocity = Vector3.one;


    private void Awake()
    {
        myT = transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SmoothFollow();
    }


    private void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        myT.position = curPos;
    }
}
