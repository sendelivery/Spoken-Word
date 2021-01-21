using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBar : MonoBehaviour
{
	public Slider slider;

	public void SetMaxForce(float force) 
	{
		slider.maxValue = force;
		slider.value = force;
	}

	public void MoveForce(float force) 
	{
		// set the value of the slider to the force the player chose
		slider.value = force;
	}

	public float GetMaxValue() 
	{
		return slider.maxValue;
	}

	public float GetValue() {
		return slider.value;
	}
}
