using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockDoor : MonoBehaviour
{
	public float TheDistance;
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject ExtraCross;
	public AudioSource lockDoor;
	public GameObject firstKeyDoor;
	public AudioSource DoorOpenSound;

	void Update()
	{
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver()
	{
		if (TheDistance <= 3)
		{
			ExtraCross.SetActive(true);
			ActionText.GetComponent<Text>().text = "OpenDoor";
			ActionDisplay.SetActive(true);
			ActionText.SetActive(true);
		}
		if (Input.GetButtonDown("Action"))
		{
			if (TheDistance <= 3)
			{
				this.GetComponent<BoxCollider>().enabled = false;
				ActionDisplay.SetActive(false);
				ActionText.SetActive(false);
				ExtraCross.SetActive(false);
				StartCoroutine(DoorReset());
			}
		}
	}

	void OnMouseExit() 
	{
		ExtraCross.SetActive(false);
		ActionDisplay.SetActive(false);
		ActionText.SetActive(false);
	}

	IEnumerator DoorReset()
	{
		if (GlobalInventory.firstDoorKey == false)
		{
			lockDoor.Play();
			yield return new WaitForSeconds(1);
			this.GetComponent<BoxCollider>().enabled = true;
		}
		else 
		{
			firstKeyDoor.GetComponent<Animator>().Play("KeyDoorAnim");
			DoorOpenSound.Play();
			yield return new WaitForSeconds(1);
			this.GetComponent<BoxCollider>().enabled = false;
		}
		
	}
}
