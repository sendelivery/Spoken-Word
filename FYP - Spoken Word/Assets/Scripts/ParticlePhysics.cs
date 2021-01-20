using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePhysics : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    public Vector3 force = new Vector3(0.0f, 100.0f, -100.0f);
    public float multiplier = 1f;

    void OnParticleCollision(GameObject other) {
        Debug.Log("particle collision");
        Rigidbody body = GetComponentInChildren<Rigidbody>();

        body.isKinematic = false;

		body.AddForce(force * multiplier);
    }
}
