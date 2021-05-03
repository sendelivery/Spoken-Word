using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustSensitivity : MonoBehaviour
{
    private Slider sensSlider;

    private void Awake()
    {
        sensSlider = this.GetComponent<Slider>();
        sensSlider.onValueChanged.AddListener(delegate { UpdateSens(); });
    }

    private void UpdateSens()
	{
        SpokenWord.GameManager.player.GetComponent<Control.ControlHandler>().UpdatePlayerSensitivity(sensSlider.value * 10f);
	}
}
