using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyState
{
    Idle,
    MoveToBase,     
    ChasePlayer,      
    Attack,     
    Dead      
}

public class EnemyAI : MonoBehaviour
{
    private EEnemyState EnemyState = EEnemyState.Idle;

    public EEnemyState GetEnemyState() {return EnemyState;}
    public GameObject targetObject = null;

    public float AttackRange = 15f;

    public void TryToSetEnemyState(EEnemyState aimEnemyState)
    {
        if(EnemyState == EEnemyState.Dead) return;

        EnemyState = aimEnemyState;
    }

    void Start()
    {
        EnemyState = EEnemyState.Idle;
    }

    void Update()
    {
        if(targetObject == null) return;
        if(transform.childCount < 1) return;
        float Distance = Vector3.Distance(targetObject.transform.position, transform.GetChild(0).transform.position);

        if(Distance <= AttackRange)
        {
            if(EnemyState == EEnemyState.MoveToBase || EnemyState == EEnemyState.ChasePlayer)
            {
                TryToSetEnemyState(EEnemyState.Attack); 
            }
        }
    }
}
