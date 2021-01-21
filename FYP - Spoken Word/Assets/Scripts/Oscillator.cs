using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This code needs A LOT of refactoring (So does ForceBar.cs and ParticlePhysics.cs), BUT it works :)
public class Oscillator : MonoBehaviour 
{
    public ForceBar forceBar;

    [Tooltip("Controls the speed of one 'cycle' up and down the bar. Higher is faster, lower is slower.")]
    public float period = 1f;

    private const float length = 1f;

	public Button forceButton;
	private bool forceButtonPressed = false;

	public ParticlePhysics ring;
	public ParticleSystem particles;

	void Start() {
		particles.Stop();
		//Calls the TaskOnClick method when you click the Button
		forceButton.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void Update() 
	{
		if (forceButtonPressed) 
		{
			// Stop adjusting the size of the bar, done with this if - DONE
			// Pass the value of the bar to the ParticlePhysics script (as a multiplier value) - DONE
			ring.SetForceMultiplier(forceBar.GetValue());

			// In that script, enable the particle system, 


			// then when particles collide, adjust the force applied to the ring with the force multiplier
			// then set forceButtonPressed to false (after a short pause? - above line).
			forceButtonPressed = false;
		} 
		else 
		{
			AdjustForceBar();
		}
		
	}

	private void AdjustForceBar() {
		// Could use forceBar.getMaxValue() instead of length, but because the rate is the same,
		// the effect on the forceBar is much slower. Using a shorter length and then multiplying by the max value
		// had a more desired default speed.
		float movementFactor = Mathf.PingPong(Time.time * period, length);
		movementFactor = movementFactor * forceBar.GetMaxValue();

		forceBar.MoveForce(movementFactor); // Set the bar value to the movementFactor (0 - forceBar max value)
	}

	void TaskOnClick() {
		//Output this to console when forceButton is clicked.
		forceButtonPressed = true;
		particles.Play();
	}
}
