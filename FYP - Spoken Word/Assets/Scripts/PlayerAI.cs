using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] private Waypoint[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    /*
    private void HandleObjective() {
        FaceDirection();
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            GoToObjective();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void GoToObjective() {
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceDirection() {
        Vector3 direction = (target.position - transform.position.normalized);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    */
}
