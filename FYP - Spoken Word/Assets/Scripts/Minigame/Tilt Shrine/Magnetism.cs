using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    public GameObject sphere;

    private bool _repel = false;
    private ContactPoint c;

	/*private void OnTriggerStay(Collider c)
	{
        Vector3 dir = c.ClosestPointOnBounds(transform.position);
        ApplyMagneticForce(c.gameObject, dir);
	}*/

	private void OnCollisionEnter(Collision collision)
	{
        c = collision.GetContact(0);
        _repel = true;
	}

	private void FixedUpdate()
	{
		if (_repel)
		{
            ApplyMagneticForce();
        }
	}

	private void OnCollisionExit(Collision collision)
	{
        _repel = false;
	}

	/*void OnCollisionEnter(Collision other)
    {
        // Print how many points are colliding with this transform
        Debug.Log("Points colliding: " + other.contacts.Length);

        // Print the normal of the first point in the collision.
        Debug.Log("Normal of the first point: " + other.contacts[0].normal);

        // Draw a different colored ray for every normal in the collision
        foreach (var item in other.contacts)
        {
            Debug.DrawRay(item.point, item.normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
        }
    }*/

	private void ApplyMagneticForce()
    {
        Debug.Log("Entered the outer collision trigger of the wall.");
        Vector3 dir = new Vector3(c.normal.x, 0f, c.normal.z);
        sphere.GetComponent<Rigidbody>().AddForce(-dir * 0.25f, ForceMode.Acceleration);
        /*
        Vector3 rawDirection = transform.position - obj.transform.position;

        float distance = rawDirection.magnitude;
        float distanceScale = Mathf.InverseLerp(range, 0f, distance);
        float attractionStrength = Mathf.Lerp(0f, strength, distanceScale);

        obj.GetComponent<Rigidbody>().AddForce(rawDirection.normalized * attractionStrength * -1, ForceMode.Force);
        */
    }
}
