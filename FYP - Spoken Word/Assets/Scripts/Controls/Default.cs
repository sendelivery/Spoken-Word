using System;
using System.Collections;
using UnityEngine;

namespace Control
{
	public class Default : State
	{
        Vector2 move;
        Vector2 look;
        bool run = false;
        float speed;

        bool zoom;

        public Default(Settings settings) : base(settings)
        {
            return;
        }

		public override void Start()
		{
            // Movement
            settings.playerControls.DefaultGameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            settings.playerControls.DefaultGameplay.Move.canceled += _ => move = Vector2.zero;
            settings.playerControls.DefaultGameplay.TriggerRun.performed += _ => run = true;
            settings.playerControls.DefaultGameplay.TriggerRun.canceled += _ => run = false;
            speed = settings.runSpeed;

            // Look & Zoom
            settings.playerControls.DefaultGameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
            settings.playerControls.DefaultGameplay.Look.canceled += _ => look = Vector2.zero;
            settings.playerControls.DefaultGameplay.ZoomHold.performed += _ => zoom = true;
            settings.playerControls.DefaultGameplay.ZoomHold.canceled += _ => zoom = false;
            settings.playerControls.DefaultGameplay.ZoomTap.performed += _ => zoom = !zoom;

            // Jump
            settings.playerControls.DefaultGameplay.Jump.performed += _ => Jump();

            // Interaction
            settings.playerControls.DefaultGameplay.Interact.performed += _ => Interact();

            // Disable the navMeshAgent component and enable the default gameplay action map
            settings.navMeshAgent.enabled = false;

            settings.playerControls.RingToss.Disable();
            settings.playerControls.DefaultGameplay.Enable();
		}

		public override IEnumerator HandleInput()
		{
            if (settings.characterController.enabled == true)
            {
                MoveAndLook();
            }

            // TODO: If player input is disabled, and input has been detected from the player,
            else if (settings.characterController.enabled == false /* && player input detected */)
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

            return base.HandleInput();
		}

        protected void MoveAndLook()
        {
            if (move != Vector2.zero)
            {
                // Map the 2D joystick input to a Vector3 for movement
                // Here, we're using move.y as the z value of the Vector3
                Vector3 m = settings.player.transform.right * move.x + settings.player.transform.forward * move.y;
                if (run && speed == settings.runSpeed)
                {
                    speed *= 1.5f;
                }
                settings.characterController.Move(m * speed * Time.deltaTime);
            }
            else
            {
                if (!run)
                {
                    speed = settings.runSpeed;
                }
            }
            if (look != Vector2.zero)
            {
                Vector2 r = new Vector2(-look.y, look.x) * settings.sensitivity * Time.deltaTime;
                settings.cam.GetComponent<MouseLook>().HandleInput(r);
            }

            float currentFOV = settings.cam.fieldOfView;

            if (currentFOV > settings.zoomedFOV && zoom) // If current fov is > 30 and we want to zoom
            {
                Zoom(currentFOV, settings.zoomedFOV);
            }
            else if (currentFOV < settings.defaultFOV && !zoom) // If current fov is less than 70 and we want to zoom out
            {
                Zoom(currentFOV, settings.defaultFOV);
            }
        }

        private void Zoom(float currentFOV, float targetFOV)
        {
            settings.cam.fieldOfView = Mathf.Lerp(currentFOV, targetFOV, 8f * Time.deltaTime);
        }

		private void Jump()
		{
            settings.playerPhysics.Jump();
        }

		protected override void Interact()
		{
            Debug.Log("default.interact");
            // TODO: call method in ui set up, or move that code here i.e. cast the ray from here,
            // if true move cam in ui set up.
            var (hitObjective, hit) = settings.playerUI.FireRay();
            if (hitObjective)
            {
                // Switch state
                SendStateChangeEvent();
            }
        }
	}
}