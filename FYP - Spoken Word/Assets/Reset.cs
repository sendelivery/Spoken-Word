using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpokenWord;

public class Reset : MonoBehaviour
{
	private Rigidbody rigidbody;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
    {
        if(transform.position.y < -10f)
		{
			rigidbody.velocity = new Vector3(0f, 0f, 0f);
			rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
			transform.position = new Vector3(-2.5f, 0.325f, 0.5f);
            GameManager.activeArena.transform.rotation = 
                new Quaternion(0f, 0f, 0f, GameManager.activeArena.transform.rotation.w);
		}
    }
}
