using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public enum EAudioType
    {
        EAT_BackgroundMusic = 0,
        EAT_GameOverMusic = 1,
        EAT_GameClearMusic = 2,
        EAT_EnemyDeath = 3,
        EAT_EnemyShoot = 4,
        EAT_PlayerShoot1 = 5,
        EAT_PlayerShoot2 = 6,
        EAT_BulletSplash = 7,
        EAT_BulletHit = 8,
    }

    public static AudioManager instance = null;

    private AudioSource backgroundAudioSource;


    [SerializeField]
    private List<AudioClip> audioClipList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        GameObject bgmObject = new GameObject("BackgroundMusicSource");
        backgroundAudioSource = bgmObject.AddComponent<AudioSource>();
        backgroundAudioSource.loop = true; 
        bgmObject.transform.parent = this.transform;

        if(SceneManager.GetActiveScene().name == "VictoryRoom")
        {
            PlayBackgroundMusic(2);
        }else if(SceneManager.GetActiveScene().name == "LoseRoom")
        {
            PlayBackgroundMusic(1);
        }else{
            PlayBackgroundMusic(0);
        }
        
    }

    public void PlaySound(EAudioType audioType, float volume, Vector3 location)
    {
        int index = (int)audioType;

        if (index < audioClipList.Count)
        {
            AudioSource.PlayClipAtPoint(audioClipList[index], location, volume);
        }
        
    }

    public void PlayBackgroundMusic(int index)
    {
        if (0 < audioClipList.Count)
        {
            backgroundAudioSource.clip = audioClipList[index];
            backgroundAudioSource.volume = 0.5f;
            backgroundAudioSource.Play();
        }
        
    }

    public void StopBackgroundMusic()
    {
        if (backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Stop();
        }
    }
}
