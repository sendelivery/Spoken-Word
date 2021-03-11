using UnityEngine;
using System.Collections;
using System;
using UnityEngine.InputSystem;

namespace Control
{
	public class RingToss : Minigame
	{
		public RingToss(ref Settings settings) : base(ref settings)
		{
		}

		public override void Initialise()
		{
			base.Initialise();

			Debug.Log("Created a move voice action inside RingToss, minigame");
			_voiceActions.Add("fire", () => Fire());

			// On face buttons press
			settings.playerControls.RingToss.Fire.performed += ctx => Fire();

			settings.playerControls.Minigame.Enable();
			settings.playerControls.RingToss.Enable();
		}

		public override void Enable()
		{
			base.Enable();

			settings.playerControls.Minigame.Enable();
			settings.playerControls.RingToss.Enable();
		}

		private void Fire()
		{
			// process time spent from saying fire to reaching here,
			// adjust forcebar to go back that time spent,
			// then:
			settings.playerUI.TriggerPositive();
		}
	}
}