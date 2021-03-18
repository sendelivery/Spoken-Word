﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class PlayerUISetUp : MonoBehaviour
{
	public GameObject reticle;
	public Canvas playerUICanvas;
	public Shader reticleShader;

	[Tooltip("How close the player has to be before they can click on a waypoint.")]
	public float clickDistance = 1.5f;

	// Camera stuff, used to move the camera in and out of position when casting a ray on a waypoint
	Camera mainCamera;
	public Transform defaultCameraPostion;
	Transform desiredCameraPosition;

	private bool waypointSelected;
	private bool backOut;

	private Button ExitButton;
	private Button PositiveButton;

	private GameObject player;

	private void Start()
	{
		// Get the cached main camera
		mainCamera = SpokenWord.GameManager.camera;

		// Get the player, used to disable movement and mouse look when necessary
		player = SpokenWord.GameManager.player;

		// Get the exit button, then listen for TaskOnClick
		ExitButton = GameObject.FindGameObjectWithTag("RT Exit").GetComponent<Button>();
		ExitButton.onClick.AddListener(ExitButtonTaskOnClick);
		PositiveButton = GameObject.FindGameObjectWithTag("RT Fire").GetComponent<Button>();
	}

	private void Update()
	{
		// Move the camera into the specified view of the waypoint.
		if (waypointSelected)
		{
			// Disable player control
			mainCamera.GetComponent<MouseLook>().enabled = false;

			// Rotation
			mainCamera.transform.rotation = Quaternion.Slerp
				(mainCamera.transform.rotation, desiredCameraPosition.rotation, Time.deltaTime * 8f);

			// Translation
			mainCamera.transform.position = Vector3.Lerp
				(mainCamera.transform.position, desiredCameraPosition.position, 8f * Time.deltaTime);

			// Zoom
			if (mainCamera.fieldOfView < 70f)
				mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 70f, 8f * Time.deltaTime);

			// Check if reached desired location
			if (mainCamera.transform.position == desiredCameraPosition.position)
			{
				waypointSelected = false;
				EventSystem.current.SetSelectedGameObject(ExitButton.gameObject);
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
				mainCamera.GetComponent<MouseLook>().enabled = true;

				// Set controls back to default controls
				player.GetComponent<Control.ControlHandler>().SwitchStateDefault();
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
			desiredCameraPosition = hit.transform.gameObject.GetComponentsInChildren<Transform>()[1];
				//GameObject.FindGameObjectWithTag("WaypointCamPos").transform;
			waypointSelected = true;
			// TODO: Set the desired camera pos to that of the specific waypoint selected.
			return (true, hit);
		}
		return (false, hit);
	}

	public void ExitButtonTaskOnClick()
	{
		// Starts moving the camera back towards the original position inside the player on the next frame.
		backOut = true;
		EventSystem.current.SetSelectedGameObject(null);
	}

	public void TriggerPositive()
	{
		PositiveButton.onClick.Invoke();
	}
}