using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    public Transform defaultCamPos;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    public void HandleInput(Vector2 rotation)
    {
        float x = rotation.x; //Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y = rotation.y; //Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(x, -90f, 90f);

        transform.Rotate(Vector3.right, xRotation);
        defaultCamPos.Rotate(Vector3.right, xRotation);

        playerBody.Rotate(Vector3.up, y); // Vector3.up is shorthand for (0, 1, 0) then 1 is * by y

        /*
         * Because a mouse is a continuous kind of movement, where as a controller is a joystick,
         * meaning that you push it up and leave it up if you want to keep moving (or looking) further up
         * the above code is better, transform.Rotate will apply a rotation, so it can be applied over
         * multiple frames. localRotation is better for a mouse because it will SET the rotation, so when
         * you move up a certain distance, that rotation will be set to that distance from the origin point.
         * If we used the below for a controller, the rotation would constantly be set at the value we'd like
         * it to increase by, meaning there would be no to litttle change from frame to frame, creating a
         * jittery kind of effect.
        */

        /*xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        defaultCamPos.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up, x);
        defaultCamPos.Rotate(Vector3.up, x);*/
    }
}
