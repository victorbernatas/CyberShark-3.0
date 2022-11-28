using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigoDetection : MonoBehaviour
{
    [SerializeField] private Transform enemyTarget;
  

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = enemyTarget.transform.position - transform.position;
        var startAngle =  Mathf.Atan2(Pos.x, Pos.z);
        var radius = Vector3.Magnitude(Pos);

        Debug.Log(startAngle);

        

        
        
    }
}
