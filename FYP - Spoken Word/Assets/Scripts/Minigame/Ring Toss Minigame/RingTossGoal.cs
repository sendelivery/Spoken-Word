using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossGoal : Goal
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You scored!");
        bonusMultiplier++;
        Score.Instance.IncreaseScore(pointsAwarded);
    }
}
