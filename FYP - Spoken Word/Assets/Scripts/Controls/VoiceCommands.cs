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

        public IEnumerator Move(List<RuntimeEntity> incomingEntities)
		{
            float timeElapsed = 0f;
            string direction = "";

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
                    while (timeElapsed < 5f)
                    {
                        MoveCharacter(Vector3.forward);
                        timeElapsed += Time.deltaTime;

                        yield return null;
                    }
                    break;
                case "back":
                    Debug.Log("Back, Move " + direction);
                    while (timeElapsed < 5f)
                    {
                        MoveCharacter(Vector3.back);
                        timeElapsed += Time.deltaTime;

                        yield return null;
                    }
                    break;
                case "right":
                    Debug.Log("Right, Move " + direction);
                    while (timeElapsed < 5f)
                    {
                        MoveCharacter(Vector3.right);
                        timeElapsed += Time.deltaTime;

                        yield return null;
                    }
                    break;
                case "left":
                    Debug.Log("Left, Move " + direction);
                    while (timeElapsed < 5f)
                    {
                        MoveCharacter(Vector3.left);
                        timeElapsed += Time.deltaTime;

                        yield return null;
                    }
                    break;
                default:
                    Debug.Log("Default, Move " + direction + ", default = forward");
                    while (timeElapsed < 5f)
                    {
                        MoveCharacter(Vector3.forward);
                        timeElapsed += Time.deltaTime;

                        yield return null; // wait for the next frame
                    }
                    break;
            }
        }

		private void MoveCharacter(Vector3 direction)
		{
			player.GetComponent<CharacterController>().Move(direction * 5f * Time.deltaTime);
		}

        public void Look(List<RuntimeEntity> incomingEntities)
        {
            float duration = 2f;
            string direction = "";

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
                case "above":
                    Debug.Log("Up, Look " + direction);
                    StartCoroutine(LookTo(Vector3.up, duration));
                    break;
                case "below":
                    Debug.Log("Down, Look " + direction);
                    StartCoroutine(LookTo(Vector3.down, duration));
                    break;
                case "right":
                    Debug.Log("Right, Look " + direction);
                    StartCoroutine(LookTo(Vector3.right, duration));
                    break;
                case "left":
                    Debug.Log("Left, Look " + direction);
                    StartCoroutine(LookTo(Vector3.left, duration));
                    break;
            }
        }

        private IEnumerator LookTo(Vector3 direction, float duration)
        {
            var fromAngle = player.transform.rotation;
            var toAngle = Quaternion.Euler(player.transform.eulerAngles + (direction * 90));

            for (var t = 0f; t < 1; t += Time.deltaTime / duration)
            {
                Debug.Log("rotating");
                transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
                yield return null;
            }
        }
    }
}