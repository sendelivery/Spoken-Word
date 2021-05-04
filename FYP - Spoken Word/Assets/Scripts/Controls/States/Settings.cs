using UnityEngine;
using UnityEngine.AI;

namespace Control
{
	public class Settings
	{
        // Simplified constructor
        /// <summary>
        /// Simplified constructor only requiring the camera and player controls.
        /// Used only for prototyping control states for new minigames.
        /// </summary>
        public Settings(Camera main, PlayerControls controls, ref VoiceCommands voiceCommands)
		{
            cam = main;
            playerControls = controls;
            this.voiceCommands = voiceCommands;

		}

        // Complete constructor
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

            // Other settings
            this.navMeshAgent.speed = speed; 
            runSpeed = speed; 
            sensitivity = sens; 
            cam = main;
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

        public float zoomedFOV = 30f;
        public float defaultFOV = 70f;
        public float goalRadius = 1f;
    }
}