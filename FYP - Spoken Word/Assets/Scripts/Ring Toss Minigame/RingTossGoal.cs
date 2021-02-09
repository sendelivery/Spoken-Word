using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossGoal : Goal
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You scored!");
        bonusMultiplier++;
        Score.Instance.IncreaseScore(pointsAwarded);
    }
}
