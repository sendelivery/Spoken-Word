using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingFactory : MonoBehaviour
{
    protected static RingFactory instance;
    public GameObject ring;

	private void Start()
	{
		instance = this;
	}

	public static Ring CreateRing(Vector3 ringPos, Quaternion rotation,
		string name, bool isActive, bool inPlace, bool isLastRing, Material mat)
	{
		GameObject ringObject = Object.Instantiate(instance.ring, ringPos, rotation);
		ringObject.name = name;
		ringObject.GetComponent<Renderer>().material = mat;
		Ring ringScript = ringObject.GetComponentInChildren<Ring>();

		ringScript.Initialize(isActive, inPlace, isLastRing);
		return ringScript;
		// return a ring
	}

	/* Method to return an empty Ring script, never used.
	public static Ring CreateEmptyRing()
	{
		Ring emptyRing = new Ring();
		return emptyRing;
	}
	*/
}