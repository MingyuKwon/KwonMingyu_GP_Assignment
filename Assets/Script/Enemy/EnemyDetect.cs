using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    private EnemyAI enemyAI;
    private SphereCollider sphereCollider;

    void Start()
    {
        enemyAI = GetComponentInParent<EnemyAI>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other) {
    
        if(enemyAI)
        {
            enemyAI.targetObject = other.gameObject;
            enemyAI.TryToSetEnemyState(EEnemyState.ChasePlayer);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(enemyAI)
        {
            enemyAI.targetObject = null;
            enemyAI.TryToSetEnemyState(EEnemyState.Idle);
        }
    }

    void Update()
    {
        
    }
}
