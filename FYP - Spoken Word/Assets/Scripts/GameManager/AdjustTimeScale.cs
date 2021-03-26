using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustTimeScale : MonoBehaviour
{
    public delegate void ChangeTimeScale();
    public event ChangeTimeScale TimeScaleChanged;

    public void SendTimeScaleChangedEvent()
	{
        TimeScaleChanged.Invoke();
	}

    private Slider timeSlider;

	private void Awake()
	{
        timeSlider = this.GetComponent<Slider>();
        timeSlider.onValueChanged.AddListener(delegate { SendTimeScaleChangedEvent(); });
    }
}