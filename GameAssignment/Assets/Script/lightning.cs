using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutThrow : MonoBehaviour
{
    public AudioClip throwSound;
    public GameObject CoconutObject;
    public float throwForce;
    static public bool canThrow = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1") /*&& canThrow*/)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = throwSound;
            audio.Play();
            GameObject temp = Instantiate(CoconutObject, transform.position, transform.rotation);
            temp.name = "Coconut";
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(new Vector3(0, 0, throwForce));

            if(temp.GetComponent<Rigidbody>() == null)
            {
                Debug.Log("Component Missing!");
                temp.AddComponent<Rigidbody>();
                Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), temp.GetComponent<Collider>(), true);
            }
        }
    }
}
