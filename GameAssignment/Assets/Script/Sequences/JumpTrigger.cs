using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{

    public AudioSource DoorBang;
    public AudioSource DoorJumpMusic;
    public GameObject TheZombie;
    public GameObject TheDoor;
    public AudioSource Music;

    void OnTriggerEnter()
    {

        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("JumpDoorAnim");
        DoorBang.Play();
        TheZombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());


    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        Music.Stop();
        DoorJumpMusic.Play();
    }
}
