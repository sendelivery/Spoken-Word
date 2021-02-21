using UnityEngine;
using UnityEngine.AI;

namespace Control
{
    // This should become a singleton at some point.
	public class Settings
	{
        public Settings(GameObject player, PlayerPhysics playerPhysics, CharacterController characterController, AgentMovement agentMovement, 
            NavMeshAgent navMeshAgent, float speed, float sens, Camera main, PlayerControls controls, PlayerUISetUp ui)
		{
            this.player = player;
            this.playerPhysics = playerPhysics;
            this.characterController = characterController;
            this.agentMovement = agentMovement;
            this.navMeshAgent = navMeshAgent;
            playerUI = ui;

            playerControls = controls;

            runSpeed = speed; sensitivity = sens; cam = main;

            // Log the created settings:
            Debug.Log("The following settings have been created:\n"
                + "gameObject: " + this.player + ",\n"
                + "characterController: " + this.characterController + ",\n"
                + "agentMovement: " + this.agentMovement + ",\n"
                + "navMeshAgent: " + this.navMeshAgent + ",\n"
                + "playerUI: " + this.playerUI + ",\n"
                + "playerControls: " + this.playerControls + ",\n"
                + "runSpeed: " + this.runSpeed + ",\n"
                + "sensitivity: " + this.sensitivity + ",\n"
                + "cam: " + this.cam + ",\n");
		}
        public GameObject player { get; }
        public PlayerPhysics playerPhysics { get; }
        public CharacterController characterController { get; }
        public AgentMovement agentMovement { get; }
        public NavMeshAgent navMeshAgent { get; }
        public PlayerUISetUp playerUI { get; set; }

        public PlayerControls playerControls { get; }

        public float runSpeed { get; }
        public float sensitivity { get; set; }

        public Camera cam { get; }
        public Transform target { get; set; }

        // Recently implemented settings:
        public float zoomedFOV = 30f;
        public float defaultFOV = 70f;
    }
}