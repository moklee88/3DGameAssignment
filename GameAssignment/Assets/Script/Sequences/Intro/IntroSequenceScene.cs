using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequenceScene : MonoBehaviour
{
    public GameObject textBox;
    public GameObject DateDisplay;
    public GameObject DividerImage;
    public GameObject PlaceDisplay;
    public AudioSource Audio1;
    public AudioSource Audio2;
    public AudioSource Audio3;
    public AudioSource Audio4;
    public AudioSource Audio5;
    public AudioSource ThudSound;
    public GameObject Allblack;
    public GameObject LoadText;
    //public GameObject MainCamera;

    void Start()
    {
        StartCoroutine(SequenceBegin());
    }

    IEnumerator SequenceBegin()
            
    {
        yield return new WaitForSeconds(3);
        PlaceDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        DividerImage.SetActive(true);
        yield return new WaitForSeconds(1);
        DateDisplay.SetActive(true);
        yield return new WaitForSeconds(4);
        PlaceDisplay.SetActive(false);
        DateDisplay.SetActive(false);
        DividerImage.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "The night of October 29th 2008 change me forever!"; 
        Audio1.Play();
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "I headed out to investigate the haunting sounds in the woods!";
        Audio2.Play();
        yield return new WaitForSeconds(6);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "I stumbled upon a clearing with a cabin in the distance!";
        Audio3.Play();
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "I could hear those sounds again coming from there!";
        Audio4.Play();
        yield return new WaitForSeconds(4); 
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "Little did i know that this only the beginning!";
        Audio5.Play();
        yield return new WaitForSeconds(14 );
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(15);
        Allblack.SetActive(true);
        ThudSound.Play();
        yield return new WaitForSeconds(5);
        LoadText.SetActive(true);
        SceneManager.LoadScene(2);
        //MainCamera.SetActive(false);

    }

}
