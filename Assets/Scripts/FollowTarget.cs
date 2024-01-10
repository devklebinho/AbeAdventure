using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    public float enemyLife;

    public Transform[] target;
    public NavMeshAgent agent;
    public int currentTarget;
    public float pursuitRadius;
    public Transform playerReference;
    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
        if(enemyLife > 0)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerReference.position);

            if(distanceToPlayer <= agent.stoppingDistance)
            {
                //Attack();
            }
            else if(distanceToPlayer <= pursuitRadius)
            {
                Pursuit(playerReference);
            }
            else
            {
                Patrol();
            }
        }
        else
        {
            Debug.Log("IH morreu");
        }

    }

    void Attack()
    {
        Debug.Log("Atacando");
    }

    void Pursuit(Transform newTarget)
    {
        agent.SetDestination(newTarget.position);
    }

    void Patrol()
    {
        if(!agent.pathPending && agent.remainingDistance < 1f)
        {
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        if (target.Length == 0)
            return;

        currentTarget += 1;

        if(currentTarget >= target.Length)
            currentTarget = 0;

        agent.SetDestination(target[currentTarget].position);
    }
}