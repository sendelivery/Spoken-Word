using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatch : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; } // Use this for initialization
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = false;
    }
}