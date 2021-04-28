using IBM.Watson.Assistant.V1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpokenWord;

namespace Control
{
    public class VoiceCommands : MonoBehaviour
    {
        private static VoiceCommands _instance;

        public GameObject player;
        public Camera cam;
        private Transform target;

        public static VoiceCommands Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;

                // Doesn't work in the tilt shrine scene and that's ok :)
                target = GameObject.FindGameObjectWithTag("Target").transform;
            }
        }

        public void Move(List<RuntimeEntity> incomingEntities, string inputText)
		{
            List<string> direction = new List<string>();
            float distance = 5f;
            string objective = "";

            // This for loop and the one in all the other methods could be extracted into it's own function.
            // The only issue is that we set distance and direction in a lot of them so would have to split
            // this block up into two functions.
            for (int i = 0; i < incomingEntities.Count; i++)
            {
                if (incomingEntities[i].Entity == "Direction")
                {
                    direction.Add(incomingEntities[i].Value);
                }
                if (incomingEntities[i].Entity == "Number")
                {
                    int start = (int)incomingEntities[i].Location[0];
                    int end = (int)incomingEntities[i].Location[1];

                    string temp = inputText.Substring(start, (end - start));
                    distance = float.Parse(temp);
                }
                if (incomingEntities[i].Entity == "Waypoint")
				{
                    objective = incomingEntities[i].Value;
                    break;
				}
            }

            if (objective != "")
			{
                Transform waypointTarget;
                switch (objective)
				{
                    case "ring toss":
                        waypointTarget =
                            GameManager.rtWaypoint.GetComponentsInChildren<Transform>()[2];
                        SetTarget(waypointTarget, GameManager.rtWaypoint.transform);
                        break;
                    case "tilt shrine":
                        waypointTarget =
                            GameManager.tsWaypoint.GetComponentsInChildren<Transform>()[2];
                        SetTarget(waypointTarget, GameManager.tsWaypoint.transform);
                        break;
                    case "finish":
                        waypointTarget = GameManager.finishGameCollider.transform;
                        SetTarget(waypointTarget, null);
                        break;
				}
			}
            else
			{
                for (int i = 0; i < direction.Count; i++)
                {
                    // break out of the for loop if i is 2, basically don't move in 3 directions at once
                    if (i == 2) break;

                    switch (direction[i])
                    {
                        case "forward":
                            Debug.Log("Forward, Move " + direction + "by " + distance);
                            SetTarget(Vector3.forward, distance);
                            break;
                        case "back":
                            Debug.Log("Back, Move " + direction + "by " + distance);
                            SetTarget(Vector3.back, distance);
                            break;
                        case "right":
                            Debug.Log("Right, Move " + direction + "by " + distance);
                            SetTarget(Vector3.right, distance);
                            break;
                        case "left":
                            Debug.Log("Left, Move " + direction + "by " + distance);
                            SetTarget(Vector3.left, distance);
                            break;
                        default:
                            Debug.Log("Default, Move " + direction + "by " + distance + ", default = forward");
                            SetTarget(Vector3.forward, distance);
                            break;
                    }
                }
            }
        }

        private void SetTarget(Transform waypointTarget, Transform waypoint)
		{
            target.position = waypointTarget.position;
            ControlHandler c = player.GetComponent<ControlHandler>();
            c.target = target;
            c.targetWaypoint = waypoint;
		}

		private void SetTarget(Vector3 direction, float distance)
		{
            // place the target by distance:
            target.position = player.transform.position + player.transform.TransformDirection(direction * distance);
            Debug.Log("target set in SetTarget(direction, distance)");
            Debug.Log("target = " + target);
            Debug.Log("player = " + player);
            player.GetComponent<ControlHandler>().target = target;
		}

        public void Look(List<RuntimeEntity> incomingEntities, string inputText)
        {
            List<string> direction = new List<string>();
            float angle = 45f;
            float duration = 1f;

            for (int i = 0; i < incomingEntities.Count; i++)
            {
                if (incomingEntities[i].Entity == "Direction")
                {
                    direction.Add(incomingEntities[i].Value);
                }
                if (incomingEntities[i].Entity == "Number")
				{
                    int start = (int)incomingEntities[i].Location[0];
                    int end = (int)incomingEntities[i].Location[1];

                    string temp = inputText.Substring(start, (end - start));

                    try
                    {
                        angle = float.Parse(temp);
                    }
                    catch
					{
                        Debug.Log("Could not extract an angle from the input text, default angle is " + angle);
					}
				}

                //foreach (var item in incomingEntities[i].Location)
				//{
                //    Debug.Log(item);
				//}
            }

            for(int i = 0; i < direction.Count; i++)
			{
                // break out of the for loop if i is 2, basically don't look in 3 directions at once
                if (i == 2) break;

                switch (direction[i])
                {
                    case "above":
                        Debug.Log("Up, Look " + direction + " " + angle);
                        StartCoroutine(LookOnX(new Vector3(-1, 0, 0), duration, angle));
                        break;
                    case "below":
                        Debug.Log("Down, Look " + direction + " " + angle);
                        StartCoroutine(LookOnX(new Vector3(1, 0, 0), duration, angle));
                        break;
                    case "right":
                        Debug.Log("Right, Look " + direction + " " + angle);
                        StartCoroutine(LookOnY(new Vector3(0, 1, 0), duration, angle));
                        break;
                    case "left":
                        Debug.Log("Left, Look " + direction + " " + angle);
                        StartCoroutine(LookOnY(new Vector3(0, -1, 0), duration, angle));
                        break;
                    case "around":
                        Debug.Log("Around, Look " + direction + " " + 180);
                        StartCoroutine(LookOnY(new Vector3(0, -1, 0), duration, 180f));
                        break;
                }
            }
        }

        private IEnumerator LookOnY(Vector3 direction, float duration, float angle)
        {
            Quaternion fromAngle = player.transform.rotation;
            Quaternion toAngle = Quaternion.Euler(player.transform.eulerAngles + (direction * angle));

            for (var t = 0f; t < 1; t += Time.deltaTime / duration)
            {
                Debug.Log("rotating");
                player.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
                yield return null;
            }           
        }

        private IEnumerator LookOnX(Vector3 direction, float duration, float angle)
		{
            MouseLook m = cam.GetComponent<MouseLook>();
            float tempAngle;
            float oldTempAngle = 0f;
            float lerpChange;

            for (var t = 0f; t < 1; t += Time.deltaTime / duration)
            {
                tempAngle = Mathf.Lerp(0, angle, t);
                lerpChange = tempAngle - oldTempAngle;
                m.HandleInput(new Vector2(lerpChange, 0f));
                oldTempAngle = tempAngle;
                yield return null;
            }
        }

        public void TiltShrineRotate(List<RuntimeEntity> incomingEntities, string inputText, Transform camera)
		{
            string direction = "";
            float angle = 90f;
            float duration = 1f;

            for (int i = 0; i < incomingEntities.Count; i++)
			{
                if (incomingEntities[i].Entity == "Direction")
                {
                    direction = incomingEntities[i].Value;
                }
                if (incomingEntities[i].Entity == "Number")
                {
                    int start = (int)incomingEntities[i].Location[0];
                    int end = (int)incomingEntities[i].Location[1];

                    string temp = inputText.Substring(start, (end - start));
                    angle = float.Parse(temp);
                }
            }

            switch (direction)
            {
                case "right":
                    Debug.Log("Right, Look " + direction + " " + angle);
                    StartCoroutine(RotateArena(new Vector3(0f, -1f, 0f), duration, angle, camera));
                    break;
                case "left":
                    Debug.Log("Left, Look " + direction + " " + angle);
                    StartCoroutine(RotateArena(new Vector3(0f, 1f, 0f), duration, angle, camera));
                    break;
            }
        }

        private IEnumerator RotateArena(Vector3 direction, float duration, float targetAngle, Transform camera)
		{
            Quaternion fromAngle = camera.rotation;
            Quaternion toAngle = Quaternion.Euler(camera.eulerAngles + (direction * targetAngle));

            for (float t = 0f; t < 1; t += Time.deltaTime / duration)
            {
                Debug.Log("rotating");
                camera.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
                yield return null;
            }

            camera.rotation = toAngle;
        }

        public void TiltShrineTilt(List<RuntimeEntity> incomingEntities, string inputText, Transform camera)
        {
            List<string> direction = new List<string>();
            string amount = "neutral";
            float angle = 30f;
            float duration = 1f;

            // An acceptable input, for example: "intent:[tilt] to the direction:[left] a amount:[little]"
            for (int i = 0; i < incomingEntities.Count; i++)
            {
                if (incomingEntities[i].Entity == "Direction")
                {
                    direction.Add(incomingEntities[i].Value);
                }
                if (incomingEntities[i].Entity == "Amount")
                {
                    amount = incomingEntities[i].Value;
                }
            }

            if (amount == "small")
                angle = 15f;
            else if (amount == "large")
                angle = 45f;

            for(int i = 0; i < direction.Count; i++)
			{
                // break out of the for loop if i is 3, basically don't tilt in 3 directions at once
                if (i == 3) break;

                switch (direction[i])
                {
                    case "above":
                        Debug.Log("Above, Tilt " + direction + " " + amount);
                        StartCoroutine(TiltArena(camera, camera.right, angle, duration));
                        break;
                    case "forward":
                        Debug.Log("Forward, Tilt " + direction + " " + amount);
                        StartCoroutine(TiltArena(camera, camera.right, angle, duration));
                        break;
                    case "below":
                        Debug.Log("Below, Tilt " + direction + " " + amount);
                        StartCoroutine(TiltArena(camera, -camera.right, angle, duration));
                        break;
                    case "back":
                        Debug.Log("Back, Tilt " + direction + " " + amount);
                        StartCoroutine(TiltArena(camera, -camera.right, angle, duration));
                        break;
                    case "right":
                        Debug.Log("Right, Tilt " + direction + " " + amount);
                        StartCoroutine(TiltArena(camera, -camera.forward, angle, duration));
                        break;
                    case "left":
                        Debug.Log("Left, Tilt " + direction + " " + amount);
                        StartCoroutine(TiltArena(camera, camera.forward, angle, duration));
                        break;
                }
            }
        }

        private IEnumerator TiltArena(Transform relativeTo, Vector3 axis, float targetAngle, float duration)
        {
            Transform temp = GameManager.activeArena.transform;
            float angleChange;

            GameManager.EnableSphere();

            for (float t = 0f; t < 1; t += Time.deltaTime / duration)
            {
                angleChange = targetAngle * Time.deltaTime;
                temp.RotateAround(relativeTo.position, axis, angleChange);
                yield return null;
            }


            //GameManager.activeArena.transform.rotation =
            //        new Quaternion(temp.rotation.x, 0f, temp.rotation.z, temp.rotation.w);
        }

        public void TiltShrineReset(PlayerControls.TiltShrineActions tiltShrine)
		{
			StartCoroutine(ResetArena(tiltShrine));
		}

		private IEnumerator ResetArena(PlayerControls.TiltShrineActions tiltShrine)
		{
            tiltShrine.Disable();
            Transform temp = GameManager.activeArena.transform;
            float duration = 2f;

            Quaternion finalRotation = new Quaternion(0f, 0f, 0f, GameManager.activeArena.transform.rotation.w);

            for (float t = 0f; t < 1; t += Time.deltaTime / duration)
            {
                GameManager.ResetSphereVelocity();
                temp.rotation = Quaternion.Slerp
                (temp.rotation, finalRotation, t);
                yield return null;
            }

            GameManager.activeArena.transform.rotation =
							new Quaternion(0f, 0f, 0f, GameManager.activeArena.transform.rotation.w);
            tiltShrine.Enable();
		}

        // Move this to a helper gameobject or something later on, it should not be here.
        public void DisableActionTemporarily(UnityEngine.InputSystem.InputAction action, float seconds)
        {
            StartCoroutine(DisableActionTemporarilyCoroutine(action, seconds));
        }

        private IEnumerator DisableActionTemporarilyCoroutine(UnityEngine.InputSystem.InputAction action, float seconds)
        {
            action.Disable();
            Debug.Log("disabled fire");
            yield return new WaitForSeconds(seconds);
            action.Enable();
            Debug.Log("enabled fire");
        }
    }
}