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
        
    }
}
