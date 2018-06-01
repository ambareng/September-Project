
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PeekItem : MonoBehaviour {

	public GameObject ItemInInventory;
	public GameObject PeekButton;
	public GameObject NoPeekButton;
	public CharacterController PlayerControls;
	public GameObject DialoguePanel;
	public GameObject TextBox;
	public Text Text;
	public GameObject Player;
	public int DialogueDone = 0;

	public void OnTriggerExit (Collider col) {
		if (col.tag == "Player" && ItemInInventory.activeSelf) {
			PlayerControls.GetComponent<CharacterController>().enabled = false;
			DialoguePanel.SetActive (true);
			Text.text = "You sense something bad from the 'goods' you got from that person. Peek inside?";
			TextBox.SetActive (true);
			Player.GetComponent<FirstPersonController>().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			PeekButton.SetActive (true);
			NoPeekButton.SetActive (true);
		}
	}

	public void Peek () {
		Text.text = "Shit! It was illegal drugs all along! You are now faced with a dillema. Report to authorities, confront the man or just go along with it...";
		GetCaught.Peeked = 1;
		CloseDialogue ();
	}

	public void NoPeek () {
		Text.text = "Probably nothing... Either way I don't care as long as I get paid.";
		GetCaught.Peeked = 0;
		CloseDialogue ();
	}

	public void CloseDialogue () {
		PeekButton.SetActive (false);
		NoPeekButton.SetActive (false);
		DialogueDone = 1;
	}

	public void Update () {
		if (Input.GetKeyDown (KeyCode.Return) && DialogueDone == 1) {
			PlayerControls.GetComponent<CharacterController>().enabled = true;
			DialoguePanel.SetActive (false);
			TextBox.SetActive (false);
			Player.GetComponent<FirstPersonController>().enabled = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = false;
			DialogueDone = 0;
			this.gameObject.SetActive (false);
		}
	}
}
