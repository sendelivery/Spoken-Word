using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridSnap : MonoBehaviour
{
    [SerializeField]
    float increment = 0.5f;
    [SerializeField]
    bool snapY = true;

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = (float)Math.Round(transform.position.x * 2, MidpointRounding.AwayFromZero) / 2;
        snapPos.z = (float)Math.Round(transform.position.z * 2, MidpointRounding.AwayFromZero) / 2;

        if (snapY)
		{
            transform.position = new Vector3(snapPos.x, -0.5f, snapPos.z);
        }
        else
		{
            snapPos.y = transform.position.y;
            transform.position = new Vector3(snapPos.x, snapPos.y, snapPos.z);
        }
    }
}
