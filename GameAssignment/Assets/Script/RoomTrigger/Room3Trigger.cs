using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3Trigger : MonoBehaviour
{
    public GameObject TheKey1;
    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;

    void OnTriggerEnter(Collider other) 
    { 
        TheKey1.SetActive(true);
        Room1.SetActive(false);
        Room2.SetActive(false);
        Room3.SetActive(false);
    }
}
