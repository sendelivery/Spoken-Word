using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpokenWord;
using Control;
using TMPro;

public class TiltShrineSetUp : MonoBehaviour
{
    [SerializeField]
    private GameObject sphere;
    [SerializeField]
    private TextMeshProUGUI completedText;
    [SerializeField]
    private GameObject waypoint;

	private void Awake()
	{
        completedText.enabled = false;
	}

	public void NextLevel()
	{
        if (GameManager.NextArena())
		{
            Debug.Log("Hello");
            // Disable controls
            GameManager.player.GetComponent<ControlHandler>().DisableControls();

            StartCoroutine(MoveSphereOut());

            // Move old arena out, move new one in.
            Vector3 newLocation = GameManager.activeArena.transform.position;
            newLocation += new Vector3(-8f, 0f, 0f);
            StartCoroutine(MoveOut(GameManager.activeArena, newLocation));

            GameManager.SetNextArena();

            newLocation += new Vector3(8f, 0f, 0f);
            StartCoroutine(MoveIn(GameManager.activeArena, newLocation));

            GameManager.player.GetComponent<ControlHandler>().UpdateTiltTranformReference();

            StartCoroutine(WaitThenEnable(3f));
        }
        else
		{
            completedText.enabled = true;
            GameManager.player.GetComponent<ControlHandler>().DisableControls();
            waypoint.GetComponentInChildren<WaypointLight>().MarkComplete();
		}
	}

    private IEnumerator MoveSphereOut()
	{
        float x = 2f;
        sphere.GetComponent<Rigidbody>().isKinematic = true;
        var t = 0f;
        var start = sphere.transform.position;
        var target = start + new Vector3(0f, 3f, 0f);

        while (t < 1)
        {
            t += Time.deltaTime / x;

            if (t > 1) t = 1;

            sphere.transform.position = Vector3.Lerp(sphere.transform.position, target, t);

            yield return null;
        }

        StartCoroutine(MoveSphereIn());
    }

    private IEnumerator MoveSphereIn()
	{
        float x = 1f;
        Vector3 newLocation = sphere.GetComponent<Reset>().startingPos;
        for (var t = 0f; t <= x; t += Time.deltaTime)
        {
            sphere.transform.position = Vector3.Lerp(sphere.transform.position, newLocation, t / x);
            yield return null;
        }
        sphere.GetComponent<Rigidbody>().isKinematic = false;
    }

    private IEnumerator MoveOut(GameObject activeArena, Vector3 newLocation)
	{
        float x = 10f;
        for (var t = 0f; t <= x; t += Time.deltaTime)
        {
            activeArena.transform.position = Vector3.Lerp(activeArena.transform.position, newLocation, t / x);
            yield return null;
        }
    }

    private IEnumerator MoveIn(GameObject activeArena, Vector3 newLocation)
	{
        float x = 10f;
        for (var t = 0f; t <= x; t += Time.deltaTime)
        {
            activeArena.transform.position = Vector3.Lerp(activeArena.transform.position, newLocation, t / x);
            yield return null;
        }
    }

    private IEnumerator WaitThenEnable(float seconds)
	{
        yield return new WaitForSeconds(seconds);

        GameManager.player.GetComponent<ControlHandler>().EnableControls();
    }
}
