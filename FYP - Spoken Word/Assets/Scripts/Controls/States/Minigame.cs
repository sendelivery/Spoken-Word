using UnityEngine;
using System.Collections;

namespace Control
{
	public class Minigame : State
	{
		public Minigame(ref Settings settings) : base(ref settings)
		{
		}

		public override void Initialise()
		{
			base.Initialise();

			_voiceActions.Add("exit", () => Exit());
			settings.playerControls.Minigame.Back.performed += ctx => Exit();
			settings.playerControls.Minigame.Enable();
		}

		public virtual void Exit()
		{
			settings.playerUI.ExitButtonTaskOnClick();
			SendStateChangeEvent();
		}
	}
}