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
            }
        }

        public void Move(List<RuntimeEntity> incomingEntities)
		{
            string direction = "";
            float duration = 2f;

            for (int i = 0; i < incomingEntities.Count; i++)
            {
                if (incomingEntities[i].Entity == "Direction")
                {
                    direction = incomingEntities[i].Value;
                    break;
                }
            }

            switch (direction)
            {
                case "forward":
                    Debug.Log("Forward, Move " + direction);
                    StartCoroutine(MoveCharacter(Vector3.forward, duration));
                    break;
                case "back":
                    Debug.Log("Back, Move " + direction);
                    StartCoroutine(MoveCharacter(Vector3.back, duration));
                    break;
                case "right":
                    Debug.Log("Right, Move " + direction);
                    StartCoroutine(MoveCharacter(Vector3.right, duration));
                    break;
                case "left":
                    Debug.Log("Left, Move " + direction);
                    StartCoroutine(MoveCharacter(Vector3.left, duration));
                    break;
                default:
                    Debug.Log("Default, Move " + direction + ", default = forward");
                    StartCoroutine(MoveCharacter(Vector3.forward, duration));
                    break;
            }
        }

		private IEnumerator MoveCharacter(Vector3 direction, float duration)
		{
            float timeElapsed = 0f;

            Vector3 m = player.transform.right * direction.x + player.transform.forward * direction.z;

            while (timeElapsed < duration)
            {

                player.GetComponent<CharacterController>().Move(m * 5f * Time.deltaTime);
                timeElapsed += Time.deltaTime;

                yield return null; // wait for the next frame
            }
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
                if (incomingEntities[i].Entity == "Angle")
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