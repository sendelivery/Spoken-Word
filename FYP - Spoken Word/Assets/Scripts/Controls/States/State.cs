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
		public event StateEventHandler ChangedControlState;

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
		}

		public virtual void Enable()
		{
			// Disable all action maps
			settings.playerControls.DefaultGameplay.Disable();
			settings.playerControls.Minigame.Disable();
			settings.playerControls.RingToss.Disable();
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

		public virtual void HandleMultipleIntents(string[] intentOutput, List<RuntimeEntity> entities)
		{
			return;
		}

		protected virtual void Interact()
		{
			return;
		}

		protected virtual void SendStateChangeEvent()
		{
			ChangedControlState.Invoke();
		}
	}
}