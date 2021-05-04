using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TargetPlacement : MonoBehaviour
{
    public Terrain terrain;

    // Keep the target, or anything else this script is attached to, stuck onto the terrain.
    void Update()
    {
        PlaceOnTerrain();
    }

    public void PlaceOnTerrain()
	{
        Vector3 currentPos = gameObject.transform.position;
        currentPos.y = terrain.SampleHeight(currentPos);

        gameObject.transform.position = currentPos;
    }
}
