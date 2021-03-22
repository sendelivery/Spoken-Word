using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

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
		private static GameObject pauseCanvas;
		//[SerializeField]
		//private AdjustTimeScale _timeSlider;
		private static AdjustTimeScale timeSlider;

		private static float newTimeScale;

		private static GameObject tempSelected;
		private static CursorLockMode tempCursorState;
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
			Debug.Log("Static player = " + player);
			fadein = _fadeIn;
			fadein.GetComponent<Image>().color = new Color(0, 0, 0, 1);

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
			optionsCanvas = _optionsCanvas;

			timeSlider = pauseCanvas.GetComponentInChildren<AdjustTimeScale>();
		}

		private void Start()
		{
			StartCoroutine(FadeIntoView());
		}

		private IEnumerator FadeIntoView()
		{
			float t = 3f;
			Color col = fadein.GetComponent<Image>().color;

			for (float i = 0f; i < 1f; i += Time.deltaTime / t)
			{
				col.a -= Time.deltaTime / t;
				fadein.GetComponent<Image>().color = col;
				yield return null;
			}
			Destroy(fadein);
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

		public static void TakeSnapshot()
		{
			Debug.LogWarning("Taking snapshot");
			snapshot = new Snapshot();
		}

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