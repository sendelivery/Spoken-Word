using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpokenWord;

public class FinishGame : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == GameManager.player)
		{
			StartCoroutine(GameManager.FadeOutAndQuit());
		}
	}
}
