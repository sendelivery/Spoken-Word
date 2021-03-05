using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SpokenWord
{
	public static class GameManager
	{
		#region Pause Canvas Members
		private static GameObject pauseCanvas = GameObject.FindGameObjectWithTag("Pause Canvas");
		private static AdjustTimeScale timeSlider = pauseCanvas.GetComponentInChildren<AdjustTimeScale>();

		private static float newTimeScale;

		private static GameObject tempSelected;
		private static CursorLockMode tempCursorState;
		#endregion

		#region Options Canvas Members
		private static GameObject optionsCanvas = GameObject.FindGameObjectWithTag("Options Canvas");
		private static float tempTime;
		#endregion

		public static void Pause()
		{
			if (Time.timeScale == 0f) // Unpause
			{
				// Min slider value is 0.1f, time scale will not be set to 0 outside of the pause screen.
				if (newTimeScale > 0 && newTimeScale < 1) Time.timeScale = newTimeScale;
				else Time.timeScale = 1f;

				timeSlider.TimeScaleChanged -= SetTimeScale;
				pauseCanvas.GetComponent<Canvas>().enabled = false;

				EventSystem.current.SetSelectedGameObject(tempSelected);

				Cursor.lockState = tempCursorState;
			}
			else // Pause
			{
				Time.timeScale = 0;
				timeSlider.TimeScaleChanged += SetTimeScale;

				pauseCanvas.GetComponent<Canvas>().enabled = true;

				tempSelected = EventSystem.current.currentSelectedGameObject;
				EventSystem.current.SetSelectedGameObject(timeSlider.gameObject);

				tempCursorState = Cursor.lockState;
				Cursor.lockState = CursorLockMode.Confined;
			}
		}

		public static void Options()
		{
			Canvas canvas = optionsCanvas.GetComponent<Canvas>();

			if (canvas.enabled == false)
			{
				canvas.enabled = true;
			}
			else
			{
				canvas.enabled = false;
			}

			if (Time.timeScale > 0)
			{
				tempTime = Time.timeScale;
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = tempTime;
			}

		}

		private static void SetTimeScale()
		{
			newTimeScale = timeSlider.GetComponent<Slider>().value;
		}
	}
}