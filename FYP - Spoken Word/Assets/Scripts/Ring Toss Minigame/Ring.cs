using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    // Ring identifier, for positioning subsequent rings. - I don't think I need this.
    public int ringNum;

    private bool isActive;  // Active, meaning the ring ready to be fired.
    private bool inPlace; // In Place, meaning the ring that is in the correct position, ready to be fired.
    private bool isLastRing; // Last, meaning there are no more rings queued up after this one.

    IEnumerator currentMoveCoroutine;

    // ParticleSystem and collision variables
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    public Vector3 force = new Vector3(0.0f, 100.0f, -110.0f);
    private float forceMultiplier = 1f;

    private Oscillator2 osc;

	private void Awake()
	{
        osc = GameObject.FindGameObjectWithTag("Force Bar").GetComponent<Oscillator2>();
    }

	public void Initialize(bool active, bool place, bool last)
	{
        isActive = active;
        inPlace = place;
        isLastRing = last;
	}

	// Methods for applying force to the ring. ##############################################################
	void OnParticleCollision(GameObject other)
    {
        forceMultiplier = osc.GetForceMultiplier();
		if (isActive)
		{
            Rigidbody body = GetComponentInChildren<Rigidbody>();
            body.isKinematic = false;
            Vector3 forceApplied = new Vector3(
                force.x + Random.Range(1f, 5f), 
                force.y + Random.Range(1f, 5f), 
                force.z + Random.Range(1f, 2f)
            );
            body.AddTorque(new Vector3(Random.Range(1f, 2f), Random.Range(1f, 2f), Random.Range(1f, 2f)));
            body.AddForce(forceApplied * forceMultiplier);

            isActive = false;
        }
    }

    // Not used in Oscillator2.cs
    public void SetForceMultiplier(float multi)
    {
        forceMultiplier = multi;
    }

    // Methods for moving the next ring into place. #########################################################
    public void PrepareNextRing(Vector3 defaultRingPos)
    {
        // If there is another ring to be fired, start a coroutine for moving that ring into position.
        currentMoveCoroutine = MoveRing(gameObject.transform, defaultRingPos, 8f);
        StartCoroutine(currentMoveCoroutine);
    }

    IEnumerator MoveRing(Transform activeRing, Vector3 destination, float speed)
    {
        isActive = true; // Set the ring as the active ring.

        // Keep moving the ring towards the default position every frame until it reaches it.
        while (activeRing.transform.position != destination)
        {
            activeRing.transform.position =
                Vector3.MoveTowards(activeRing.transform.position, destination, speed * Time.deltaTime);

            yield return null;
        }

        // When it reaches the desired position, set it as in place.
        inPlace = true;
        // Enable the fire button, unpause the force bar oscillation.
        osc.forceButton.enabled = true;
        osc.PlayForceBar();
    }
    
    public bool GetIsActive()
	{
        return isActive;
	}

    public bool GetInPlace()
	{
        return inPlace;
	}

    public bool GetIsLast()
	{
        return isLastRing;
	}
}