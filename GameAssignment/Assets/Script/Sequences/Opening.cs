using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public AudioSource Audio1;
    public AudioSource Audio2;

    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer() {
        yield return new WaitForSeconds (1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "...Where am I????";
        Audio1.Play();
        yield return new WaitForSeconds (2);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        TextBox.GetComponent<Text>().text = "I Get Out Of Here......";
        Audio2.Play();
        yield return new WaitForSeconds(1.7f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
    }

}
