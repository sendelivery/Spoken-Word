using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpokenWord;
using Control;

public class TiltShrineGoal : Goal
{
    public GameObject tiltShrineSetUp;

	void OnTriggerEnter(Collider other)
    {
        Score.Instance.IncreaseScore(pointsAwarded);
        gameObject.GetComponent<BoxCollider>().enabled = false;

        CalculateBonus();

        tiltShrineSetUp.GetComponent<TiltShrineSetUp>().NextLevel();
    }

    private void CalculateBonus()
	{
        // e.g. 779.4....
        float t = GameManager.player.GetComponent<ControlHandler>().GetAndResetTotalTilt();
        int b;

        if (t <= 100) // If the total tilt has been kept below 100, we increase the score by the bonus limit
		{
            b = bonus;
		}
        else // Otherwise, we dampen the tilt change and work out the final bonus
		{
            t *= 0.66f;
            b = Mathf.CeilToInt(t / 10); // 779.4 => 78

            Debug.Log("inverse bonus = " + b);

            // If our bonus limit - the calculated bonus is negative, the bonus for this game is 0
            b = bonus - b < 0 ? 0 : bonus - b;

            Debug.Log("final bonus = " + b);
        }
        
        Score.Instance.IncreaseScore(b);
	}
}