using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScreenSetUp : MonoBehaviour
{
    public Camera ringTossCamera;
    public Material rtCamMaterial;

    public Camera tiltShrineCamera;
    public Material tsCamMaterial;

    // Setting up the render texture to render what the assigned camera is viewing.
    void Start()
    {
        if (ringTossCamera.targetTexture != null)
		{
            ringTossCamera.targetTexture.Release();
		}
        ringTossCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        rtCamMaterial.mainTexture = ringTossCamera.targetTexture;

        if (tiltShrineCamera.targetTexture != null)
        {
            tiltShrineCamera.targetTexture.Release();
        }
        tiltShrineCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        tsCamMaterial.mainTexture = tiltShrineCamera.targetTexture;
    }
}
