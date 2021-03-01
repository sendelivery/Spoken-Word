﻿using UnityEngine;

 namespace Control
{
	public abstract class ControlStateMachine : MonoBehaviour
	{
		protected State state;

		public void SetState(State incomingState)
		{
			this.state = incomingState;
			this.state.Initialise();
		}

		public void ChangeState(State incomingState)
		{
			this.state = incomingState;
		}
	}
}