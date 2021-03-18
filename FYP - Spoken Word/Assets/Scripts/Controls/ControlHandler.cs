using IBM.Watson.Assistant.V1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
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

        [Header("Other Player Settings")]
        [SerializeField] float runSpeed;
        [SerializeField] float sensitivity;
        [SerializeField] PlayerUISetUp playerUI;

        [Header("Pathfinding")]
        [SerializeField] public Transform target;
        #endregion

        private static VoiceCommands voiceCommands;
        private static Settings _settings;
        private static State _default;
        private static State _ringtoss;
        private static State _tilt;

        private void Awake()
        {
            PlayerControls controls = new PlayerControls();

            // Start and Select (Pause and Options)
            controls.Pause.Enable();
            controls.Pause.Pause.performed += ctx => Pause(controls);
            controls.Pause.Options.performed += ctx => Options(controls);

            SetUpVoiceCommands();

            // _settings contains references to any objects or components needed by each state
            _settings = new Settings(this.gameObject, ref voiceCommands, playerPhysics, ref characterController,
                agentMovement, ref navMeshAgent, runSpeed, sensitivity, Camera.main, controls, playerUI);

            if (_default == null || _ringtoss == null || _tilt == null)
			{
                _default = new Default(ref _settings);
                _ringtoss = new RingToss(ref _settings);
                _tilt = new TiltShrine(ref _settings);
            }

            SetState(_default);
        }

        // Need to attach voice commands to an object because
        // coroutines can only be called if attached to an object, 
        private void SetUpVoiceCommands()
		{
            GameObject obj = new GameObject("Voice Commands");
            obj.AddComponent<VoiceCommands>();
            voiceCommands = obj.GetComponent<VoiceCommands>();
		}

		private void OnEnable()
		{
            _tilt.ChangeStateDefault += SwitchStateDefault;
            _ringtoss.ChangeStateDefault += SwitchStateDefault;
            _default.ChangeStateTiltShrine += () => SwitchState("TiltShrine");
            _default.ChangeStateRingToss += () => SwitchState("RingToss");
        }

		private void OnDisable()
        {
            _tilt.ChangeStateDefault -= SwitchStateDefault;
            _ringtoss.ChangeStateDefault -= SwitchStateDefault;
            _default.ChangeStateTiltShrine -= () => SwitchState("TiltShrine");
            _default.ChangeStateRingToss -= () => SwitchState("RingToss");
        }

		void FixedUpdate()
        {
            Debug.Log(state);
            state.HandleInput();
            if (target)
			{
                switch (((Default)_default).targetState) // Downcast to access Default.cs members of _default
                {
                    case Default.TargetState.NONE:
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
		}

		public void Options(PlayerControls c)
        {
            if (c.Pause.Pause.enabled) c.Pause.Pause.Disable();
            else c.Pause.Pause.Enable();
            SpokenWord.GameManager.Options();
        }

        public void Pause(PlayerControls c)
        {
            if (c.Pause.Options.enabled) c.Pause.Options.Disable();
            else c.Pause.Options.Enable();
            SpokenWord.GameManager.Pause();
        }

        private void SwitchState(string v)
        {
            switch (v)
            {
                case "RingToss":
                    playerUI.reticle.SetActive(false);
                    SetState(_ringtoss);
                    break;
                case "TiltShrine":
                    playerUI.reticle.SetActive(false);
                    SetState(_tilt);
                    break;
                default:
                    Debug.LogWarning("Unable to find a control state that matches: " + v);
                    break;
            }
        }

		public void SwitchStateDefault()
		{
            playerUI.reticle.SetActive(true);
            SetState(_default);
		}

        internal void HandleIntent(List<RuntimeIntent> intents, List<RuntimeEntity> entities, string text, float confThreshold)
        {
            // If there is more than one intent
            if (intents.Count > 1)
			{
                string[] intentOutput = new string[2];

                // Get only the top 2 intents that are above the confidence threshold
                for (int i = 0; i < 2; i++)
                {
                    intentOutput[i] = intents[i].Confidence >= confThreshold ? intents[i].Intent : null;
                }
                state.HandleMultipleIntents(intentOutput, entities);
            }
            else
			{
                string intent = intents[0].Intent;
                state.HandleIntent(intent, entities, text);
			}
        }

        // Tilt Shrine specific functions:
        public void DisableControls()
        {
            ((TiltShrine)state).Disable();
        }

        public void EnableControls()
        {
            ((TiltShrine)state).Enable();
        }

        public void UpdateTiltTranformReference()
        {
            ((TiltShrine)state).temp = SpokenWord.GameManager.activeArena.transform;
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