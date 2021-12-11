using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class PlayerExample : MonoBehaviour
{
    public AudioClip shootSound;
    public float soundIntensity = 5f; //distance for the sound travelled to let enemy hear
    public float walkEnemyPerceptionRadius = 1f;
    public float sprintEnemyPerceptionRadius = 1.5f;
    public LayerMask enemyLayer;


    private AudioSource audioSource;
    private FirstPersonController fpsc;
    private SphereCollider sphereCollider;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fpsc = GetComponent<FirstPersonController>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }

        if (fpsc.GetPlayerStealthProfile() == 0)
        {
            sphereCollider.radius = walkEnemyPerceptionRadius;
        }else
        {
            sphereCollider.radius = sprintEnemyPerceptionRadius;
        }
    }

    public void shoot()
    {
        audioSource.PlayOneShot(shootSound);
        Collider[] enemy = Physics.OverlapSphere(transform.position, soundIntensity, enemyLayer);
        for(int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<AIExample>().OnAware(); 
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<AIExample>().OnAware();
        }
    }
}
