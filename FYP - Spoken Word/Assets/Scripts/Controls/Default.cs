using System.Collections;
using UnityEngine;

namespace Control
{
	public class Default : State
	{
        Vector2 move;
        Vector2 look;

        public Default(Settings settings) : base(settings)
        {
            return;
        }

		public override void Start()
		{
            Debug.Log("Hey I'm in the Start function");
            // Movement & Look
            settings.playerControls.DefaultGameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            settings.playerControls.DefaultGameplay.Move.canceled += ctx => move = Vector2.zero;

            settings.playerControls.DefaultGameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
            settings.playerControls.DefaultGameplay.Look.canceled += ctx => look = Vector2.zero;

            // Interaction
            settings.playerControls.DefaultGameplay.Interact.performed += ctx => Interact();
            Debug.Log("The controls should have been set.");
            Debug.Log("Now executing the rest of the start method...");
            settings.navMeshAgent.enabled = false;
            settings.playerControls.DefaultGameplay.Enable();
		}

        public override IEnumerator Move()
		{
            if (settings.characterController.enabled == true)
            {
                // The below could potentially be extracted into its own method?
                if (move != Vector2.zero)
                {
                    // Map the 2D joystick input to a Vector3 for movement
                    // Here, we're using move.y as the z value of the Vector3
                    Vector3 m = Vector3.right * move.x + Vector3.forward * move.y;

                    settings.characterController.Move(m * settings.runSpeed * Time.deltaTime);
                }
                if (look != Vector2.zero)
                {
                    Vector2 r = new Vector2(-look.y, look.x) * settings.sensitivity * Time.deltaTime;
                    settings.cam.GetComponent<MouseLook>().HandleInput(r);
                }
            }
            // TODO: If player input is disabled, and input has been detected from the player,
            else if (settings.characterController.enabled == false)// && input detected
            {
                // TODO: Disable the navMeshAgent, destroy the target
                // TODO: Enable the character & player controller and proceed to handle input
                // playerController.enabled = true;
                // characterController.enabled = true;
                // playerController.HandleInput();
            }

            if (settings.target) // If we set a target to pathfind to:
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

            yield break;
        }

		public override IEnumerator Interact()
		{
            if (settings.playerControls.DefaultGameplay.enabled)
            {
                // TODO: call method in ui set up, or move that code here i.e. cast the ray from here,
                // if true move cam in ui set up.
                var (hitObjective, hit) = settings.playerUI.FireRay();
                if (hitObjective)
                {
                    // Disable the default player controls
                    settings.playerControls.DefaultGameplay.Disable();

                    // Enable the controls for the corresponding objective (in this case, ring toss) - use the hit variable returned
                    settings.playerControls.RingToss.Enable();
                }
            }
            else if (settings.playerControls.RingToss.enabled)
            {
                Debug.Log("Gamepad South registered");
            }

            yield break;
        }
	}
}