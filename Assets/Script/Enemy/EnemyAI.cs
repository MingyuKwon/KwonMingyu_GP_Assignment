using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyState
{
    Idle,
    MoveToBase,     
    ChasePlayer,      
    Attack,     
    GameEnd      
}

public class EnemyAI : MonoBehaviour
{
    private EEnemyState EnemyState = EEnemyState.Idle;

    public EEnemyState GetEnemyState() {return EnemyState;}
    public GameObject targetObject = null;
    public GameObject MainBase;

    public float AttackRange = 15f;

    public void TryToSetEnemyState(EEnemyState aimEnemyState)
    {
        if(EnemyState == EEnemyState.GameEnd) return;

        EnemyState = aimEnemyState;
    }

    void Start()
    {
        EnemyState = EEnemyState.Idle;
        MainBase = GameObject.Find("Main Base");

    }

    void Update()
    {
        if(targetObject == null) 
        {
            if(MainBase)
            {
                targetObject =  MainBase;
            }else
            {
                EnemyState = EEnemyState.GameEnd;
            }
        }

        if(EnemyState == EEnemyState.GameEnd) 
        {
            return;
        }

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
