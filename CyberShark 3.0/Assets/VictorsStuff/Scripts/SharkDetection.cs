using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkDetection : MonoBehaviour
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

    [SerializeField] private bool isCurrentlytargeted = false;


    [SerializeField] private bool northIsOrigin;
    [SerializeField] private bool southIsOrigin;
    [SerializeField] private bool westIsOrigin;
    [SerializeField] private bool eastIsOrigin;

    [SerializeField] private float dot1;
    [SerializeField] private float dot2;

    [SerializeField] private Color activatedColor;
    [SerializeField] private Color originColor;

    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 dirToTarget;

    [SerializeField] private bool goingClockwise;
    [SerializeField] private bool goingCounterClockwise;


  
    void Update()
    {
        FourDirectionDetectionClockwise();
        ColorChange();
        DotDetection();
        
    }

    private void FourDirectionDetectionClockwise()
    {
        Ray northRay = new Ray(transform.position, Vector3.forward);
        Ray eastRay = new Ray(transform.position, Vector3.right);
        Ray southRay = new Ray(transform.position, Vector3.back);
        Ray westRay = new Ray(transform.position, Vector3.left);


        #region
        if (Physics.Raycast(northRay, 100f, playerLayerMask))
        {
            northIsActivated = true;

            ColorChange();
            OriginDetection();
            boolCounter();

            if (Physics.Raycast(northRay, 100f, playerLayerMask) && northIsOrigin && eastIsActivated && southIsActivated && westIsActivated)
            {
                Destroy(gameObject);

            }

        }

        if (northIsActivated && !isCurrentlytargeted && dot1 > 0 && dot2 < 0 && goingClockwise && !northIsOrigin)
        {
            northIsActivated = false;

        }

        if (northIsActivated && !isCurrentlytargeted && dot1 > 0 && dot2 > 0 && goingCounterClockwise && !northIsOrigin)
        {
            northIsActivated = false;

        }

        

        #endregion


        if (Physics.Raycast(eastRay, 100f, playerLayerMask))
        {
            eastIsActivated = true;
            ColorChange();
            OriginDetection();
            boolCounter();

            if (Physics.Raycast(eastRay, 100f, playerLayerMask) && eastIsOrigin && southIsActivated && westIsActivated && northIsActivated)
            {
                Destroy(gameObject);

            }

        }


        if (eastIsActivated && !isCurrentlytargeted && dot1 > 0 && dot2 >0 && goingClockwise && !eastIsOrigin)
        {
            eastIsActivated = false;
           
        }

        if (eastIsActivated && !isCurrentlytargeted && dot1 < 0 && dot2 > 0 && goingCounterClockwise && !eastIsOrigin)
        {
            eastIsActivated = false;

        }

        


        if (Physics.Raycast(southRay, 100f, playerLayerMask))
        {
            southIsActivated = true;
            ColorChange();
            OriginDetection();
            boolCounter();

            if (Physics.Raycast(southRay, 100f, playerLayerMask) && southIsOrigin && westIsActivated && northIsActivated && eastIsActivated)
            {
                Destroy(gameObject);

            }

        }

        if (southIsActivated && !isCurrentlytargeted && dot1 < 0 && dot2 > 0 && goingClockwise && !southIsOrigin)
        {
            southIsActivated = false;
            
        }

        if (southIsActivated && !isCurrentlytargeted && dot1 < 0 && dot2 < 0 && goingCounterClockwise && !southIsOrigin)
        {
            southIsActivated = false;

        }

        



        if (Physics.Raycast(westRay, 100f, playerLayerMask))
        {
            westIsActivated = true;
            ColorChange();
            OriginDetection();
            boolCounter();

            if (Physics.Raycast(westRay, 100f, playerLayerMask) && westIsOrigin && northIsActivated && eastIsActivated && southIsActivated)
            {
                Destroy(gameObject);

            }


        }

        if (westIsActivated && !isCurrentlytargeted && dot1 < 0 && dot2 < 0 && goingClockwise && !westIsOrigin)
        {
            westIsActivated = false;
          
        }

        if (westIsActivated && !isCurrentlytargeted && dot1 > 0 && dot2 < 0 && goingCounterClockwise && !westIsOrigin)
        {
            westIsActivated = false;

        }

        

        if (Physics.Raycast(northRay, 100f, playerLayerMask) || Physics.Raycast(eastRay, 100f, playerLayerMask) || 
            Physics.Raycast(southRay, 100f, playerLayerMask) || Physics.Raycast(westRay, 100f, playerLayerMask))
        {
            isCurrentlytargeted = true;
        }

        else
        {
            isCurrentlytargeted = false;
        }

    }

    void DotDetection()
    {
        dirToTarget = Vector3.Normalize(playerPos.transform.position - transform.position);
        dot1 = Vector3.Dot(Vector3.forward, dirToTarget);
        dot2 = Vector3.Dot(Vector3.right, dirToTarget);
    }

    void ColorChange()
    {
        Renderer northSphereRenderer = northSphere.GetComponent<Renderer>();
        Renderer eastSphereRenderer = eastSphere.GetComponent<Renderer>();
        Renderer southSphereRenderer = southSphere.GetComponent<Renderer>();
        Renderer westSphereRenderer = westSphere.GetComponent<Renderer>();

        if (northIsActivated && !northIsOrigin)
        {
            northSphereRenderer.material.SetColor("_Color", activatedColor);
        }

        else if (northIsOrigin)
        {
            northSphereRenderer.material.SetColor("_Color", originColor);
        }
        else
        {
            northSphereRenderer.material.SetColor("_Color", Color.white);
        }

        if (eastIsActivated && !eastIsOrigin)
        {
            eastSphereRenderer.material.SetColor("_Color", activatedColor);
        }
        else if (eastIsOrigin)
        {
            eastSphereRenderer.material.SetColor("_Color", originColor);
        }
        else
        {
            eastSphereRenderer.material.SetColor("_Color", Color.white);
        }

        if (southIsActivated &&!southIsOrigin)
        {
            southSphereRenderer.material.SetColor("_Color", activatedColor);
        }
        else if (southIsOrigin)
        {
            southSphereRenderer.material.SetColor("_Color", originColor);
        }

        else
        {
            southSphereRenderer.material.SetColor("_Color", Color.white);
        }

        if (westIsActivated && !westIsOrigin)
        {
            westSphereRenderer.material.SetColor("_Color", activatedColor);
        }

        else if (westIsOrigin)
        {
            westSphereRenderer.material.SetColor("_Color", originColor);
        }
        else
        {
            westSphereRenderer.material.SetColor("_Color", Color.white);
        }
    }

    void OriginDetection()
    {
        if(northIsActivated && !eastIsActivated && !southIsActivated && !westIsActivated)
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
        if(northIsOrigin && eastIsActivated && !goingCounterClockwise|| eastIsOrigin && southIsActivated && !goingCounterClockwise || 
            southIsOrigin && westIsActivated && !goingCounterClockwise || westIsOrigin && northIsActivated && !goingCounterClockwise)
        {
            goingClockwise = true;
        }

        else
        {
            goingClockwise = false;
        }

        if (northIsOrigin && westIsActivated && !goingClockwise|| westIsOrigin && southIsActivated && !goingClockwise || 
            southIsOrigin && eastIsActivated && !goingClockwise || eastIsOrigin && northIsActivated && !goingClockwise)
        {
            goingCounterClockwise = true;
        }

        else
        {
            goingCounterClockwise = false;
        }
        
    }

}   
