using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(0.5f, 2f)]
    public float mouseSensitivity = 1;

    public float verticalRange = 75f;
    float cumulativeXAngle = 0f;

    public Transform playerBody;
    public Transform defaultCamPos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HandleInput(Vector2 rotation)
    {
        float x = rotation.x;
        float y = rotation.y;

        // If the new angle is within the vertical range: rotate
        if(cumulativeXAngle + x >= -verticalRange && cumulativeXAngle + x <= verticalRange)
		{
            // Tallying the angle we want to increase by:
            cumulativeXAngle += x;
            transform.Rotate(Vector3.right, x);
            defaultCamPos.Rotate(Vector3.right, x);
        }

        // Else we calculate the difference and rotate by that amount so that we don't exceed the vertical range
        else if (x > 0) // Angle is positive
		{
            float diff = (cumulativeXAngle + x) - verticalRange;
            x -= diff;
            cumulativeXAngle += x;
            transform.Rotate(Vector3.right, x);
            defaultCamPos.Rotate(Vector3.right, x);
        }
        else if (x < 0) // Angle is negative
        {
            float diff = (cumulativeXAngle + x) +verticalRange;
            x -= diff;
            cumulativeXAngle += x;
            transform.Rotate(Vector3.right, x);
            defaultCamPos.Rotate(Vector3.right, x);
        }

        playerBody.Rotate(Vector3.up, y); // Vector3.up is shorthand for (0, 1, 0) then 1 is * by y
    }

    public float GetCumulativeXAngle()
	{
        return cumulativeXAngle;
	}
}
