using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDead : MonoBehaviour
{

    public int EnemyHealth = 20;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource JumpScareMusic;
    public AudioSource Music;

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }
        void Update()
    {
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            TheEnemy.GetComponent<Animation>().Stop("walk");
            TheEnemy.GetComponent<Animation>().Play("back_fall");
            JumpScareMusic.Stop();
            Music.Play();
        }
    }
}