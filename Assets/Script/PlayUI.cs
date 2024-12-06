using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    public TextMeshProUGUI FPSShowText;
    public Scrollbar NexusHealth;
    public Scrollbar PlayerHealth;
    public TextMeshProUGUI TimeLeft;

    private bool isPaused = false;

    private void OnDisable() {
        GamePlayManager.instance.NexusHealthUpdateEvent -= UpdateNexusHealth;
        GamePlayManager.instance.TimeAlertEvent -= UpdateLeftTime;
        GamePlayManager.instance.PlayerHealthUpdateEvent -= UpdatePlayerHealth;
    }

    private void Start() {
        GamePlayManager.instance.NexusHealthUpdateEvent += UpdateNexusHealth;
        GamePlayManager.instance.TimeAlertEvent += UpdateLeftTime;
        GamePlayManager.instance.PlayerHealthUpdateEvent += UpdatePlayerHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }


        if(FPSShowText && !isPaused)
        {
            FPSShowText.text = "FPS : " + ((int)(1 / Time.deltaTime)).ToString();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    void UpdateNexusHealth(float healthPercent)
    {
        if(NexusHealth)
        {
            NexusHealth.size = healthPercent;
        }
        
    }

    void UpdatePlayerHealth(float healthPercent)
    {
        if(PlayerHealth)
        {
            PlayerHealth.size = healthPercent;
        }
        
    }

    void UpdateLeftTime(int Time)
    {
        if(TimeLeft)
        {
            TimeLeft.text = "Left Time : " + Time.ToString();
        }
        
    }
}
