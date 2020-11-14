using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

public class MovementHandler : MonoBehaviour
{
    [Header("User Control Instances")]
    [SerializeField] PlayerController playerController;
    [SerializeField] CharacterController characterController;

    [Header("Agent Control Instances")]
    [SerializeField] AgentMovement agentMovement;
    [SerializeField] NavMeshAgent navMeshAgent;

    public Transform target;
    public float goalRadius = 1f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.enabled == true)
        {
            playerController.HandleInput();
		} else if (playerController.enabled == false && Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetButtonDown("Jump"))
        {
            navMeshAgent.enabled = false;
            target = null; // TODO destroy target

            playerController.enabled = true;
            characterController.enabled = true;
 
            playerController.HandleInput();
        }

        if (target) 
        {
            if (navMeshAgent.enabled == false) navMeshAgent.enabled = true;

            // Checks if the agent can find a valid path to the target
            if (agentMovement.CheckTarget(navMeshAgent, target)) 
            {
                playerController.enabled = false;
                characterController.enabled = false;
                navMeshAgent.SetDestination(target.position);

                float dist = navMeshAgent.remainingDistance;

                // Once the target has been reached, destroy the target, re enable the player controller and disable the agent
                if (dist != Mathf.Infinity && dist != 0 && navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && dist <= goalRadius)
                {
                    target = null; // TODO destroy the target

                    playerController.enabled = true;
                    characterController.enabled = true;

                    navMeshAgent.enabled = false;
                }

			} else {
                navMeshAgent.enabled = false;
                playerController.enabled = true;
                characterController.enabled = true;
            }
        }
    }
}
