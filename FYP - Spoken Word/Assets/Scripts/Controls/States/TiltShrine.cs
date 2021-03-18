using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpokenWord;
using System;
using IBM.Watson.Assistant.V1.Model;

namespace Control
{
	public class TiltShrine : Minigame
	{
        private Vector2 tilt;
        private Vector2 rotate;

		private Transform camera;
		public Transform temp;

        public TiltShrine(ref Settings settings) : base(ref settings)
		{
		}

		public override void Initialise()
		{
			base.Initialise();

			camera = GameManager.tiltCamera.GetComponentsInParent<Transform>()[1];
			temp = GameManager.activeArena.transform;

			VoiceCommands voiceCommands = settings.voiceCommands;

			_voiceActions.Add("tilt", () => voiceCommands.TiltShrineTilt(incomingEntities, inputText, camera));
			_voiceActions.Add("rotate", () => voiceCommands.TiltShrineRotate(incomingEntities, inputText, camera));

            // Tilt
            settings.playerControls.TiltShrine.Tilt.performed += ctx => tilt = ctx.ReadValue<Vector2>();
            settings.playerControls.TiltShrine.Tilt.canceled += _ => tilt = Vector2.zero;

            // Rotate
            settings.playerControls.TiltShrine.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
            settings.playerControls.TiltShrine.Rotate.canceled += _ => rotate = Vector2.zero;

			Enable();
        }

		private void testRotate()
		{
			RuntimeEntity testEntity = new RuntimeEntity();
			RuntimeEntity secondTestEntity = new RuntimeEntity();

			string testText = "90";

			long start = 0;
			long length = (long)testText.Length;

			testEntity.Entity = "Number";
			testEntity.Location = new List<long?>();
			testEntity.Location.Add(start);
			testEntity.Location.Add(length);

			secondTestEntity.Entity = "Direction";
			secondTestEntity.Value = "left";

			incomingEntities = new List<RuntimeEntity>();

			incomingEntities.Add(testEntity);
			incomingEntities.Add(secondTestEntity);

			settings.voiceCommands.TiltShrineRotate(incomingEntities, testText, camera);
		}

		private void testTilt()
		{
			RuntimeEntity testEntity = new RuntimeEntity();
			RuntimeEntity secondTestEntity = new RuntimeEntity();

			string testText = "little";

			testEntity.Entity = "Amount";
			testEntity.Value = "large";

			secondTestEntity.Entity = "Direction";
			secondTestEntity.Value = "left";

			incomingEntities = new List<RuntimeEntity>();

			incomingEntities.Add(testEntity);
			incomingEntities.Add(secondTestEntity);

			settings.voiceCommands.TiltShrineTilt(incomingEntities, testText, camera);
		}

		public override void Enable()
		{
			base.Enable();

			Cursor.lockState = CursorLockMode.Locked;
			settings.playerControls.Minigame.Enable();
			settings.playerControls.TiltShrine.Enable();
		}

		public void Disable()
		{
			settings.playerControls.TiltShrine.Disable();
		}

		public override void HandleInput()
		{
			Debug.Log("Inside tilt HandleInput");
			if (tilt != Vector2.zero)
			{
				Debug.Log("Should be rotating");
				temp.RotateAround(camera.position, camera.forward, -tilt.x);
				temp.RotateAround(camera.position, camera.right, tilt.y);
				Debug.Log(GameManager.activeArena);
				Debug.Log(camera);
				// Discard yaw rotations then set rotation to the environment :)
				GameManager.activeArena.transform.rotation = 
					new Quaternion(temp.rotation.x, 0f, temp.rotation.z, temp.rotation.w);
			}
			if(rotate != Vector2.zero)
			{
				camera.Rotate(0f, rotate.x * Time.deltaTime * 50f, 0f);
			}
		}
	}
}