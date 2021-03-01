using System;
using UnityEngine;
using UnityEngine.AI;

namespace Control
{
	public class ControlHandler : ControlStateMachine
    {
		#region Serialized Fields
		[Header("User Control References")]
        [SerializeField] PlayerPhysics playerPhysics;
        [SerializeField] CharacterController characterController;

        [Header("Agent Control References")]
        [SerializeField] AgentMovement agentMovement;
        [SerializeField] NavMeshAgent navMeshAgent;

        [Header("Other Player Settings")] // Organise this in a way that makes sense please.
        [SerializeField] float runSpeed;
        [SerializeField] float sensitivity;
        [SerializeField] PlayerUISetUp playerUI;

        [Header("Pathfinding")]
        [SerializeField] public Transform target;
        #endregion

        private static Settings _settings;
        private static State _default;
        private static State _ringtoss;

        private void Awake()
        {
            PlayerControls controls = new PlayerControls();

            // Start and Select (Pause and Options)
            controls.Pause.Enable();
            controls.Pause.Pause.performed += ctx => Pause(controls);
            controls.Pause.Options.performed += ctx => Options(controls);

            // _settings contains references to any objects or components needed by each state
            // to move the character for example.
            _settings = new Settings(this.gameObject, playerPhysics, ref characterController, agentMovement, ref navMeshAgent,
                runSpeed, sensitivity, Camera.main, controls, playerUI);

            if (_default == null || _ringtoss == null)
			{
                _default = new Default(ref _settings);
                _ringtoss = new RingToss(ref _settings);
			}

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

		void Update()
        {
            state.HandleInput();
			switch (((Default)_default).targetState) // Downcast to access Default.cs members of _default
			{
				case Default.TargetState.NONE:
                    Debug.Log("case: NONE");
                    if (target)
					{
                        Debug.Log("Target set");
                        // target = AdjustPosition(target); // Adjust pos so that it's on top of the terrain. (if not using the target game object in the hierarchy)

                        ((Default)_default).SetTarget(target);
                    }
                    break;

                case Default.TargetState.SET:
                    Debug.Log("case: SET");
                    break;

                case Default.TargetState.REACHED:
                    Debug.Log("case: REACHED");
                    // If we have a target but it's been reached: set it to null, and reset the target state inside _default.
                    if (target)
                    {
                        target = null;
                        ((Default)_default).targetState = Default.TargetState.NONE;
                    }
                    break;

                default:
					break;
			}
		}

        private Transform AdjustPosition(Transform t)
		{
            Vector3 pos = t.position; // Get the selected target's position

            // Get the gameobject called Target and give it the selected target's world position.
            GameObject temp = GameObject.FindGameObjectWithTag("Target");
            temp.transform.position = pos;
            temp.GetComponent<TargetPlacement>().PlaceOnTerrain();

            return temp.transform;
		}

		private void Options(PlayerControls c)
        {
            if (c.Pause.Pause.enabled) c.Pause.Pause.Disable();
            else c.Pause.Pause.Enable();
            GameManager.Options();
        }

        private void Pause(PlayerControls c)
        {
            if (c.Pause.Options.enabled) c.Pause.Options.Disable();
            else c.Pause.Options.Enable();
            GameManager.Pause();
        }

        private void SwitchState()
        {
            Debug.Log("Changing state to minigame");

            if (state == _default) ChangeState(_ringtoss);
            else if (state == _ringtoss) ChangeState(_default);
        }

		public void SwitchStateDefault()
		{
            ChangeState(_default);
		}

        [ContextMenu("Autofill Fields")]
        void AutofillFields()
        {
            playerPhysics = gameObject.GetComponent<PlayerPhysics>();
            characterController = gameObject.GetComponent<CharacterController>();

            agentMovement = gameObject.GetComponent<AgentMovement>();
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

            playerUI = gameObject.GetComponentInChildren<PlayerUISetUp>();
            runSpeed = 5f;
            sensitivity = 100f;
        }
	}
}