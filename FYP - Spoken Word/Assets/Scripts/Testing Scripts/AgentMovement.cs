using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.Playables;

public class AgentMovement : MonoBehaviour
{

    NavMeshAgent agent;
    public Camera cam;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshPath path = new NavMeshPath();

        agent.CalculatePath(target.position, path);
        // Debug.Log(path.status);
        if (path.status == NavMeshPathStatus.PathComplete) {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        } else {
            agent.isStopped = true;
        }
    }
}
