using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private GameObject pauseCanvas;
    public static void Pause()
	{
		GameObject pauseCanvas = GameObject.FindGameObjectWithTag("Pause Canvas");

		if (Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			pauseCanvas.SetActive(false);
		} 
		else
		{
			Time.timeScale = 0;
			pauseCanvas.SetActive(true);
		}
	}
}
