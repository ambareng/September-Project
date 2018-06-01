
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GuardDialogue : MonoBehaviour {

	public GameObject Dialogue;
	public string[] TextLines;
	public int EndLine;
	public GameObject Player;
	public GameObject InteractText;
	public GameObject DialoguePanel;
	public GameObject TextBox;
	public int CurrentLine;
	public GameObject ReportButton;
	public GameObject DontReportButton;
	public GameObject ItemInInventory;
	public int shit = 0;

	void Start () {
		if (Dialogue != null) { // Checks if there is actually a txt file in the Dialogue variable
			TextLines = Dialogue.GetComponent<Text>().text.Split ('\n'); // Splits the text found in the file by the \n
		}

		if (EndLine == 0) {
			EndLine = TextLines.Length;
		}
	}

	void Update () {
		if (shit == 0) {
			shit = 1;
			Player.GetComponent<CharacterController>().enabled = false;
			InteractText.SetActive (false);
			DialoguePanel.SetActive (true);
			TextBox.SetActive (true);
			Player.GetComponent<FirstPersonController>().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;	
		}

		if (ItemInInventory.activeSelf && GetCaught.Peeked == 1) {
			ReportButton.SetActive (true);
			DontReportButton.SetActive (true);
		}
			
		TextBox.GetComponent<Text> ().text = TextLines [CurrentLine];
		if (Input.GetKeyDown (KeyCode.Return)) {
			CurrentLine += 1;
		}

		if (CurrentLine == EndLine) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				CloseDialogue ();
			}
		}	
	}

	public void CloseDialogue () {
		TextBox.SetActive (false);
		DialoguePanel.SetActive (false);
		Player.GetComponent<CharacterController> ().enabled = true;
		Player.GetComponent<FirstPersonController>().enabled = true;
		Cursor.visible = false;	
		CurrentLine = 0;
		shit = 0;
		this.gameObject.SetActive (false);
	}
}
