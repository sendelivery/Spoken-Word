﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private static DoorOpen _instance;

    public Animator doorOpen;
    public Camera cutseneCam;
    private int completed;
    public GameObject finishCollider;

    public static DoorOpen Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void MarkComplete()
    {
        completed++;
        doorOpen.SetInteger("completedGames", completed);

        if (completed == SpokenWord.GameManager.waypointCount)
		{
            StartCoroutine(OpenDoorCutscene());
		}
    }

    private IEnumerator OpenDoorCutscene()
	{
        // Switch cameras and disable reticle
        SpokenWord.GameManager.player.GetComponentInChildren<PlayerUISetUp>().reticle.SetActive(false);
        SpokenWord.GameManager.camera.enabled = false;
        cutseneCam.enabled = true;

        do // basically just do nothing while the opening animation is playing.
        {
            yield return null;
            // We're actually still in the idle animation state on the first few frames that we're in this loop,
            // so we have to check for the idle or opening animation state here.
        } while (doorOpen.GetCurrentAnimatorStateInfo(0).IsName("Opening") || doorOpen.GetCurrentAnimatorStateInfo(0).IsName("Idle"));

        // Switch back and enable reticle
        SpokenWord.GameManager.player.GetComponentInChildren<PlayerUISetUp>().reticle.SetActive(true);
        cutseneCam.enabled = false;
        SpokenWord.GameManager.camera.enabled = true;

        // Move the collider in front of the door, could do this in the loop above but it doesn't really matter.
        Vector3 start = finishCollider.transform.position;
        Vector3 end = finishCollider.transform.position - new Vector3(-1.75f, 0f, 0f);

        for (float t = 0f; t < 1; t += Time.deltaTime / 1f)
        {
            finishCollider.transform.position = Vector3.Lerp(start, end, t);

            yield return null;
        }
    }
}
