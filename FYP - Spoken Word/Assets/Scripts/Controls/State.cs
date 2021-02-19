using System;
using System.Collections;
using UnityEngine;

namespace Control
{
	public abstract class State
	{
		protected Settings settings;

		public delegate void StateEventHandler();
		public event StateEventHandler ChangedControlState;

		public State(Settings settings)
		{
			this.settings = settings;

			return;
		}

		public virtual void Start()
		{
			return;
		}

		public virtual IEnumerator HandleInput()
		{
			yield break;
		}

		protected virtual void Interact()
		{
			Debug.Log("Base, State.Interact(): Not yet implemented.");
		}

		protected virtual void SendStateChangeEvent()
		{

			ChangedControlState.Invoke();
		}
	}
}