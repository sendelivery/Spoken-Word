using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
// Used when casting a ray to an objective to know which one it is.
public class Waypoint : MonoBehaviour 
{
	// Waypoint name and description, these two are not used too much at the moment.
	[Tooltip("Give each waypoint a unique name, this is how the player will navigate to it using voice control.")]
	public string wName;
    public string description;

	[Header("Buttons")]
	public Button positiveAction = null;
	public Button negativeAction = null;

	[Header("Actors")]
	public GameObject actor = null;
}