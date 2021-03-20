using UnityEngine;
using SpokenWord;

namespace Control
{
	public class RingToss : Minigame
	{
		private int clickCount = 0;

		public RingToss(ref Settings settings) : base(ref settings)
		{
		}

		public override void Initialise()
		{
			base.Initialise();

			_voiceActions.Add("fire", () => VoiceFire());
			settings.playerControls.RingToss.Fire.performed += ctx => Fire();

			// Get exit button, add listener.
			GameManager.rtWaypoint.negativeAction.onClick.AddListener(settings.playerUI.ExitButtonTaskOnClick);

			Enable();
		}

		public override void Enable()
		{
			base.Enable();

			Cursor.lockState = CursorLockMode.Confined;
			settings.playerControls.Minigame.Enable();
			settings.playerControls.RingToss.Enable();
		}

		public override void Disable()
		{
			// Disable the fire button so it's not accidentally pressed when next entering the ringtoss game.
			GameManager.rtWaypoint.positiveAction.interactable = false;
		}

		public override void HandleInput()
		{
			base.HandleInput();

			// The following if is used to stop the fire button being accidentally clicked when first
			// interacting with the ring toss waypoint. If you click on the screen, because the fire button
			// takes up the whole space, it'll actually trigger the button once you let go of the mouse.
			// This if gives a 10 frame window where this won't happen because the button is not interactible
			// yet. Basically what I'm saying is, there's gotta be a better way of doing this lmao.
			if (clickCount == 10)
			{
				GameManager.rtWaypoint.positiveAction.interactable = true;
			}
			else
				clickCount++;
		}

		private void Fire()
		{
			GameManager.rtWaypoint.positiveAction.onClick.Invoke();
		}

		private void VoiceFire()
		{
			Debug.LogWarning("Voice fire");
			GameManager.osc.SetValue(GameManager.snapshot.forceSliderValue);
			GameManager.rtWaypoint.positiveAction.onClick.Invoke();
		}

		public override void Exit()
		{
			Disable();
			base.Exit();
		}
	}
}