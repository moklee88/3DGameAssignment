using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAmmorPickUp : MonoBehaviour
{
    public GameObject ammoDisplayBox;

    void OnTriggerEnter(Collider other) {
        ammoDisplayBox.SetActive(true);
        GlobalAmmor.AmmorCount += 7;
        gameObject.SetActive(false);
    }
}
