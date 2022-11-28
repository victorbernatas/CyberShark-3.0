using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] LayerMask playerLayerMask;

    [SerializeField] GameObject northSphere;
    [SerializeField] GameObject eastSphere;
    [SerializeField] GameObject southSphere;
    [SerializeField] GameObject westSphere;

    [SerializeField] private bool northIsActivated = false;
    [SerializeField] private bool southIsActivated = false;
    [SerializeField] private bool eastIsActivated = false;
    [SerializeField] private bool westIsActivated = false;

    [SerializeField] private bool northIsOrigin;
    [SerializeField] private bool southIsOrigin;
    [SerializeField] private bool westIsOrigin;
    [SerializeField] private bool eastIsOrigin;

    private bool arrivedNorthFromWest;
    private bool arrivedNorthFromEast;
    private bool arrivedSouthFromWest;
    private bool arrivedSouthFromEast;
    private bool arrivedEastFromNorth;
    private bool arrivedEastFromSouth;
    private bool arrivedWestFromNorth;
    private bool arrivedWestFromSouth;

    private bool goingClockwise;
    private bool goingCounterClockwise;

    [SerializeField] int pointsActivated = 0;



    [SerializeField] private Color activatedColor;

    [SerializeField] private GameObject playerMesh;

    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 dirToTarget;
    [SerializeField] private float dot1;
    [SerializeField] private float dot2;

    [SerializeField] private float initialDot;



    [SerializeField] private bool isCurrentlytargeted = false;

    // Start is called before the first frame update
    void Start()
    {
        activatedColor = new Color(1f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        NorthDetection();
        SouthDetection();
        EastDetection();
        WestDetection();

        AttemptAtDot();

        BoolCalculator();

        

    }


    private void NorthDetection()
    {
        Vector3 northDirection = new Vector3(0, 0, 1);
        Renderer northSphereRenderer = northSphere.GetComponent<Renderer>();

        if (Physics.Raycast(transform.position, northDirection, out RaycastHit forwardHit, 100f, playerLayerMask))
        {
           
            
            isCurrentlytargeted = true;
            northIsActivated = true;
            pointsActivated++;

            if(southIsActivated == false && eastIsActivated == false && westIsActivated == false)
            {
                northIsOrigin = true;
                northSphereRenderer.material.SetColor("_Color", Color.red);
            }
            else
            {
                northSphereRenderer.material.SetColor("_Color", activatedColor);
            }
            
        }

        else
        {           
            isCurrentlytargeted = false;         
        }

        if (northIsActivated == true && westIsActivated == true && isCurrentlytargeted == false && dot1 > 0 && dot2 < 0 && arrivedNorthFromWest == true
          || northIsActivated == true && eastIsActivated == true && isCurrentlytargeted == false && dot1 > 0 && dot2 > 0 && arrivedNorthFromEast == true)
        {
            pointsActivated--;
            northIsActivated = false;
            northSphereRenderer.material.SetColor("_Color", Color.white);
        }

        if (Physics.Raycast(transform.position, northDirection, 100f, playerLayerMask) && northIsOrigin == true && northIsActivated == true && southIsActivated == true && westIsActivated == true && eastIsActivated == true)

        {
            Destroy(this.gameObject);
        }
    }

    private void SouthDetection()
    {
        Vector3 southDirection = new Vector3(0, 0, -1);
        Renderer southSphereRenderer = southSphere.GetComponent<Renderer>();

        if (Physics.Raycast(transform.position, southDirection, out RaycastHit backwardHit, 100f, playerLayerMask))
        {
            southIsActivated = true;
            isCurrentlytargeted = true;
            pointsActivated++;
        

            if (northIsActivated == false && eastIsActivated == false && westIsActivated == false)
            {
                southIsOrigin = true;
                southSphereRenderer.material.SetColor("_Color", Color.red);
            }
            else
            {
                southSphereRenderer.material.SetColor("_Color", activatedColor);
            }

        }
        else
        {
            isCurrentlytargeted = false;
        }

        if (southIsActivated == true && eastIsActivated == true && isCurrentlytargeted == false && dot1 < 0 && dot2 > 0 && arrivedSouthFromEast
        || southIsActivated == true && westIsActivated == true && isCurrentlytargeted == false && dot1 < 0 && dot2 < 0 && arrivedSouthFromWest)
        {
            pointsActivated--;
            southIsActivated = false;
            southSphereRenderer.material.SetColor("_Color", Color.white);
        }

        if (Physics.Raycast(transform.position, southDirection, 100f, playerLayerMask) && southIsOrigin == true && northIsActivated == true && southIsActivated == true && westIsActivated == true && eastIsActivated == true)
        {
            Destroy(this.gameObject);
        }



    }


    private void EastDetection()
    {
        Vector3 eastDirection = new Vector3(1, 0, 0);
        Renderer eastSphereRenderer = eastSphere.GetComponent<Renderer>();

        if (Physics.Raycast(transform.position, eastDirection, out RaycastHit eastwardHit, 100f, playerLayerMask))
        {
            eastIsActivated = true;
            isCurrentlytargeted = true;
            pointsActivated++;
            

            if (northIsActivated == false && southIsActivated == false && westIsActivated == false)
            {
                eastIsOrigin = true;
                eastSphereRenderer.material.SetColor("_Color", Color.red);
            }

            else
            {
                eastSphereRenderer.material.SetColor("_Color", activatedColor);
            }

        }
        else
        {
            isCurrentlytargeted = false;
        }

        // try for cancelling activation

        if(eastIsActivated == true && northIsActivated && isCurrentlytargeted == false && dot1 > 0 && dot2 > 0 && arrivedEastFromNorth == true 
            || eastIsActivated == true && southIsActivated && isCurrentlytargeted == false && dot1 < 0 && dot2 > 0 && arrivedEastFromSouth)
        {
            pointsActivated--;
            eastIsActivated = false;
            eastSphereRenderer.material.SetColor("_Color", Color.white);
        }

        if (Physics.Raycast(transform.position, eastDirection, 100f, playerLayerMask) && eastIsOrigin == true && northIsActivated == true && southIsActivated == true && westIsActivated == true && eastIsActivated == true)
        {
            Destroy(this.gameObject);
        }
    }


    private void WestDetection()
    {
        

        Vector3 westDirection = new Vector3(-1, 0, 0);
        Renderer westSphereRenderer = westSphere.GetComponent<Renderer>();

        if (Physics.Raycast(transform.position, westDirection, out RaycastHit westwardHit, 100f, playerLayerMask))
        {
            westIsActivated = true;
            isCurrentlytargeted = true;
            pointsActivated++;
            

            if (northIsActivated == false && eastIsActivated == false && southIsActivated == false)
            {
                westIsOrigin = true;
                westSphereRenderer.material.SetColor("_Color", Color.red);
            }
            else
            {
                westSphereRenderer.material.SetColor("_Color", activatedColor);
            }

        }
        else
        {
            isCurrentlytargeted = false;
        }
        if (westIsActivated == true && southIsActivated == true && isCurrentlytargeted == false && dot1 < 0 && dot2 < 0 && arrivedWestFromSouth
            || westIsActivated == true && northIsActivated == true && isCurrentlytargeted == false && dot1 > 0 && dot2 < 0 && arrivedWestFromNorth)
        {
            pointsActivated--;
            westIsActivated = false;
            westSphereRenderer.material.SetColor("_Color", Color.white);
        }

        if (Physics.Raycast(transform.position, westDirection, 100f, playerLayerMask) && westIsOrigin == true && northIsActivated == true && southIsActivated == true && westIsActivated == true && eastIsActivated == true)
        {
            Destroy(this.gameObject);
        }

    }

    private void AttemptAtDot()
    {
        dirToTarget = Vector3.Normalize(playerPos.transform.position - transform.position);
        dot1 = Vector3.Dot(Vector3.forward, dirToTarget);

        dot2 = Vector3.Dot(Vector3.right, dirToTarget);

       
    }

    private void BoolCalculator()
    {
        if (northIsOrigin && westIsActivated || westIsOrigin && southIsActivated || southIsOrigin && eastIsActivated || eastIsOrigin && northIsActivated)
        {
            goingCounterClockwise = true;
            return;
        }

        if (northIsOrigin && eastIsActivated || eastIsOrigin && southIsActivated || southIsOrigin && westIsActivated || westIsOrigin && northIsActivated)
        {
            goingClockwise = true;
        }


    }

    private void WhichDirection()
    {
        if(pointsActivated == 2 && goingClockwise)
        {

        }

        if(pointsActivated == 2 && goingCounterClockwise)
        {

        }

    }

    



}
