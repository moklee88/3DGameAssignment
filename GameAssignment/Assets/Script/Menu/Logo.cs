 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(TakeToMenu());
    }

    IEnumerator TakeToMenu()
    { 
    yield return new WaitForSeconds(7);
        SceneManager.LoadScene(1);
    }

}
