using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(0.5f, 2f)]
    public float mouseSensitivity = 1;

    public Transform playerBody;
    public Transform defaultCamPos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HandleInput(Vector2 rotation)
    {
        float x = Mathf.Clamp(rotation.x, -30f, 30f);
        x *= mouseSensitivity;
        float y = rotation.y;
        y *= mouseSensitivity;

        Vector3 eulerAngles = transform.rotation.eulerAngles;
        float targetXAngle = eulerAngles.x + x;

        if (targetXAngle <= 75f) // bottom half check
        {
            transform.Rotate(Vector3.right, x);
            defaultCamPos.Rotate(Vector3.right, x);
        } 
        else if (targetXAngle >= 285f) // top half check
		{
            transform.Rotate(Vector3.right, x);
            defaultCamPos.Rotate(Vector3.right, x);
		}
        else
		{
            // have to check for some arbitrary angle above the lower limit because
            // the angles wrap around, so the upper limit would also evaluate as true here otherwise.
            if (targetXAngle > 75f && targetXAngle < 125f) // lower half
			{
                float temp = targetXAngle - 75f;
                x -= temp;
                transform.Rotate(Vector3.right, x);
                defaultCamPos.Rotate(Vector3.right, x);
            }
            else if (targetXAngle < 285f) // upper half
			{
                float temp = 285 - targetXAngle;
                x += temp;
                transform.Rotate(Vector3.right, x);
                defaultCamPos.Rotate(Vector3.right, x);
            }
		}

        playerBody.Rotate(Vector3.up, y); // Vector3.up is shorthand for (0, 1, 0) then 1 is * by y

    }
}
