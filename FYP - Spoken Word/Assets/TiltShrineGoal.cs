using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltShrineGoal : Goal
{
    public GameObject tiltShrineSetUp;

	void OnTriggerEnter(Collider other)
    {
        Debug.Log("You scored!");
        bonusMultiplier++;
        Score.Instance.IncreaseScore(pointsAwarded);

        gameObject.GetComponent<BoxCollider>().enabled = false;
        tiltShrineSetUp.GetComponent<TiltShrineSetUp>().NextLevel();
    }
}