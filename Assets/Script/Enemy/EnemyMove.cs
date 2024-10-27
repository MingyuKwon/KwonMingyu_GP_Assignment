using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; 
    private EnemyAI enemyAI;
    private NavMeshAgent agent;
    private Vector3 BasePosition;

    void Start()
    {
        enemyAI = GetComponentInParent<EnemyAI>();

        BasePosition = GameObject.Find("Main Base").transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;

        enemyAI.TryToSetEnemyState(EEnemyState.MoveToBase);
    }

    void Update()
    {
        if(enemyAI.GetEnemyState() == EEnemyState.MoveToBase)
        {
            agent.isStopped = false;
            agent.SetDestination(BasePosition);
        }else if(enemyAI.GetEnemyState() == EEnemyState.ChasePlayer)
        {
            agent.isStopped = false;
            if(enemyAI.targetObject)
            {
                agent.SetDestination(enemyAI.targetObject.transform.position);
            }

        }else
        {
            agent.isStopped = true;

        }


    }
}
