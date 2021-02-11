using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ProcessText : MonoBehaviour
{
    public Text textField;
	[SerializeField] private GameObject player;

	private void Start() {
	}

	// Update is called once per frame
	void Update()
    {
        if (textField.text.Contains("(Final, ")) {
			if (textField.text.Contains("go") && textField.text.Contains("a")) {
				string incomingSpeech = "A";
				//player.GetComponent<PlayerAI>().HandleObjective(incomingSpeech); // Something is wrong with this line!
			} else {
				//player.GetComponent<PlayerMovement>().HandleInput(textField.text);
			}
		}
    }
}
