﻿using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PlayerUISetUp : MonoBehaviour
{
	public Canvas playerUICanvas;
	public Shader reticleShader;

	[Tooltip("How close the player has to be before they can click on a waypoint.")]
	public float clickDistance = 1.5f;

	// Camera stuff, used to move the camera in and out of position when casting a ray on a waypoint
	Camera mainCamera;
	Transform defaultCameraPostion;
	Transform desiredCameraPosition;

	private bool waypointSelected;
	private bool backOut;

	private Button exitButton;

	private GameObject player;

	private void Start()
	{
		// Get the desired camera position within the waypoint and the default camera position within the player game object
		// Small CPU overhead, same with the rest, maybe cache?
		// https://docs.unity3d.com/ScriptReference/Camera-main.html
		// https://docs.unity3d.com/ScriptReference/Caching.html
		mainCamera = Camera.main;
		desiredCameraPosition = GameObject.FindGameObjectWithTag("WaypointCamPos").transform;
		defaultCameraPostion = GameObject.FindGameObjectWithTag("PlayerCamPos").transform;

		// Get the player, used to disable movement and mouse look when necessary
		player = GameObject.FindGameObjectWithTag("Player");

		// Get the exit button, then listen for TaskOnClick
		// TODO tag the rt exit button with RT_Exit
		exitButton = GameObject.FindGameObjectWithTag("RT Exit").GetComponent<UnityEngine.UI.Button>();
		exitButton.onClick.AddListener(TaskOnClick);
	}

	private void Update()
	{
		// Fire ray on fire 1, ray distance is 1.5f
		if (/*Input.GetButtonDown("Fire1") && waypointSelected == false*/false)
		{
			// If a raycast hits a waypoint within 1.5f, set waypointSelected to true.
			FireRay();
		}

		// Move the camera into the specified view of the waypoint.
		if (waypointSelected)
		{
			// Disable player control
			player.GetComponent<Control.ControlHandler>().enabled = false;
			mainCamera.GetComponent<MouseLook>().enabled = false;

			// Rotation
			mainCamera.transform.rotation = Quaternion.Slerp
				(mainCamera.transform.rotation, desiredCameraPosition.rotation, Time.deltaTime * 8f);

			// Translation
			mainCamera.transform.position = Vector3.Lerp
				(mainCamera.transform.position, desiredCameraPosition.position, 8f * Time.deltaTime);

			// Check if reached desired location
			if (mainCamera.transform.position == desiredCameraPosition.position)
			{
				waypointSelected = false;
				Cursor.lockState = CursorLockMode.Confined;
			}
		}

		if (backOut)
		{
			waypointSelected = false;

			// Rotation
			mainCamera.transform.rotation = Quaternion.Slerp
				(mainCamera.transform.rotation, defaultCameraPostion.transform.rotation, Time.deltaTime * 8f);

			// Translation
			mainCamera.transform.position = Vector3.Lerp
				(mainCamera.transform.position, defaultCameraPostion.transform.position, 8f * Time.deltaTime);

			// Check if reached desired location
			if (mainCamera.transform.position == defaultCameraPostion.transform.position)
			{
				// Re-enable player control
				backOut = false;
				player.GetComponent<Control.ControlHandler>().enabled = true;
				mainCamera.GetComponent<MouseLook>().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
		
	}

	public (bool, RaycastHit) FireRay()
	{
		// Fire a ray, if it hits a waypoint, start moving the camera towards the waypoint from the next frame.
		RaycastHit hit;
		bool hitObjective = Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 100f);
		if (hitObjective && hit.transform.gameObject.GetComponent<Waypoint>() && hit.distance <= clickDistance)
		{
			waypointSelected = true;
			// TODO: Set the desired camera pos to that of the specific waypoint selected.
			return (true, hit);
		}
		return (false, hit);
	}

	private void TaskOnClick()
	{
		// Starts moving the camera back towards the original position inside the player on the next frame.
		backOut = true;
	}
}