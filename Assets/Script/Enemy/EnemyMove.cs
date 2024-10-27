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
        enemyAI = GetComponent<EnemyAI>();

        BasePosition = GameObject.Find("Main Base").transform.position;
        agent = GetComponentInChildren<NavMeshAgent>();
        agent.enabled = true;

        enemyAI.TryToSetEnemyState(EEnemyState.MoveToBase);
    }

    void Update()
    {
        if(agent == null) return;
        
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

        }else if(enemyAI.GetEnemyState() == EEnemyState.Idle)
        {
            agent.isStopped = true;
            enemyAI.TryToSetEnemyState(EEnemyState.MoveToBase);


        }else if(enemyAI.GetEnemyState() == EEnemyState.Attack)
        {
            agent.isStopped = true;

        }


    }
}
