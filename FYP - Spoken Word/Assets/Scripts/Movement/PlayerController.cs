using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Currently this script is doing nothing, reconsider its use when refactoring the ControlHandler.cs
public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 1.5f;
	public float runSpeed = 4f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

	/*private void CheckTarget() {
		AgentMovement agentMovement = GetComponent<AgentMovement>();
		NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();

		// if the target exists or is valid
		if (true) { // for example: agentMovement.target != null
			// disable the player controller and re enable the agent movement
			// most likely have a movement manager script that enable and disables as the player sees fit.
		}
	}*/

	private void Start() { }

	public void HandleInput() {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0) {
			velocity.y = -2f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		if (Input.GetKey(KeyCode.LeftShift)) {
			controller.Move(move * runSpeed *Time.deltaTime);
		} else {
			controller.Move(move * speed * Time.deltaTime);
		}
		

		// Jump
		if (Input.GetButtonDown("Jump") && isGrounded) {
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}

	/*private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }*/
}
