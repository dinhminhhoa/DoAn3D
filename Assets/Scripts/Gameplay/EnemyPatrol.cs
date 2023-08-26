using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public Transform[] targetPoint;
    public int currentTarget;
    public float speed;

    private AiAgent agent;

    void Start()
    {

        agent = GetComponent<AiAgent>();
        currentTarget = 0;
    }


    void Update()
    {
        if (currentTarget < targetPoint.Length)
        {
            Debug.Log(currentTarget);
            if (agent.navMeshAgent.remainingDistance <= agent.navMeshAgent.stoppingDistance )
            {
                currentTarget++;
                if (currentTarget >= targetPoint.Length)
                {
                    currentTarget = 0;
                }
            }

            agent.navMeshAgent.SetDestination(targetPoint[currentTarget].position);
        }      
    }

}
