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
        if(agent == null) return;

        Vector3 targetLocation = Vector3.zero;
        if(enemyAI.GetEnemyState() == EEnemyState.MoveToBase)
        {
            agent.isStopped = false;
            agent.SetDestination(BasePosition);

            targetLocation = BasePosition;

        }else if(enemyAI.GetEnemyState() == EEnemyState.ChasePlayer)
        {
            agent.isStopped = false;
            if(enemyAI.targetObject)
            {
                agent.SetDestination(enemyAI.targetObject.transform.position);
                targetLocation = enemyAI.targetObject.transform.position;

            }

        }else if(enemyAI.GetEnemyState() == EEnemyState.Idle)
        {
            agent.isStopped = true;
            enemyAI.TryToSetEnemyState(EEnemyState.MoveToBase);

            targetLocation = BasePosition;

        }else if(enemyAI.GetEnemyState() == EEnemyState.Attack)
        {
            agent.isStopped = true;
            if(enemyAI.targetObject)
            {
                targetLocation = enemyAI.targetObject.transform.position;
            }
        }

        Vector3 direction = (targetLocation - transform.position).normalized;
        if (direction != Vector3.zero) 
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); 
        }

    }
}
