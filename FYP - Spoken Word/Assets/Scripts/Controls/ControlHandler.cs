using System;
using UnityEngine;
using UnityEngine.AI;

namespace Control
{
	public class ControlHandler : ControlStateMachine
    {
        [Header("User Control Instances")]
        [SerializeField] PlayerPhysics playerPhysics;
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
        State _ringtoss;

        private void Awake()
        {
            PlayerControls controls = new PlayerControls();

            controls.Pause.Enable();
            controls.Pause.Pause.performed += ctx => GameManager.Pause();

            // _settings contains references to any objects or components needed by each state to move the character for example.
            _settings = new Settings(this.gameObject, playerPhysics, characterController, agentMovement, navMeshAgent,
                runSpeed, sensitivity, Camera.main, controls, playerUI);

            _default = new Default(_settings);
            _ringtoss = new RingToss(_settings);

            SetState(_default);
        }

		private void OnEnable()
		{
            state.ChangedControlState += SwitchState;
        }

		private void OnDisable()
        {
            state.ChangedControlState -= SwitchState;
        }

        public bool changeState = false;
        public int count = 0;

		void Update()
        {
            Debug.Log("Calling the state.HandleInput()");
            StartCoroutine(state.HandleInput());
            
            if (changeState && count == 0)
			{
                SwitchState();
                ++count;
			}
        }

        private void SwitchState()
        {
            Debug.Log("Changing state to minigame");

            if (state == _default) SetState(_ringtoss);
            else if (state == _ringtoss) SetState(_default);
        }

		public void SwitchStateDefault()
		{
            SetState(_default);
		}
	}
}