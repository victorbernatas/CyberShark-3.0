using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusOnDisable : MonoBehaviour
{
    [SerializeField] GameObject baby1;
    [SerializeField] Transform  tbaby1;
    [SerializeField] GameObject baby2;
    [SerializeField] Transform tbaby2;
    [SerializeField] GameObject baby3;
    [SerializeField] Transform tbaby3;


    [SerializeField] GameObject sharkRef;
    // Start is called before the first frame update
    void Start()
    {
        sharkRef = GameObject.FindGameObjectWithTag("SharkHead");
    }

   

    private void OnDestroy()
    {
        if (sharkRef != null)
        {
            Instantiate(baby1, tbaby1.position, Quaternion.identity);
            Instantiate(baby2, tbaby2.position, Quaternion.identity);
            Instantiate(baby3, tbaby3.position, Quaternion.identity);
        }
        
    }
}
