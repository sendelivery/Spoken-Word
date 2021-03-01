using System;
using System.Collections;
using UnityEngine;

namespace Control
{
	public class Default : State
	{
        private Vector2 move;
        private Vector2 look;
        private bool run = false;
        private float speed;

        private bool zoom;

        private Transform target;

        public enum TargetState { NONE, SET, REACHED }
        public TargetState targetState = TargetState.NONE;

        public Default(ref Settings settings) : base(ref settings)
        {
            return;
        }

		public override void Initialise()
		{
            // Disable previous action map
            settings.playerControls.RingToss.Disable();

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
            zoom = false;

            // Jump
            settings.playerControls.DefaultGameplay.Jump.performed += _ => Jump();

            // Interaction
            settings.playerControls.DefaultGameplay.Interact.performed += _ => Interact();

            // Listen for C# Event


            // Disable the navMeshAgent component and enable the default gameplay action map
            settings.navMeshAgent.enabled = false;

            // Enable the default action map
            settings.playerControls.DefaultGameplay.Enable();
		}

		public override void HandleInput()
		{
            // TODO: If player input is disabled, and input has been detected from the player,
            //else if (settings.characterController.enabled == false && move != Vector2.zero)
            //{
                //Debug.Log("Agent navigation cancelled.");
                // TODO: Disable the navMeshAgent, destroy the target
                // TODO: Enable the character & player controller and proceed to handle input
                // characterController.enabled = true;
            //}

            if (target) // If we set a target to pathfind to:
            {
                if (settings.navMeshAgent.enabled == false) settings.navMeshAgent.enabled = true; // Enable the navMeshAgent

                // Checks if the agent can find a valid path to the target
                if (settings.agentMovement.CheckTarget(settings.navMeshAgent, target))
                {
                    Debug.Log("Valid target found.");

                    // Disable the player control components and set the destination for the navMeshAgent to pathfind to:
                    settings.characterController.enabled = false;
                    settings.navMeshAgent.enabled = true;

                    settings.navMeshAgent.SetDestination(target.position);

                    float dist = settings.navMeshAgent.remainingDistance;
                    Debug.Log(dist);

                    // Once the target has been reached, destroy the target, 
                    // re enable the player controller and disable the agent
                    if (dist != 0 && dist <= settings.goalRadius)
					{
                        target = null;
                        targetState = TargetState.REACHED;
                        settings.characterController.enabled = true;
                        settings.navMeshAgent.enabled = false;
					}
                }
                else
                {
                    settings.navMeshAgent.enabled = false;
                    settings.characterController.enabled = true;
                    ResetTarget();
                    Debug.Log("Invalid target. \nDouble check the target's y coord is above or on the terrain" +
                        "\nand x and z coords are on the nav mesh.");
                }
            }

            if (settings.characterController.enabled == true)
            {
                MoveAndLook();
            }

            base.HandleInput();
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

            if (currentFOV > settings.zoomedFOV && zoom) // If current fov is greater than 30 and we want to zoom
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

            // Set the FOV to 30 after it reaches below 30.5
            // this is so we have an earlier definite end to the zoom function call
            if (zoom && settings.cam.fieldOfView < 30.5f) settings.cam.fieldOfView = settings.zoomedFOV;

            // Same as above but for zoom out, set FOV to 70 if it's above 69.5
            else if (!zoom && settings.cam.fieldOfView > 69.5f) settings.cam.fieldOfView = settings.defaultFOV;
        }

		private void Jump()
		{
            settings.playerPhysics.Jump();
        }

        protected override void Interact()
        {
            // TODO: call method in ui set up, or move that code here i.e. cast the ray from here,
            // if true move cam in ui set up.
            var (hitObjective, hit) = settings.playerUI.FireRay();
            if (hitObjective)
            {
                // Switch state
                SendStateChangeEvent();
            }
        }

        public void SetTarget(Transform t)
		{
            target = t;
            targetState = TargetState.SET;
		}

        public void ResetTarget()
		{
            target = null;
            targetState = TargetState.NONE;
		}
    }
}