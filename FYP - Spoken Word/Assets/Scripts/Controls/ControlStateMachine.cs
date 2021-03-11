using UnityEngine;

 namespace Control
{
	public abstract class ControlStateMachine : MonoBehaviour
	{
		protected State state;

		public void SetState(State incomingState)
		{
			this.state = incomingState;
			if (this.state.firstSwitch)
			{
				this.state.Initialise();
				this.state.firstSwitch = false;
			}
			else
			{
				this.state.Enable();
			}
		}
	}
}