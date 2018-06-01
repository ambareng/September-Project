using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Quest001Accept : MonoBehaviour {
	public GameObject InteractText;
	public GameObject DialoguePanel;
	public GameObject Quest001TextBox;
	public Text Quest001Text;
	public CharacterController PlayerControls;
	public TextAsset Dialogue; // A chunk of text e.g. a txt file
	public string[] TextLines; 
	public int CurrentLine;
	public int EndLine;
	public static int OffControls = 0;
	public GameObject Player;
	public GameObject AcceptButton;
	public GameObject RejectButton;
	public GameObject FindMe1;
	public GameObject FindMe2;
	public GameObject FindMe3;
	public GameObject QuestGiver001;
	public GameObject OnDialogue001;

	void Start () {
		if (Dialogue != null) { // Checks if there is actually a txt file in the Dialogue variable
			TextLines = (Dialogue.text.Split ('\n')); // Splits the text found in the file by the \n
		}

		if (EndLine == 0) {
			EndLine = TextLines.Length;
		}
	}

	void OnMouseOver () {
		if (Input.GetButtonDown ("Interact")) {
			PlayerControls.GetComponent<CharacterController>().enabled = false;
			InteractText.SetActive (false);
			DialoguePanel.SetActive (true);
			Quest001TextBox.SetActive (true);
			Player.GetComponent<FirstPersonController>().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			OnDialogue001.SetActive (true);
		}
	}

	public void Update() {
		if (!Quest001TextBox.activeSelf) {
			CurrentLine = 0;
		}

		if (OnDialogue001.activeSelf) {
			Quest001Text.text = TextLines [CurrentLine];
			if (Input.GetKeyDown (KeyCode.Return)) {
				CurrentLine += 1;
			}

			if (CurrentLine == EndLine - 1) {
				AcceptButton.SetActive (true);
				RejectButton.SetActive (true);
			}

			if (CurrentLine == EndLine) {
				if (Input.GetKeyDown (KeyCode.Return)) {
					CloseDialogue ();
				}
			}
		}
			
		if (!Quest001TextBox.activeSelf) {
			CurrentLine = 0;
		}
	}

	void OnMouseExit () {
		InteractText.SetActive (false);
	}

	public void Accept () {
		FindMe1.SetActive (true);
		FindMe2.SetActive (true);
		FindMe3.SetActive (true);
		CloseDialogue ();
		QuestGiver001.GetComponent<Quest001Accepted>().enabled = true;
		GetComponent<Quest001Accept>().enabled = false;
	}

	public void Reject () {
		CloseDialogue ();
	}

	public void CloseDialogue () {
		Quest001TextBox.SetActive (false);
		DialoguePanel.SetActive (false);
		PlayerControls.GetComponent<CharacterController> ().enabled = true;
		Player.GetComponent<FirstPersonController>().enabled = true;
		Cursor.visible = false;	
		CurrentLine = 0;
		AcceptButton.SetActive (false);
		RejectButton.SetActive (false);
		OnDialogue001.SetActive (false);
	}
}
