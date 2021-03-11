using IBM.Watson.Assistant.V1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    public class VoiceCommands : MonoBehaviour
    {
        private static VoiceCommands _instance;

        private GameObject player;
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
                player = GameObject.Find("Player w Pathfind");
                target = GameObject.FindGameObjectWithTag("Target").transform;
            }
        }

        public void Move(List<RuntimeEntity> incomingEntities, string inputText)
		{
            string direction = "forward";
            float distance = 5f;

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
                    distance = float.Parse(temp);
                }
            }

            switch (direction)
            {
                case "forward":
                    Debug.Log("Forward, Move " + direction + "by "  + distance);
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

		private void SetTarget(Vector3 direction, float distance)
		{
            // place the target by distance:
            target.position = player.transform.position + player.transform.TransformDirection(direction * distance);

            player.GetComponent<ControlHandler>().target = target;
		}

        public void Look(List<RuntimeEntity> incomingEntities, string inputText)
        {
            string direction = "";
            float angle = 45f;
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

                foreach (var item in incomingEntities[i].Location)
				{
                    Debug.Log(item);
				}
            }

            switch (direction)
            {
                case "above":
                    Debug.Log("Up, Look " + direction + " " + angle);
                    StartCoroutine(LookTo(new Vector3(-1, 0, 0), duration, angle));
                    break;
                case "below":
                    Debug.Log("Down, Look " + direction + " " + angle);
                    StartCoroutine(LookTo(new Vector3(1, 0, 0), duration, angle));
                    break;
                case "right":
                    Debug.Log("Right, Look " + direction + " " + angle);
                    StartCoroutine(LookTo(new Vector3(0, 1, 0), duration, angle));
                    break;
                case "left":
                    Debug.Log("Left, Look " + direction + " " + angle);
                    StartCoroutine(LookTo(new Vector3(0, -1, 0), duration, angle));
                    break;
            }
        }

        private IEnumerator LookTo(Vector3 direction, float duration, float angle)
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
    }
}