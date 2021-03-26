using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpokenWord;

public class Reset : MonoBehaviour
{
	private new Rigidbody rigidbody;
	public Vector3 startingPos;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		startingPos = transform.position;
	}

	// Update is called once per frame
	void Update()
    {
        if(transform.position.y < startingPos.y - 8f)
		{
			ResetPos();
		}
	}

	private void ResetPos()
	{
		rigidbody.velocity = new Vector3(0f, 0f, 0f);
		rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
		transform.position = startingPos;
		GameManager.activeArena.transform.rotation =
			new Quaternion(0f, 0f, 0f, GameManager.activeArena.transform.rotation.w);
		GameManager.DisableSphere();
	}
}
