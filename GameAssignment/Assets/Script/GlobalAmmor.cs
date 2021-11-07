using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmor : MonoBehaviour
{

    public static int AmmorCount;
    public GameObject ammorDisplay;
    public int InternalAmmor;

    void Update()
    {
        InternalAmmor = AmmorCount;
        ammorDisplay.GetComponent<Text>().text = "" + AmmorCount;        
    }
}
