using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GetCaught : MonoBehaviour {

	public static int Peeked = 69;
	public GameObject ItemInInventory;
	public GameObject DialoguePanel;
	public GameObject TextBox;
	public Text Text;
	public GameObject Player;
	public GameObject CheckUp;
	public TextAsset Dialogue; // A chunk of text e.g. a txt file
	public string[] TextLines; 
	public int CurrentLine;
	public int EndLine;
	public GameObject OnDialogue003;
	public GameObject Shit;

	public void Start () {
		
	}

	public void OnTriggerEnter (Collider col) {
		if (col.tag == "Player" && ItemInInventory.activeSelf) {
			Player.GetComponent<CharacterController>().enabled = false;
			DialoguePanel.SetActive (true);
			Text.text = "HALT!!! Random Checkup...";
			TextBox.SetActive (true);
			Player.GetComponent<FirstPersonController>().enabled = false;
			CheckUp.SetActive (true);
			CheckUp.transform.parent = null;
			Player.transform.Rotate (0, 180, 0, Space.World);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

			if (Peeked == 1) {
				Debug.Log ("Peeked");
				Shit = GameObject.Find ("Peeked");
			} else if (Peeked == 0) {
				Debug.Log ("NOT Peeked");
				Shit = GameObject.Find ("NotPeeked");
			}

			if (Shit != null) { // Checks if there is actually a txt file in the Dialogue variable
				TextLines = (Shit.GetComponent<Text>().text.Split ('\n')); // Splits the text found in the file by the \n
			}

			if (EndLine == 0) {
				EndLine = TextLines.Length;
			}

			OnDialogue003.SetActive (true);
		}


	}

	public void Update () {
		ItemInInventory = GameObject.FindWithTag ("ItemInInventory");
		Player = GameObject.Find ("FPSController");

		if (OnDialogue003.activeSelf) {
			Text.text = TextLines [CurrentLine];
			if (Input.GetKeyDown (KeyCode.Return)) {
				CurrentLine += 1;
			}

			if (CurrentLine == EndLine) {
				if (Input.GetKeyDown (KeyCode.Return)) {
					CloseDialogue ();
				}
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
		OnDialogue003.SetActive (false);
		this.gameObject.GetComponent<MeshCollider>().enabled = false;
		this.gameObject.GetComponent<GetCaught>().enabled = false;
	}
}
