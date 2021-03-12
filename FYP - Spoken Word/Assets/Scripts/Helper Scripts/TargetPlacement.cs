using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TargetPlacement : MonoBehaviour
{
    public Terrain terrain;

    // Update is called once per frame
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
