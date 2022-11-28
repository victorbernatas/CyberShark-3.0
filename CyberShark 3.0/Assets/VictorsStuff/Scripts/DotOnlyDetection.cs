using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotOnlyDetection : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 dirToTarget;

    [SerializeField] private float dot1;
    [SerializeField] private float dot2;
    [SerializeField] private float dot3;
    [SerializeField] private float dot4;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 north = new Vector3(0, 0, 1);
        Vector3 east = new Vector3(1, 0, 0);
        Vector3 northEast = new Vector3(1, 0, 1);

        dirToTarget = Vector3.Normalize(playerPos.transform.position - transform.position);
        dot1 = Vector3.Dot(Vector3.forward, dirToTarget);
        dot2 = Vector3.Dot(Vector3.right, dirToTarget);

    }
}
