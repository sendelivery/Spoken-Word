using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

	public Text textField;

	void Update() {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0) {
			velocity.y = -2f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * speed * Time.deltaTime);

		HandleInput("");

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);

		// process text
		if (textField.text.Contains("(Final, ")) {
			if (textField.text.Contains("go") && textField.text.Contains("a")) {
				string incomingSpeech = "A";
				GetComponent<PlayerAI>().HandleObjective(incomingSpeech); // Something is wrong with this line!
			} else {
				GetComponent<PlayerMovement>().HandleInput(textField.text);
			}
		}
	}

	public void HandleInput(string incomingSpeech) {
		if (Input.GetButtonDown("Jump") && isGrounded || incomingSpeech.Contains("jump") && isGrounded) {
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
	}
}
