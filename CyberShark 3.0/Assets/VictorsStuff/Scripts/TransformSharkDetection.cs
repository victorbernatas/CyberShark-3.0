using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSharkDetection : MonoBehaviour
{

    [SerializeField] private Vector3 dirToTarget;
    [SerializeField] Transform playerPos;

    [SerializeField] private float dot1;
    [SerializeField] private float dot2;
    [SerializeField] private float dot3;
    [SerializeField] private float dot4;


    [SerializeField] GameObject northSphere;
    [SerializeField] GameObject eastSphere;
    [SerializeField] GameObject southSphere;
    [SerializeField] GameObject westSphere;


    [SerializeField] private bool northIsOrigin;
    [SerializeField] private bool southIsOrigin;
    [SerializeField] private bool westIsOrigin;
    [SerializeField] private bool eastIsOrigin;


    [SerializeField] private bool northIsActivated = false;
    [SerializeField] private bool southIsActivated = false;
    [SerializeField] private bool eastIsActivated = false;
    [SerializeField] private bool westIsActivated = false;


    [SerializeField] private bool isCurrentlyTargeted;

    [SerializeField] private bool goingClockwise;
    [SerializeField] private bool goingCounterClockwise;

    [SerializeField] private Color activatedColor;
    [SerializeField] private Color originColor;

    private SharkManager sharkManager;

    [SerializeField] int scoreValue;


    [SerializeField] private Renderer eastSphereRenderer;
    [SerializeField] private Renderer southSphereRenderer;
    [SerializeField] private Renderer westSphereRenderer;
    [SerializeField] private Renderer northSphereRenderer;

    private void Awake()
    {
        playerPos = GameObject.Find("SharkHead").GetComponent<Transform>();
        sharkManager = GameObject.Find("Shark").GetComponent<SharkManager>();


        
    }

    private void Start()
    {
       
    }

    private void Update()
    {

      

        DotDetection();
        NorthDetection();
        EastDetection();
        SouthDetection();
        WestDetection();
        IsCurrentlyTargeted();
        OriginDetection();
        boolCounter();
        ColorChange();


    }


    void DotDetection()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);


        if (playerPos != null)
        {
            dirToTarget = Vector3.Normalize(playerPos.transform.position - transform.position);
            dot1 = Mathf.Round (Vector3.Dot(forward, dirToTarget) * 10) * 0.1f;
            dot2 = Mathf.Round (Vector3.Dot(right, dirToTarget) *10) *0.1f;
            dot3 = Vector3.Dot(new Vector3(1, 0, 1), dirToTarget);


        }

    }


    void NorthDetection()
    {
        if (dot1 > 0 && dot2 == 0)
        {
            northIsActivated = true;
            
        }

        if (northIsActivated && !isCurrentlyTargeted && dot1 > 0 && dot2 < 0 && goingClockwise && !northIsOrigin)
        {
            northIsActivated = false;

        }

        if (northIsActivated && !isCurrentlyTargeted && dot1 > 0 && dot2 > 0 && goingCounterClockwise && !northIsOrigin)
        {
            northIsActivated = false;

        }
        //selfdestroy
        if (dot1 > 0 && dot2 == 0 && northIsOrigin && eastIsActivated && southIsActivated && westIsActivated)
        {
            SelfDestroy();
        }
    }


    void EastDetection()
    {
        if (dot1 == 0 && dot2 > 0)
        {
            eastIsActivated = true;
            
        }


        if (eastIsActivated && !isCurrentlyTargeted && dot1 > 0 && dot2 > 0 && goingClockwise && !eastIsOrigin)
        {
            eastIsActivated = false;

        }

        if (eastIsActivated && !isCurrentlyTargeted && dot1 < 0 && dot2 > 0 && goingCounterClockwise && !eastIsOrigin)
        {
            eastIsActivated = false;

        }

        if (dot1 == 0 && dot2 > 0 && eastIsOrigin && southIsActivated && westIsActivated && northIsActivated)
        {
            SelfDestroy();
        }
    }

    void SouthDetection()
    {
        if (dot1 < 0 && dot2 == 0)
        {
            southIsActivated = true;
           
        }

        if (southIsActivated && !isCurrentlyTargeted && dot1 < 0 && dot2 > 0 && goingClockwise && !southIsOrigin)
        {
            southIsActivated = false;

        }

        if (southIsActivated && !isCurrentlyTargeted && dot1 < 0 && dot2 < 0 && goingCounterClockwise && !southIsOrigin)
        {
            southIsActivated = false;

        }

        if (dot1 < 0 && dot2 == 0 && southIsOrigin && westIsActivated && northIsActivated && eastIsActivated)
        {
            SelfDestroy();
        }
    }


    void WestDetection()
    {
        if (dot1 == 0 && dot2 < 0)
        {
            westIsActivated = true;
            
        }

        if (westIsActivated && !isCurrentlyTargeted && dot1 < 0 && dot2 < 0 && goingClockwise && !westIsOrigin)
        {
            westIsActivated = false;

        }

        if (westIsActivated && !isCurrentlyTargeted && dot1 > 0 && dot2 < 0 && goingCounterClockwise && !westIsOrigin)
        {
            westIsActivated = false;

        }

        if(dot1 == 0 && dot2 < 0 && westIsOrigin && northIsActivated && eastIsActivated && southIsActivated)
        {
            SelfDestroy();
        }
    }

    void IsCurrentlyTargeted()
    {
        if(dot1 > 0 && dot2 == 0 || dot1 == 0 && dot2 > 0 || dot1 < 0 && dot2 == 0 || dot1 == 0 && dot2 < 0)
            {
            isCurrentlyTargeted = true;
            }

       
        else
        {
            isCurrentlyTargeted = false;
        }
    }

    void OriginDetection()
    {
        if (northIsActivated && !eastIsActivated && !southIsActivated && !westIsActivated)
        {
            northIsOrigin = true;
        }

        if (!northIsActivated && eastIsActivated && !southIsActivated && !westIsActivated)
        {
            eastIsOrigin = true;
        }

        if (!northIsActivated && !eastIsActivated && southIsActivated && !westIsActivated)
        {
            southIsOrigin = true;
        }

        if (!northIsActivated && !eastIsActivated && !southIsActivated && westIsActivated)
        {
            westIsOrigin = true;
        }


    }

    void boolCounter()
    {
        if (northIsOrigin && eastIsActivated && !goingCounterClockwise || eastIsOrigin && southIsActivated && !goingCounterClockwise ||
            southIsOrigin && westIsActivated && !goingCounterClockwise || westIsOrigin && northIsActivated && !goingCounterClockwise)
        {
            goingClockwise = true;
        }

        else
        {
            goingClockwise = false;
        }

        if (northIsOrigin && westIsActivated && !goingClockwise || westIsOrigin && southIsActivated && !goingClockwise ||
            southIsOrigin && eastIsActivated && !goingClockwise || eastIsOrigin && northIsActivated && !goingClockwise)
        {
            goingCounterClockwise = true;
        }

        else
        {
            goingCounterClockwise = false;
        }

    }

    void ColorChange()
    {
        

        if (northIsActivated && !northIsOrigin)
        {
            northSphereRenderer.material.SetColor("_BaseColor", Color.cyan);
        }

        else if (northIsOrigin)
        {
            northSphereRenderer.material.SetColor("_BaseColor", Color.red);
        }
        else
        {
            northSphereRenderer.material.SetColor("_BaseColor", Color.white);
        }


        if (eastIsActivated && !eastIsOrigin)
        {
            eastSphereRenderer.material.SetColor("_BaseColor", Color.cyan);
        }
        else if (eastIsOrigin)
        {
            eastSphereRenderer.material.SetColor("_BaseColor", Color.red);
        }

        else
        {
            eastSphereRenderer.material.SetColor("_BaseColor", Color.white);
        }

        if (southIsActivated && !southIsOrigin)
        {
            southSphereRenderer.material.SetColor("_BaseColor", Color.cyan);
        }
        else if (southIsOrigin)
        {
            southSphereRenderer.material.SetColor("_BaseColor", Color.red);
        }
        else
        {
            southSphereRenderer.material.SetColor("_BaseColor", Color.white);
        }




        if (westIsActivated && !westIsOrigin)
        {
            westSphereRenderer.material.SetColor("_BaseColor", Color.cyan);
        }

        else if (westIsOrigin)
        {
            westSphereRenderer.material.SetColor("_BaseColor", Color.red);
        }
        else
        {
            westSphereRenderer.material.SetColor("_BaseColor", Color.white);
        }
    }

    void SelfDestroy()
    {
        Destroy(this.gameObject);
        sharkManager.AddKill();
        sharkManager.AddScore(scoreValue);
    }
}
