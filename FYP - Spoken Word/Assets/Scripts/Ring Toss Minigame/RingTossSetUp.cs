using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossSetUp : MonoBehaviour
{
    // Position  and rotation variables
    public Vector3 defaultRingPos;
    public Vector3 nextRingPos;
    public GameObject defPosTest;
    public GameObject nextPosTest;
    public float posOffset = 1f;
    public Vector3 defaultRingRotation;

    public int numberOfRings;
    private List<Ring> rings = new List<Ring>();

    private int ringNum = 0;

    public ParticleSystem bubbles;
    public GameObject forceBar;

    // Start is called before the first frame update,
    // here the specified amount of rings is instantiated and placed in the scene accordingly.
    void Start()
    {
        // Firstly, stop the particles from playing before the fire button is pressed.
        bubbles.Stop();

        // Then calculate and position the rings based on the number of rings specified.
        if(numberOfRings > 0)
		{
            defaultRingPos = defPosTest.transform.position; // THIS IS A TEST
            nextRingPos = nextPosTest.transform.position; // THIS IS A TEST

            Quaternion ringRotation = Quaternion.Euler(defaultRingRotation);
            string name = "Ring ";
            // Instantiate the first ring, then add it to the list.
            rings.Add(RingFactory.CreateRing(defaultRingPos, ringRotation,
                name, true, true, false));

            // Add the specified number of rings to the list following the first one.
            for (int i = 1; i < numberOfRings; ++i)
            {
                if (i == numberOfRings - 1) // Check if we're on the last ring. Add it to the list as the last ring.
                {
                    rings.Add(RingFactory.CreateRing(nextRingPos, ringRotation,
                        name + i.ToString(), false, false, true));
                }
                else // Otherwise instantiate it and add it to the list as a middle ring.
                {
                    rings.Add(RingFactory.CreateRing(nextRingPos, ringRotation,
                        name + i.ToString(), false, false, false));
                    nextRingPos.y += posOffset;
                }
            }
        }
        else
		{
            Debug.Log("Specify a nonzero, positive number of rings you would like to add.");
		}
    }

    private void Update()
    {
        // These if can definitely be shortened somehow...
        // Check if first ring in list is no longer active (just been fired)
        if (rings.Count > 0 && rings[ringNum].GetIsActive() == false && rings[ringNum].GetInPlace() == true)
		{
            rings.Remove(rings[ringNum]); // Remove it from the list of rings

            if (rings.Count > 0 && rings[ringNum] && rings[ringNum].GetInPlace() == false) // Check if the next ring exists and if it's in place
            {
                StartCoroutine(PrepareRing());
            }
        }
	}

	public Ring GetActiveRing()
	{
        for(int i = 0; i < rings.Count; i++)
		{
            if (rings[i].GetIsActive() == true)
                return rings[i];
		}
        return null;
	}

    IEnumerator PrepareRing()
    {
        //yield on a new YieldInstruction that waits for the particles to end.
        yield return new WaitForSeconds(Mathf.Ceil(bubbles.main.duration));

        rings[ringNum].PrepareNextRing(defaultRingPos); // Move that ring in place once the bubbles have finished.
    }
}