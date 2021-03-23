using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oscillator2 : MonoBehaviour
{
    private RingTossSetUp ringTossSetUp;

    public Slider forceBar;
    public Button forceButton;

    [Tooltip("Controls the speed of one 'cycle' up and down the bar. Higher is faster, lower is slower.")]
    public float period = 1f;

    [Tooltip("Scales the raw 0-1 value of the slider by this factor.")]
    public float scaleFactor = 5f;

    private float multiplier;
    private bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        // Give the oscillator a reference to the ring toss setup class, this is so the particle sys can be played on button click.
        ringTossSetUp = GameObject.FindGameObjectWithTag("RingTossArena").GetComponent<RingTossSetUp>();

        //Calls the TaskOnClick method when you click the Button
        forceButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            AdjustForceBar();
        }
    }

    public float GetForceMultiplier()
	{
        return multiplier;
	}

    public void PlayForceBar()
	{
        pause = false;
	}

    public void PauseForceBar()
	{
        pause = true;
	}

    private void AdjustForceBar()
    {
        // Could use forceBar.getMaxValue() instead of a length of 1f, but because the rate is the same,
        // the effect on the forceBar is much slower. Using a shorter length and then multiplying by the
        // max value had a more desired default speed.
        float movementFactor = Mathf.PingPong(Time.time * period, 1f);
        movementFactor = movementFactor * forceBar.maxValue;

        forceBar.value = movementFactor; // Set the bar value to the movementFactor (0 - forceBar max value)
    }

    public void SetValue(float val)
	{
        forceBar.value = val;
	}

    public float GetValue()
	{
        return forceBar.value;
	}

    public float GetMaxValue()
	{
        return forceBar.maxValue;
	}

    void TaskOnClick()
    {
        // On button click, pause the force bar oscillation, set the multiplier value, play the bubbles particle system.
        PauseForceBar();
        multiplier = forceBar.value * scaleFactor;
        ringTossSetUp.bubbles.Play();

        // Finally, disable the fire button.
        forceButton.enabled = false;
    }
}
