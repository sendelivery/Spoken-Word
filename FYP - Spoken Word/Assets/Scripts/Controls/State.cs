using System.Collections;
using UnityEngine;

namespace Control
{
	public abstract class State
	{
		protected Settings settings;

		public State(Settings settings)
		{
			Debug.Log("Configuring state settings");
			this.settings = settings;

			Debug.Log("Previously created settings have been set for this state.\n" +
				"The following settings have been created:\n"
				+ "characterController: " + this.settings.characterController + ",\n"
				+ "agentMovement: " + this.settings.agentMovement + ",\n"
				+ "navMeshAgent: " + this.settings.navMeshAgent + ",\n"
				+ "playerUI: " + this.settings.playerUI + ",\n"
				+ "playerControls: " + this.settings.playerControls + ",\n"
				+ "runSpeed: " + this.settings.runSpeed + ",\n"
				+ "sensitivity: " + this.settings.sensitivity + ",\n"
				+ "cam: " + this.settings.cam + ",\n");

			return;
		}

		public virtual void Start()
		{
			return;
		}

		public virtual IEnumerator Move()
		{
			yield break;
		}

		/*
		public virtual IEnumerator Look()
		{
			yield break;
		}
		*/
		public virtual IEnumerator Interact()
		{
			yield break;
		}
	}
}