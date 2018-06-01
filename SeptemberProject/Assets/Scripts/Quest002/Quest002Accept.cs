using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Quest002Accept : MonoBehaviour {
	public GameObject InteractText;
	public GameObject DialoguePanel;
	public GameObject TextBox;
	public Text Text;
	public CharacterController PlayerControls;
	public TextAsset Dialogue; // A chunk of text e.g. a txt file
	public string[] TextLines; 
	public int CurrentLine002;
	public int EndLine002;
	public static int OffControls = 0;
	public GameObject Player;
	public GameObject AcceptButton;
	public GameObject RejectButton;
	public GameObject ItemInInventory;
	public GameObject QuestGiver002;
	public GameObject Dialogue002;

	void Start () {
		if (Dialogue != null) { // Checks if there is actually a txt file in the Dialogue variable
			TextLines = (Dialogue.text.Split ('\n')); // Splits the text found in the file by the \n
		}

		if (EndLine002 == 0) {
			EndLine002 = TextLines.Length;
		}
	}

	void OnMouseOver () {
		if (Input.GetButtonDown ("Interact")) {
			PlayerControls.GetComponent<CharacterController>().enabled = false;
			InteractText.SetActive (false);
			DialoguePanel.SetActive (true);
			TextBox.SetActive (true);
			Player.GetComponent<FirstPersonController>().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Dialogue002.SetActive (true);
		}
	}

	public void Update () {
		if (!TextBox.activeSelf) {
			CurrentLine002 = 0;
		}

		if (Dialogue002.activeSelf) {
			Text.text = TextLines [CurrentLine002];
			if (Input.GetKeyDown (KeyCode.Return)) {
				CurrentLine002 += 1;
			}

			if (CurrentLine002 == EndLine002 - 1) {
				AcceptButton.SetActive (true);
				RejectButton.SetActive (true);
			}

			if (CurrentLine002 == EndLine002) {
				if (Input.GetKeyDown (KeyCode.Return)) {
					CloseDialogue ();
				}
			}	
		}

		if (!TextBox.activeSelf) {
			CurrentLine002 = 0;
		}
	}

	void OnMouseExit () {
		InteractText.SetActive (false);
	}

	public void Accept () {
		ItemInInventory.SetActive (true);
		CloseDialogue ();
		QuestGiver002.GetComponent<Quest002Accepted>().enabled = true;
		GetComponent<Quest002Accept>().enabled = false;
	}

	public void Reject () {
		CloseDialogue ();
	}

	public void CloseDialogue () {
		TextBox.SetActive (false);
		DialoguePanel.SetActive (false);
		PlayerControls.GetComponent<CharacterController> ().enabled = true;
		Player.GetComponent<FirstPersonController>().enabled = true;
		Cursor.visible = false;	
		CurrentLine002 = 0;
		AcceptButton.SetActive (false);
		RejectButton.SetActive (false);
		Dialogue002.SetActive (false);
	}
}
