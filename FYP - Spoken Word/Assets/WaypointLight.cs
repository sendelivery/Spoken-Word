using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointLight : MonoBehaviour
{
    public Material completedMaterial;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, 0.5f);
    }

    public void MarkComplete()
	{
        // Change the light to green, then mark it complete in DoorOpen.cs
        gameObject.GetComponent<Renderer>().material = completedMaterial;
        DoorOpen.Instance.MarkComplete();
	}
}
