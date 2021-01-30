using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Waypoint : MonoBehaviour {
    
	// Waypoint name and description, not really used at the moment.
	[Tooltip("Give each waypoint a unique name, this is how the player will navigate to it using voice control.")]
	public string wName;
    public string description;

	[Tooltip("How close the player has to be before they can click on a waypoint.")]
	public float clickDistance = 1.5f;

	// Camera stuff, used to move the camera in and out of position when casting a ray on a waypoint
	Camera mainCamera;
	Transform defaultCameraPostion;
	Transform desiredCameraPosition;

	private bool waypointSelected;
	private bool backOut;

	public Button exitButton;

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

		// Get the player
		player = GameObject.FindGameObjectWithTag("Player");

		//Calls the TaskOnClick method when you click the exit button
		exitButton.onClick.AddListener(TaskOnClick);
	}

	private void Update() {
		// gameObject.name = "Objective " + wName;

		// If a raycast is sent to the waypoint gameobject, and if that distance is close enough, move the camera into view.
		// TODO: This raycast code should not be in the waypoint script, but for now it can stay
		if (Input.GetButtonDown("Fire1") && waypointSelected == false)
		{
			FireRay();
		}

		if (backOut) 
		{
			waypointSelected = false;
			// Grab the player camera control to enable later
			MouseLook mouseLook = mainCamera.GetComponent<MouseLook>();
			//mouseLook.enabled = true;

			// Rotation
			mainCamera.transform.rotation = Quaternion.Slerp
				(mainCamera.transform.rotation, defaultCameraPostion.transform.rotation, Time.deltaTime * 8f);
			print("slerp applied");

			// Translation
			mainCamera.transform.position = Vector3.Lerp
				(mainCamera.transform.position, defaultCameraPostion.transform.position, 8f * Time.deltaTime);

			// Check if reached desired location
			if (mainCamera.transform.position == defaultCameraPostion.transform.position)
			{
				backOut = false;
				player.GetComponent<MovementHandler>().enabled = true;
				mainCamera.GetComponent<MouseLook>().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
		if (waypointSelected)
		{
			// Disable player camera control
			//MouseLook mouseLook = mainCamera.GetComponent<MouseLook>();
			//mouseLook.enabled = false;

			player.GetComponent<MovementHandler>().enabled = false;
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
	}

	private void FireRay()
	{
		// Fire a ray, if it hits a waypoint, start moving the camera towards the waypoint from the next frame.
		RaycastHit hit;
		bool hitObjective = Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 100f);
		if (hitObjective && hit.transform.gameObject.GetComponent<Waypoint>() && hit.distance <= clickDistance)
		{
			waypointSelected = true;
		}
	}

	private void TaskOnClick()
	{
		// Starts moving the camera back towards the original position inside the player on the next frame.
		backOut = true;
	}
}