using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour {
    public NavMeshAgent agent;
    [SerializeField] private Waypoint[] waypoints;
    //public Transform target;
    
    public void HandleObjective(string speechInput) {
        if (waypoints[0].wName == speechInput) 
        {
            // probably use a coroutine later so that new incoming speech doesn't wipe out the movement.
            // target = waypoints[0].transform;
            GoToObjective(waypoints[0]);
		}
    }

    private void GoToObjective(Waypoint waypoint) {

        agent.SetDestination(waypoint.transform.position);
        Debug.Log("Destination should be set.");
    }

    /*
    private void FaceDirection() {
        Vector3 direction = (target.position - transform.position.normalized);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
    }
    */
}