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

            player.GetComponent<PlayerMovement>().HandleInput(textField.text);
            // HandleInput(textField.text);
		}
    }
}
