using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ControlHandler : MonoBehaviour
{
    [Header("User Control Instances")]
    [SerializeField] PlayerController playerController;
    [SerializeField] CharacterController characterController;

    [Header("Agent Control Instances")]
    [SerializeField] AgentMovement agentMovement;
    [SerializeField] NavMeshAgent navMeshAgent;

    public Transform target;
    public float goalRadius = 1f;

    PlayerControls controls;

    Vector2 move;
    Vector2 look;
    Camera cam;
    public float runSpeed = 4f;
    public float sensitivity = 100f;
    public PlayerUISetUp playerUI;

    // refactor
    public CharacterController controller;

    private string activeActionMap = "defaultGameplay";

	private void Awake()
	{
        controls = new PlayerControls();
        /* DEFAULT CONTROL MAP ************************************************************/
        // Movement & Look
        controls.DefaultGameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.DefaultGameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.DefaultGameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.DefaultGameplay.Look.canceled += ctx => look = Vector2.zero;

        // Interaction
        controls.DefaultGameplay.Interact.performed += ctx => Interact();

        /* RING TOSS CONTROL MAP **********************************************************/
        // Cursor Movement

        // Fire Ring
        controls.RingToss.ThrowRing.performed += ctx => Interact();
	}

	private void OnEnable()
	{
        controls.DefaultGameplay.Enable();
	}

	private void OnDisable()
	{
        controls.DefaultGameplay.Disable();
	}

	void Start()
    {
        navMeshAgent.enabled = false;

        cam = Camera.main;
    }

    void Update()
    {
        if (controller.enabled == true)
        {
            // The below could potentially be extracted into its own method?
            if (move != Vector2.zero)
            {
                // Map the 2D joystick input to a Vector3 for movement
                // Here, we're using move.y as the z value of the Vector3
                Vector3 m = transform.right * move.x + transform.forward * move.y;

                controller.Move(m * runSpeed* Time.deltaTime);
            }
            if (look != Vector2.zero)
			{
                Vector2 r = new Vector2(-look.y, look.x) * sensitivity * Time.deltaTime;
                cam.GetComponent<MouseLook>().HandleInput(r);
            }
        } 
        // TODO: If player input is disabled, and input has been detected from the player,
        else if (controller.enabled == false)// && input detected
        {
            // TODO: Disable the navMeshAgent, destroy the target
            // TODO: Enable the character & player controller and proceed to handle input
            // playerController.enabled = true;
            // characterController.enabled = true;
            // playerController.HandleInput();
        }

        if (target) // If we set a target to pathfind to:
		{
            /* TODO: Give the Testing-02 scene a nav mesh
            if (navMeshAgent.enabled == false) navMeshAgent.enabled = true; // Enable the navMeshAgent

            // Checks if the agent can find a valid path to the target
            if (agentMovement.CheckTarget(navMeshAgent, target))
            {
                // Disable the player control components and set the destination for the navMeshAgent to pathfind to:
                playerController.enabled = false;
                characterController.enabled = false;
                navMeshAgent.SetDestination(target.position);

                float dist = navMeshAgent.remainingDistance;

                // Once the target has been reached, destroy the target, re enable the player controller and disable the agent
                if (dist != Mathf.Infinity && dist != 0 && navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && dist <= goalRadius)
                {
                    target = null; // TODO destroy the target

                    playerController.enabled = true;
                    characterController.enabled = true;

                    navMeshAgent.enabled = false;
                }
            }
            else
            {
                navMeshAgent.enabled = false;
                playerController.enabled = true;
                characterController.enabled = true;
            }
            */
        }
    }

    private void Interact()
    {
        if (controls.DefaultGameplay.enabled)
        {
            // TODO: call method in ui set up, or move that code here i.e. cast the ray from here,
            // if true move cam in ui set up.
            var (hitObjective, hit) = playerUI.FireRay();
            if (hitObjective)
            {
                // Disable the default player controls
                controls.DefaultGameplay.Disable();

                // Enable the controls for the corresponding objective (in this case, ring toss) - use the hit variable returned
                controls.RingToss.Enable();
            }
        } 
        else if (controls.RingToss.enabled)
		{
            Debug.Log("Gamepad South registered");
		}
    }
}
