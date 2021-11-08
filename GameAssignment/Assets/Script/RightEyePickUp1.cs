using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightEyePickUp1 : MonoBehaviour
{
	public float TheDistance;
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject ExtraCross;
	public GameObject TheRightEye;
	public GameObject HalfFade;
	public GameObject EyeImage;
	public GameObject EyeText;
	public GameObject FakeWall;
	public GameObject RealWall;

	void Update()
	{
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver()
	{
		if (TheDistance <= 3)
		{
			ExtraCross.SetActive(true);
			ActionText.GetComponent<Text>().text = "Pick Right Eye Puzzle";
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
				GlobalInventory.RightEye = true;
				StartCoroutine(EyePickUp());
			}
		}
	}

	void OnMouseExit()
	{
		ExtraCross.SetActive(false);
		ActionDisplay.SetActive(false);
		ActionText.SetActive(false);
	}

	IEnumerator EyePickUp()
	{
		EyeText.GetComponent<Text>().text = "You got the right eye piece";
		HalfFade.SetActive(true);
		EyeImage.SetActive(true);
		EyeText.SetActive(true);
		FakeWall.SetActive(false);
		RealWall.SetActive(true);
		yield return new WaitForSeconds(2);
		HalfFade.SetActive(false);
		EyeImage.SetActive(false);
		EyeText.SetActive(false);
		TheRightEye.SetActive(false);
	}
}
