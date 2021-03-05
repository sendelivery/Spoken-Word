using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
	public abstract class State
	{
		protected Dictionary<string, Action> actions = new Dictionary<string, Action>();

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

		public virtual void HandleIntent(string intent)
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