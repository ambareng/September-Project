
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public int conversing = 0;

	void OnMouseOver () {
		conversing = 1;
	}

	void OnMouseExit () {
		conversing = 0;
		gameObject.transform.GetChild (0).gameObject.SetActive (false);
	}

	void Update () {
		if (conversing == 1 && Input.GetButtonDown ("Interact")) {
			gameObject.transform.GetChild (0).gameObject.SetActive (true);	
		}
	}
}
