using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.Playables;

public class AgentMovement : MonoBehaviour
{
    // Check if the target set is valid
    public bool CheckTarget(NavMeshAgent agent, Transform target) 
    {
        NavMeshPath path = new NavMeshPath();

        if (agent.CalculatePath(target.position, path)) {
            //agent.isStopped = false;
            //agent.SetDestination(target.position);

            return true;

        } else {

            return false;

            //agent.isStopped = true;
        }
    }
}
