using UnityEngine;
using SpokenWord;
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

			_voiceActions.Add("fire", () => VoiceFire());

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
			settings.playerUI.TriggerPositive();
		}

		private void VoiceFire()
		{
			GameManager.osc.SetValue(GameManager.snapshot.forceSliderValue);
			settings.playerUI.TriggerPositive();
		}
	}
}