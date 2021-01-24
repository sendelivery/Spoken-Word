using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This code needs A LOT of refactoring (So does ForceBar.cs and ParticlePhysics.cs), BUT it works :)
public class Oscillator : MonoBehaviour 
{
	private RingTossSetUp ringTossSetUp;
    public Slider forceBar;

    [Tooltip("Controls the speed of one 'cycle' up and down the bar. Higher is faster, lower is slower.")]
    public float period = 1f;

	public Button forceButton;
	private bool forceButtonPressed = false;

	Ring activeRing;

	IEnumerator currentMoveCoroutine;

	void Start() {
		ringTossSetUp = GameObject.FindGameObjectWithTag("RingTossArena").GetComponent<RingTossSetUp>();
		activeRing = ringTossSetUp.GetActiveRing();
		//Calls the TaskOnClick method when you click the Button
		forceButton.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void Update() 
	{
		if(forceButtonPressed) // If the button has been pressed, stops adjusting the size of the force bar.
		{
			if(activeRing) // If there is a ring that can be fired:
			{
				forceButton.enabled = false; // Disable the force button.
				FireRing(); // Fire the ring

				// After firing a ring, we have to wait for the next ring to be put in place if there is one, then get it.
				activeRing = ringTossSetUp.GetActiveRing();
				forceButton.enabled = true;
				forceButtonPressed = false;
			}
			else 
			{
				print("All rings have been fired.");
			}
		} 
		else // else if(activeRing.moving == false) If activering is moving, keep the force bar paused and button inactive.
		{
			AdjustForceBar();
		}
	}

	private IEnumerator GetNextRing()
	{
		yield return new WaitForSeconds(3); // Wait 3 seconds then get the next ring.
		
	}

	private void FireRing()
	{
		// Pass the value of the bar to the active ring's Ring script (as a multiplier value)
		activeRing.SetForceMultiplier(forceBar.value);

		// Enable the particle system 
		ringTossSetUp.bubbles.Play();
	}

	private void AdjustForceBar() {
		// Could use forceBar.getMaxValue() instead of a length of 1f, but because the rate is the same,
		// the effect on the forceBar is much slower. Using a shorter length and then multiplying by the max value
		// had a more desired default speed.
		float movementFactor = Mathf.PingPong(Time.time * period, 1f);
		movementFactor = movementFactor * forceBar.maxValue;
		
		forceBar.value = movementFactor; // Set the bar value to the movementFactor (0 - forceBar max value)
	}

	// Do this when the force button is clicked.
	void TaskOnClick() {
		// if(activeRing.moving == false) if active ring is moving, keep the button disabled.
		forceButtonPressed = true;
	}
}