using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
	public Vector3 force;
	public bool resetVelocity = true;

	// Launch the ball in the specified direction. Set these values in the inspector.
	private void OnTriggerEnter(Collider other)
	{
		if (resetVelocity)
		{
			other.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
			other.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
		}

		other.GetComponent<Rigidbody>().AddForce(force);

		Debug.Log("launching ball!");
	}

}
