using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Waypoint : MonoBehaviour 
{
	// Waypoint name and description, not really used at the moment.
	[Tooltip("Give each waypoint a unique name, this is how the player will navigate to it using voice control.")]
	public string wName;
    public string description;
}