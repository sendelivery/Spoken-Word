using IBM.Watson.Assistant.V1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
	public abstract class State
	{
		protected Dictionary<string, Action> _voiceActions = new Dictionary<string, Action>();
		protected List<RuntimeEntity> incomingEntities;
		protected string inputText;

		protected Settings settings;

		public delegate void StateEventHandler();
		public event StateEventHandler ChangeStateDefault;
		public event StateEventHandler ChangeStateTiltShrine;
		public event StateEventHandler ChangeStateRingToss;

		public bool firstSwitch = true;

		public State(ref Settings settings)
		{
			this.settings = settings;

			return;
		}

		public virtual void Initialise()
		{
			// Disable all action maps
			settings.playerControls.DefaultGameplay.Disable();
			settings.playerControls.Minigame.Disable();
			settings.playerControls.RingToss.Disable();
			settings.playerControls.TiltShrine.Disable();

			//_voiceActions.Add("pause", () => settings.player.GetComponent<ControlHandler>().Pause(settings.playerControls));
			//_voiceActions.Add("options", () => settings.player.GetComponent<ControlHandler>().Options(settings.playerControls));
		}

		public virtual void Enable()
		{
			// Disable all action maps - enable the one(s) you want in the derived state
			settings.playerControls.DefaultGameplay.Disable();
			settings.playerControls.Minigame.Disable();
			settings.playerControls.RingToss.Disable();
		}

		public virtual void Disable()
		{
		}

		public virtual void HandleInput()
		{
			return;
		}

		public virtual void HandleIntent(string intent, List<RuntimeEntity> entities, string text)
		{
			incomingEntities = entities;
			inputText = text;

			if (_voiceActions.ContainsKey(intent))
				_voiceActions[intent]();
			else
			{
				Debug.LogError("Couldn't find an action tied to the following intent: " + intent);
			}

			incomingEntities.Clear();
		}

		public virtual void HandleMultipleIntents(string[] intentOutput, List<RuntimeEntity> entities, string text)
		{
			incomingEntities = entities;
			inputText = text;

			for(int i = 0; i < intentOutput.Length; i++)
			{
				if(_voiceActions.ContainsKey(intentOutput[i]))
				{
					_voiceActions[intentOutput[i]]();
				}
				else
				{
					Debug.LogError("Couldn't find an action tied to the following intent: " + intentOutput[i]);
				}
			}

			incomingEntities.Clear();
		}

		protected virtual void Interact()
		{
			return;
		}

		protected virtual void SendStateChangeEvent()
		{
			ChangeStateDefault.Invoke();
		}

		protected virtual void SendStateChangeEvent(string minigame)
		{
			switch (minigame)
			{
				case "RingToss":
					ChangeStateRingToss.Invoke();
					break;
				case "TiltShrine":
					ChangeStateTiltShrine.Invoke();
					break;
				default:
					ChangeStateDefault.Invoke();
					Debug.LogWarning(minigame + " control state doesn't exist.");
					break;
			}
		}
	}
}