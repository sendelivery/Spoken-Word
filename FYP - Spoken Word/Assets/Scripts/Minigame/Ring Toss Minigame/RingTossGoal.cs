using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossGoal : Goal
{
    List<Ring> collidedWith;

	private void Start()
	{
        collidedWith = new List<Ring>();
	}

	void OnTriggerEnter(Collider other)
    {
        // If we've already collided with this ring:
        if (collidedWith.Contains(other.gameObject.GetComponent<Ring>()))
		{
            Debug.Log("Collided again with the same ring!");
		}
        else
		{
            collidedWith.Add(other.gameObject.GetComponent<Ring>());

            Debug.Log("You scored!");
            Score.Instance.IncreaseScore(pointsAwarded);
        }
    }

    public void CalculateBonus()
	{
        float tempBonus = collidedWith.Count * bonus * bonusMultiplier;
        int bonusToApply = Mathf.RoundToInt(tempBonus);
        Score.Instance.IncreaseScore(bonusToApply);
	}
}
