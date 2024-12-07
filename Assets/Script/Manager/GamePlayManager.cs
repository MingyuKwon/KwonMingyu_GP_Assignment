using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; 

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;
    
    float GameLeftTime = 40.0f;
    public int killTargetAmount = 5;

    public UnityEvent EnemyDeathEvent;
    public UnityEvent GameOverEvent;

    public Action<float> NexusHealthUpdateEvent;
    public Action<float> PlayerHealthUpdateEvent;
    public Action<int> TimeAlertEvent;

    private bool bGameEnd = false;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        EnemyDeathEvent.AddListener(EnemyDieCallBack);
        GameOverEvent.AddListener(GameOverCallBack);
    }

    void EnemyDieCallBack()
    {
        killTargetAmount--;
    }

    void GameOverCallBack()
    {
        GameEnd(false);
    }

    void GameEnd(bool bVictory)
    {
        bGameEnd = true;

        if (bVictory)
        {
            SceneManager.LoadScene("VictoryRoom"); 
        }
        else
        {
            SceneManager.LoadScene("LoseRoom");
        }

    }

    void Update()
    {
        if(bGameEnd) return;

        GameLeftTime -= Time.deltaTime;

        TimeAlertEvent.Invoke((int)GameLeftTime);

        if(GameLeftTime <= 0)
        {
            GameEnd(true);
        }
    }
}
