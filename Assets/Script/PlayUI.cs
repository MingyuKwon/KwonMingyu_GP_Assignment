using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayUI : MonoBehaviour
{
    public TextMeshProUGUI FPSShowText;
    public Scrollbar NexusHealth;
    public Scrollbar PlayerHealth;
    public TextMeshProUGUI TimeLeft;

    public GameObject pauseCanvas;

    private bool isPaused = false;

    private void OnDisable() {
        if(GamePlayManager.instance)
        {
            GamePlayManager.instance.NexusHealthUpdateEvent -= UpdateNexusHealth;
            GamePlayManager.instance.TimeAlertEvent -= UpdateLeftTime;
            GamePlayManager.instance.PlayerHealthUpdateEvent -= UpdatePlayerHealth;
        }
        
    }

    public void Restart()
    {
        TogglePause();
        SceneManager.LoadScene("Assignmnet6");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void Start() {

        if(pauseCanvas)
        {
            pauseCanvas.SetActive(false);
        }
        if(GamePlayManager.instance)
        {
            GamePlayManager.instance.NexusHealthUpdateEvent += UpdateNexusHealth;
            GamePlayManager.instance.TimeAlertEvent += UpdateLeftTime;
            GamePlayManager.instance.PlayerHealthUpdateEvent += UpdatePlayerHealth;
        }
        

        
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
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            isPaused = false;

        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            isPaused = true;
        }

        if(pauseCanvas)
        {
            pauseCanvas.SetActive(isPaused);
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
