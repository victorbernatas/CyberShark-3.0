using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkDetectionDot : MonoBehaviour
{
    [SerializeField] private Vector3 dirToTarget;
    [SerializeField] GameObject playerMesh;
    [SerializeField] private float dot;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        dirToTarget = Vector3.Normalize(playerMesh.transform.position - transform.position);
        dot = Vector3.Dot(Vector3.forward, dirToTarget);
        
           Debug.Log(dot);
     

        
           
        
        
        
    }
}
