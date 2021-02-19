using UnityEngine;
using System.Collections;
using System;

namespace Control
{
	public class RingToss : Minigame
	{
		public RingToss(Settings settings) : base(settings)
		{
		}

		public override void Start()
		{
			// On face buttons press
			settings.playerControls.RingToss.Confirm.performed += ctx => Confirm();
			settings.playerControls.RingToss.Back.performed += ctx => Back();

			settings.playerControls.DefaultGameplay.Disable();
			settings.playerControls.RingToss.Enable();
		}

		private void Confirm()
		{
			
		}

		private void Back()
		{
			settings.playerUI.RTExitTaskOnClick();
		}

		public override IEnumerator HandleInput()
		{
			Debug.Log("RingToss.HandleInput()");

			return base.HandleInput();
		}
	}
}