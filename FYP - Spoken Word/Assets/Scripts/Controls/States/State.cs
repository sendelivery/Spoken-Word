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

		protected Settings settings;

		public delegate void StateEventHandler();
		public event StateEventHandler ChangedControlState;

		public State(ref Settings settings)
		{
			this.settings = settings;

			return;
		}

		public virtual void Initialise()
		{
			return;
		}

		public virtual void HandleInput()
		{
			return;
		}

		public virtual void HandleIntent(string intent, List<RuntimeEntity> entities)
		{
			incomingEntities = entities;
			_voiceActions[intent]();
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