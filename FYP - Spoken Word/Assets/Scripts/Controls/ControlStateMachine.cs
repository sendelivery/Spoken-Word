using UnityEngine;

 namespace Control
{
	public abstract class ControlStateMachine : MonoBehaviour
	{
		protected State state;

		public void SetState(State incomingState)
		{
			Debug.Log("Configuring new state to set.\nState to be set:" + incomingState);
			this.state = incomingState;

			Debug.Log("New state has been set:" + 
				this.state);

			Debug.Log("Triggering start method of new state...");
			// Trigger the start method of the newly passed in state.
			this.state.Start();
		}
	}
}