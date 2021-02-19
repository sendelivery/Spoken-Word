using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScreenSetUp : MonoBehaviour
{
    public Camera ringTossCamera;

    public Material rtCamMaterial;

    // Start is called before the first frame update
    void Start()
    {
        if (ringTossCamera.targetTexture != null)
		{
            ringTossCamera.targetTexture.Release();
		}
        ringTossCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        rtCamMaterial.mainTexture = ringTossCamera.targetTexture;
    }
}
