using UnityEngine;
using UnityEngine.AI;

namespace Control
{
    // This should become a singleton at some point.
	public class Settings
	{
        public Settings(GameObject player, ref VoiceCommands voiceCommands, PlayerPhysics playerPhysics, ref CharacterController characterController, AgentMovement agentMovement, 
            ref NavMeshAgent navMeshAgent, float speed, float sens, Camera main, PlayerControls controls, PlayerUISetUp ui)
		{
            this.player = player;
            this.voiceCommands = voiceCommands;
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
                + "playerUI: " + playerUI + ",\n"
                + "playerControls: " + playerControls + ",\n"
                + "runSpeed: " + runSpeed + ",\n"
                + "sensitivity: " + sensitivity + ",\n"
                + "cam: " + cam + ",\n");
		}
        public GameObject player { get; }
        public VoiceCommands voiceCommands { get; }
        public PlayerPhysics playerPhysics { get; }
        public CharacterController characterController { get; }
        public AgentMovement agentMovement { get; }
        public NavMeshAgent navMeshAgent { get; }
        public PlayerUISetUp playerUI { get; set; }

        public PlayerControls playerControls { get; }

        public float runSpeed { get; }
        public float sensitivity { get; set; }

        public Camera cam { get; }

        // Recently implemented settings:
        public float zoomedFOV = 30f;
        public float defaultFOV = 70f;
        public float goalRadius = 1f;
    }
}