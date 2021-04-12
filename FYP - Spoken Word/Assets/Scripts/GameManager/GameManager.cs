using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using System;

namespace SpokenWord
{
	public class GameManager : MonoBehaviour
	{
		[Header("Player")]
		[SerializeField]
		private GameObject _player;
		public static GameObject player;
		[SerializeField]
		private GameObject _fadeIn;
		private static GameObject fadein;
		private static TextMeshProUGUI instructionsText;
		private static TextMeshProUGUI thanksText;
		private static TextMeshProUGUI quitText;
		public static Camera camera;

		public static Snapshot snapshot;

		public static int waypointCount;

		#region Ring Toss Members
		[Header("Ring Toss")]
		public Waypoint ringToss;
		public static Waypoint rtWaypoint;
		public GameObject forceBar;
		[HideInInspector]
		public static Oscillator2 osc;
		#endregion

		#region
		[Header("Tilt Shrine")]
		public Waypoint tiltShrine;
		public static Waypoint tsWaypoint;
		[SerializeField]
		private Camera _tiltCamera;
		public static Camera tiltCamera;
		public List<GameObject> arenas;
		private static List<GameObject> staticArenas;
		public static GameObject activeArena;
		private static int arenaIndex = 0;
		#endregion

		[Header("Pause / Options")]
		#region Pause Canvas Members
		[SerializeField]
		private GameObject _pauseCanvas;
		[SerializeField]
		private Button _quitGameButton;
		private static Button quitGameButton;
		private static GameObject pauseCanvas;
		private static AdjustTimeScale timeSlider;

		private static float newTimeScale;

		private static GameObject tempSelected;
		private static CursorLockMode tempCursorState;
		private static bool tempCursorVisibility;
		#endregion

		#region Options Canvas Members
		[SerializeField]
		private GameObject _optionsCanvas;
		private static GameObject optionsCanvas;
		private static float tempTime;
		#endregion

		private void Awake()
		{
			player = _player;

			fadein = _fadeIn;
			fadein.GetComponent<Image>().color = new Color(0, 0, 0, 1); // black, no transparency
			instructionsText = fadein.GetComponentsInChildren<TextMeshProUGUI>()[0];
			instructionsText.color = new Color(1, 1, 1, 0); // white, transparent
			thanksText = fadein.GetComponentsInChildren<TextMeshProUGUI>()[1];
			thanksText.color = new Color(1, 1, 1, 0); // white, transparent
			quitText = thanksText.gameObject.GetComponentsInChildren<TextMeshProUGUI>()[1];
			quitText.color = new Color(1, 1, 1, 0); // white, transparent

			camera = Camera.main;
			tiltCamera = _tiltCamera;

			rtWaypoint = ringToss;
			tsWaypoint = tiltShrine;

			waypointCount = 2;

			osc = forceBar.GetComponent<Oscillator2>();
			staticArenas = arenas;
			activeArena = staticArenas[arenaIndex];
			arenaIndex++;

			pauseCanvas = _pauseCanvas;
			quitGameButton = _quitGameButton;
			quitGameButton.onClick.AddListener(Quit);
			timeSlider = pauseCanvas.GetComponentInChildren<AdjustTimeScale>();

			optionsCanvas = _optionsCanvas;

		}

		private void Start()
		{
			StartCoroutine(FadeIntoView());
		}

		private IEnumerator FadeIntoView()
		{
			float t = 2f;

			Color col = instructionsText.color; // white transparent

			// fade instruction text into view
			for (float i = 0f; i < 1f; i += Time.deltaTime / t)
			{
				col.a += Time.deltaTime / t;
				instructionsText.color = col;
				yield return null;
			}

			// hold the text for 2 seconds, then begin fading out the text and black screen
			yield return new WaitForSeconds(2);

			Color secondCol = fadein.GetComponent<Image>().color;
			t = 3f;

			// fade out black title card
			for (float i = 0f; i < 1f; i += Time.deltaTime / t)
			{
				col.a -= Time.deltaTime / t;
				secondCol.a -= Time.deltaTime / t;
				instructionsText.color = col;
				fadein.GetComponent<Image>().color = secondCol;
				yield return null;
			}
			fadein.SetActive(false);
		}

		public static IEnumerator FadeOutAndQuit()
		{
			player.GetComponent<Control.ControlHandler>().DisableControls();
			player.GetComponentInChildren<PlayerUISetUp>().reticle.SetActive(false);
			fadein.SetActive(true);

			float t = 2f;
			Color col = fadein.GetComponent<Image>().color;
			Color textCol = thanksText.color;

			for (float i = 0f; i < 1f; i += Time.deltaTime / t)
			{
				col.a += Time.deltaTime / t;
				fadein.GetComponent<Image>().color = col;
				yield return null;
			}

			for (float i = 0; i < 1f; i += Time.deltaTime / t)
			{
				textCol.a += Time.deltaTime / t;
				thanksText.color = textCol;
				quitText.color = textCol;
				yield return null;
			}

			yield return new WaitForSeconds(5f);
			Quit();
		}

		private static void Quit()
		{
			Debug.Log("QUIT");
			Application.Quit();
		}

		public static void TakeSnapshot()
		{
			Debug.LogWarning("Taking snapshot");
			snapshot = new Snapshot();
		}

		public static void Pause()
		{
			if (Time.timeScale == 0f) // Unpause
			{
				player.GetComponentInChildren<PlayerUISetUp>().playerUICanvas.enabled = true;

				// Min slider value is 0.1f, time scale will not be set to 0 outside of the pause screen.
				if (newTimeScale > 0 && newTimeScale < 1) Time.timeScale = newTimeScale;
				else Time.timeScale = 1f;

				timeSlider.TimeScaleChanged -= SetTimeScale;
				pauseCanvas.GetComponent<Canvas>().enabled = false;

				EventSystem.current.SetSelectedGameObject(tempSelected);

				Cursor.lockState = tempCursorState;
				Cursor.visible = tempCursorVisibility;
			}
			else // Pause
			{
				player.GetComponentInChildren<PlayerUISetUp>().playerUICanvas.enabled = false;

				Time.timeScale = 0;
				timeSlider.TimeScaleChanged += SetTimeScale;

				pauseCanvas.GetComponent<Canvas>().enabled = true;

				tempSelected = EventSystem.current.currentSelectedGameObject;
				EventSystem.current.SetSelectedGameObject(timeSlider.gameObject);

				tempCursorState = Cursor.lockState;
				tempCursorVisibility = Cursor.visible;
				Cursor.lockState = CursorLockMode.Confined;
				Cursor.visible = true;
			}
		}

		public static void Options()
		{
			Canvas canvas = optionsCanvas.GetComponent<Canvas>();

			if (canvas.enabled == false)
			{
				player.GetComponentInChildren<PlayerUISetUp>().playerUICanvas.enabled = false;
				canvas.enabled = true;

				tempCursorState = Cursor.lockState;
				tempCursorVisibility = Cursor.visible;
				Cursor.lockState = CursorLockMode.Confined;
				Cursor.visible = true;
			}
			else
			{
				player.GetComponentInChildren<PlayerUISetUp>().playerUICanvas.enabled = true;
				canvas.enabled = false;

				Cursor.lockState = tempCursorState;
				Cursor.visible = tempCursorVisibility;
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

		// Minigame state methods:
		public static void EnableSphere()
		{
			tsWaypoint.actor.GetComponent<Rigidbody>().isKinematic = false;
		}

		public static void DisableSphere()
		{
			tsWaypoint.actor.GetComponent<Rigidbody>().isKinematic = true;
		}

		public static bool NextArena()
		{
			return arenaIndex < staticArenas.Count ? true : false;
		}

		public static void SetNextArena()
		{
			activeArena = staticArenas[arenaIndex];
			arenaIndex++;
		}
	}
}