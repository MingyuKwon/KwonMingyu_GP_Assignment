using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

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
    public GameObject EnemyStateLight;

    public EEnemyState GetEnemyState() {return EnemyState;}
    public GameObject targetObject = null;
    public GameObject MainBase;

    public float AttackRange = 15f;

    private Light Enemylight;


    public void TryToSetEnemyState(EEnemyState aimEnemyState)
    {
        if(EnemyState == EEnemyState.GameEnd) return;

        EnemyState = aimEnemyState;

        if(Enemylight != null)
        {
            if(GetEnemyState() == EEnemyState.MoveToBase)
            {
                Enemylight.color = Color.gray; 

            }else if(GetEnemyState() == EEnemyState.ChasePlayer)
            {
                Enemylight.color = Color.yellow; 

            }else if(GetEnemyState() == EEnemyState.Idle)
            {
                Enemylight.color = Color.green; 

            }else if(GetEnemyState() == EEnemyState.Attack)
            {
                Enemylight.color = Color.red; 
            }
        }
    }

    void Start()
    {
        EnemyState = EEnemyState.Idle;
        MainBase = GameObject.Find("Main Base");
        Enemylight = EnemyStateLight.GetComponent<Light>();

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
