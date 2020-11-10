using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

[ExecuteInEditMode]
public class Waypoint : MonoBehaviour {
    public string wName;
    public string description;

	private void Update() {
		gameObject.name = "Objective " + wName;
	}
}