using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI; 

public class NPCPatrol : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;

    private NavMeshAgent agent;
    private Transform currentTarget;

    private Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = pointA;
        agent.SetDestination(currentTarget.position);
         
        animator = GetComponent<Animator>();   
    }

    void Update()
    {
        if (animator.GetBool("isWalking"))
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                SwitchTarget();
            }
        }
    }

    void SwitchTarget()
    {
        if (currentTarget == pointA)
            currentTarget = pointB;
        else
            currentTarget = pointA;

        agent.SetDestination(currentTarget.position);
    }

    public void ToggleAnimation(string animationName)
    {
        bool animationState = animator.GetBool(animationName);

        animator.SetBool(animationName, !animationState);
    }
}
