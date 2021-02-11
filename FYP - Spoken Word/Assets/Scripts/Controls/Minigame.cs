using UnityEngine;
using System.Collections;

namespace Control
{
	public class Minigame : State
	{
		public Minigame(Settings settings) : base(settings)
		{
		}

		public override void Start()
		{
			// Cursor Movement

			// On button press... (ring toss => fire ring)
			settings.playerControls.RingToss.ThrowRing.performed += ctx => Interact();
		}

		public override IEnumerator Move()
		{
			Debug.Log("I'm in move MINIGAME!!");
			return base.Move();
		}
	}
}