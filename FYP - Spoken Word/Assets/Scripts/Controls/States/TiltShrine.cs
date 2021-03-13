using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpokenWord;

namespace Control
{
	public class TiltShrine : Minigame
	{
        private Vector2 tilt;
        private Vector2 rotate;

		private Transform camera;
		private Transform temp;

        public TiltShrine(ref Settings settings) : base(ref settings)
		{
		}

		public override void Initialise()
		{
			base.Initialise();

            // Tilt
            settings.playerControls.TiltShrine.Tilt.performed += ctx => tilt = ctx.ReadValue<Vector2>();
            settings.playerControls.TiltShrine.Tilt.canceled += _ => tilt = Vector2.zero;

            // Rotate
            settings.playerControls.TiltShrine.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
            settings.playerControls.TiltShrine.Rotate.canceled += _ => rotate = Vector2.zero;

			camera = settings.cam.GetComponentsInParent<Transform>()[1];
			temp = GameManager.activeArena.transform;

			Enable();
        }

		public override void Enable()
		{
			base.Enable();

			settings.playerControls.Minigame.Enable();
			settings.playerControls.TiltShrine.Enable();
		}

		public override void HandleInput()
		{
			Debug.Log("TiltShrine.HandleInput");
			Debug.Log("tilt: " + tilt);
			Debug.Log("rotate: " + rotate);
			if (tilt != Vector2.zero)
			{
				temp.RotateAround(camera.position, camera.forward, -tilt.x);
				temp.RotateAround(camera.position, camera.right, tilt.y);

				// Discard yaw rotations then set rotations to the environment :)
				GameManager.activeArena.transform.rotation = 
					new Quaternion(temp.rotation.x, 0f, temp.rotation.z, temp.rotation.w);
			}
			if(rotate != Vector2.zero)
			{
				camera.Rotate(0, rotate.x * Time.deltaTime * 50f, 0);
			}
		}
	}
}