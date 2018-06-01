using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnThenOff : MonoBehaviour {
	void OnEnable () {
		StartCoroutine (ShowUI ());
	}

	IEnumerator ShowUI () {
		yield return new WaitForSecondsRealtime (1);
		this.gameObject.SetActive (false);
	}
}
