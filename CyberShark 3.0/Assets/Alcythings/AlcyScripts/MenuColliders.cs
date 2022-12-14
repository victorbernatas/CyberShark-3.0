using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColliders : MonoBehaviour
{
    public GameObject menuUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hehe u have collided");
            Appear(other);
        }
    }

    void Appear(Collider player)
    {
        menuUI.SetActive(true);
    }

}
