using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    public GameObject sphere;

    private bool _repel = false;
    private ContactPoint c;

	private void OnCollisionEnter(Collision collision)
	{
        c = collision.GetContact(0);
        _repel = true;
	}

	private void FixedUpdate()
	{
        // If the ball enters the first collider of a wall, repel it.
        // We need this to make sure the ball doesn't clip through walls if it goes too fast or gets stuck in a corner.
		if (_repel)
		{
            ApplyMagneticForce();
        }
	}

	private void OnCollisionExit(Collision collision)
	{
        _repel = false;
	}

	private void ApplyMagneticForce()
    {
        Debug.Log("Entered the outer collision trigger of the wall.");
        Vector3 dir = new Vector3(c.normal.x, 0f, c.normal.z);
        sphere.GetComponent<Rigidbody>().AddForce(-dir * 0.25f, ForceMode.Acceleration);
    }
}
