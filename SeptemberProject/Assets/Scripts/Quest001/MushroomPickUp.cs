using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushroomPickUp : MonoBehaviour {
	public GameObject InteractText;
	public GameObject MushroomUI;

	void OnMouseOver () {
		if (Input.GetButtonDown ("Interact")) {
			MushroomManager.MushroomCount += 1;
			InteractText.SetActive (false);
			MushroomUI.GetComponent<Text> ().text = "Mushrooms Picked: " + MushroomManager.MushroomCount.ToString ();
			MushroomUI.SetActive (true);
			Destroy (gameObject);
		}
	}
}
