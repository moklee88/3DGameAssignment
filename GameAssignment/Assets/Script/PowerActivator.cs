using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerActivator : MonoBehaviour
{
    GameObject electric;
    public GameObject flare;
    public Camera fpsCam;
    public float range = 100f;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        electric = GameObject.Find("Electric");
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(num);
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            num++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            num--;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (num%2 == 0)
            {
                electric.GetComponent<ParticleSystem>().Play();
                ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
                em.enabled = true;
            }

            else if (num % 2 == 1)
            {
                RaycastHit hit;
                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
                {
                    GameObject impactGO = Instantiate(flare, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, 5f);
                }
            }
        }
    }
}
