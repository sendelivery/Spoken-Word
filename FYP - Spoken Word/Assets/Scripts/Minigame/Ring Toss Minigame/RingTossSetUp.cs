using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class RingTossSetUp : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI completedText;
    [SerializeField]
    private GameObject waypoint;

    public List<RingTossGoal> ringTossGoals;

    // Position variables
    public GameObject defaultRingPosition;
    public GameObject nextRingPosition;

    private Vector3 defRingPos;
    private Vector3 nextRingPos;

    // Rotation variables
    public float posOffset = 1f;
    public Vector3 defaultRingRotation;

    // Desired number of rings
    public int numberOfRings = 1;
    private List<Ring> rings = new List<Ring>();
    public List<Material> ringMaterials;

    public ParticleSystem bubbles;

    public GameObject fireButton;
    public GameObject exitButton;

    // Start is called before the first frame update, (awake does not work here, resultls in null reference exception)
    // here the specified amount of rings is instantiated and placed in the scene accordingly.

    private void Awake()
    {
        completedText.enabled = false;
    }

    void Start()
    {
        // Firstly, stop the particles from playing before the fire button is pressed.
        bubbles.Stop();

        // Then calculate and position the rings based on the number of rings specified.
        if (numberOfRings > 0)
		{
            defRingPos = defaultRingPosition.transform.position;
            nextRingPos = nextRingPosition.transform.position;

            Quaternion ringRotation = Quaternion.Euler(defaultRingRotation);
            string name = "Ring ";

            System.Random rand = new System.Random();
            int matIndex = rand.Next(0, 4);

            // Instantiate the first ring, then add it to the list.
            rings.Add(RingFactory.CreateRing(defRingPos, ringRotation,
                name, true, true, false, ringMaterials[matIndex]));

            // Add the specified number of rings to the list following the first one.
            for (int i = 1; i < numberOfRings; ++i)
            {
                matIndex = rand.Next(0, 4);

                if (i == numberOfRings - 1) // Check if we're on the last ring. Add it to the list as the last ring.
                {
                    rings.Add(RingFactory.CreateRing(nextRingPos, ringRotation,
                        name + i.ToString(), false, false, true, ringMaterials[matIndex]));
                }
                else // Otherwise instantiate it and add it to the list as a middle ring.
                {
                    rings.Add(RingFactory.CreateRing(nextRingPos, ringRotation,
                        name + i.ToString(), false, false, false, ringMaterials[matIndex]));
                    nextRingPos.y += posOffset;
                }
            }
        }
        else
		{
            Debug.LogWarning("Specify a nonzero, positive number of rings you would like to add.");
		}
    }

    private void Update()
    {
        // These if can definitely be shortened somehow...
        // Check if first ring in list is no longer active (just been fired)
        if (rings.Count > 0 && rings[0].IsActive() == false && rings[0].IsInPlace() == true)
		{
            rings.Remove(rings[0]); // Remove it from the list of rings

            if (rings.Count > 0 && rings[0] && rings[0].IsInPlace() == false) // Check if the next ring exists and if it's in place
            {
                StartCoroutine(PrepareRing());
            } 
            else // If no next ring exists, highlight the exit button.
			{
				StartCoroutine(EndGame());
			}
		}
	}

	private IEnumerator EndGame()
	{
        // Wait 2 seconds so the final ring has time to land somewhere.
        yield return new WaitForSeconds(2);

		completedText.enabled = true;
		ApplyBonus();
		EventSystem.current.SetSelectedGameObject(exitButton);

        // Wait another 2 seconds before marking the game as complete so the open cutscene doesn't feel so sudden.
        yield return new WaitForSeconds(2);
        waypoint.GetComponentInChildren<WaypointLight>().MarkComplete();
    }

	private void ApplyBonus()
	{
        foreach (var goal in ringTossGoals)
		{
            goal.CalculateBonus();
		}
	}

	public Ring GetActiveRing()
	{
        for(int i = 0; i < rings.Count; i++)
		{
            if (rings[i].IsActive() == true)
                return rings[i];
		}
        return null;
	}

    IEnumerator PrepareRing()
    {
        //yield on a new YieldInstruction that waits for the particles to end.
        yield return new WaitForSeconds(Mathf.Ceil(bubbles.main.duration));

        rings[0].PrepareNextRing(defRingPos); // Move that ring in place once the bubbles have finished.
    }
}