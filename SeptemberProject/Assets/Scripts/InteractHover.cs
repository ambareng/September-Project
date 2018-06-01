using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHover : MonoBehaviour {
	public GameObject InteractText;
	public GameObject DialoguePanel;

	void OnMouseOver () { // If mouse hovers on the object this script is atatched to...
		if (DistanceToPlayer.ToTarget <= 3 && !DialoguePanel.activeSelf) { // ...and if the distance of the player to it gotten from the DistanceToPlayer script is equal to or less than 3...
			InteractText.SetActive (true); // ...then turn on this object.
		}
	}

	void OnMouseExit () { // If mouse doesn't hover on object anymore...
		InteractText.SetActive (false); // ...then turn off this object.
	}
}
