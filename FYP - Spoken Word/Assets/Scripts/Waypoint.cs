using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

[ExecuteInEditMode]
public class Waypoint : MonoBehaviour {
    
	public string wName;
    public string description;

	public Camera mainCamera;

	public Transform desiredLocation;
	public float acceptableDistance = 1.5f;

	public Transform defaultCameraPostion;

	private bool clicked;
	private bool backOut;

	private void Update() {
		// gameObject.name = "Objective " + wName;

		// If a raycast is sent to the waypoint gameobject, and if that distance is close enough, move the camera into view.
		// TODO: This raycast code should not be in the waypoint script, but for now it can stay
		if (Input.GetButtonDown("Fire1") && clicked == false)
		{
			RaycastHit hit;
			bool hitObjective = Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 100f);
			if (hitObjective && hit.transform.gameObject.GetComponent<Waypoint>() && hit.distance <= acceptableDistance)
			{
				clicked = true;
			}
		}

		if (clicked && Input.GetButtonDown("Fire2"))
		{
			backOut = true;
		}

		// TODO: Doesn't work!!! Camera gets stuck inbetween the original and waypoint position,
		// super weird. Find another solution.
		if (backOut) 
		{
			// Disable player camera control
			MouseLook mouseLook = mainCamera.GetComponent<MouseLook>();
			mouseLook.enabled = false;

			// Rotation
			mainCamera.transform.rotation = Quaternion.Slerp
				(mainCamera.transform.rotation, defaultCameraPostion.transform.rotation, Time.deltaTime * 8f);

			// Translation
			mainCamera.transform.position = Vector3.Lerp
				(mainCamera.transform.position, defaultCameraPostion.transform.position, 8f * Time.deltaTime);

			// Check if reached desired location
			if (mainCamera.transform == defaultCameraPostion.transform)
			{
				clicked = false;
				backOut = false;
				mouseLook.enabled = true;
			}
		}
		if (clicked)
		{
			// Disable player camera control
			MouseLook mouseLook = mainCamera.GetComponent<MouseLook>();
			mouseLook.enabled = false;

			// Rotation
			mainCamera.transform.rotation = Quaternion.Slerp
				(mainCamera.transform.rotation, desiredLocation.rotation, Time.deltaTime * 8f);

			// Translation
			mainCamera.transform.position = Vector3.Lerp
				(mainCamera.transform.position, desiredLocation.position, 8f * Time.deltaTime);

			// Check if reached desired location
			/*if (mainCamera.transform.position == desiredLocation.position)
			{
				clicked = false;
				mouseLook.enabled = true;
			}*/
		}
	}

	public IEnumerator MoveCamToView()
	{
		print("just entered the move cam to view");
		// Keep moving the ring towards the default position every frame until it reaches it.
		while (mainCamera.transform.position != desiredLocation.position)
		{
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, desiredLocation.position, 8f * Time.deltaTime);

			yield return null;
		}
		print("not in the while");
	}
}