using UnityEngine;
using UnityEngine.AI;

namespace Control
{
	public class ControlHandler : ControlStateMachine
    {
        [Header("User Control Instances")]
        // [SerializeField] PlayerMovement playerMovement;
        [SerializeField] CharacterController characterController;

        [Header("Agent Control Instances")]
        [SerializeField] AgentMovement agentMovement;
        [SerializeField] NavMeshAgent navMeshAgent;

        [Header("The Rest...")] // Organise this in a way that makes sense please.
        [SerializeField] float runSpeed;
        [SerializeField] float sensitivity;
        [SerializeField] PlayerUISetUp playerUI;

        private static PlayerControls _controls;
        private static Settings _settings;

        State _default;
        State _minigame;

        private void Awake()
        {
            PlayerControls controls = new PlayerControls();

            _settings = new Settings(characterController, agentMovement, navMeshAgent,
                runSpeed, sensitivity, Camera.main, controls, playerUI);

            print("Creating default state...");
            _default = new Default(_settings);
            Debug.Log("Default created: " + _default);
            print("Creating minigame state...");
            _minigame = new Minigame(_settings);
        }

        void Start()
        {
            print("Setting state to default...\nDefault state = " + _default);
			SetState(_default);
            print("Default state set.");
        }

        public bool test = false;

        void Update()
        {
            // Lets me change the current state with boolean test
            StartCoroutine(state.Move());
			
            if(test)
			{
                SetState(_minigame);
			}

        }
    }
}