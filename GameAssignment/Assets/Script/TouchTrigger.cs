using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    public GameObject FallDownTrigger;
    public GameObject touchTrigger;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        touchTrigger.SetActive(true);
        StartCoroutine(DeactivateToughtObject());
    }

    IEnumerator DeactivateToughtObject()
    {
        yield return new WaitForSeconds(0.5f);
        touchTrigger.SetActive(false);
        //yield return new WaitForSeconds(2.5f);
    }

}
