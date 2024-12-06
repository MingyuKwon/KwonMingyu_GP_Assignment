using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletMuzzle;
    public GameObject shootPosition;

    private EnemyAI enemyAI;
    public float fireCoolTimeUnit = 1f;

    private float fireCoolTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        fireCoolTime = fireCoolTimeUnit;
    }

    // Update is called once per frame
    void Update()
    {
        fireCoolTime -= Time.deltaTime;
        fireCoolTime = Mathf.Max(fireCoolTime, 0);

        if(enemyAI)
        {
            if(enemyAI.GetEnemyState() == EEnemyState.Attack)
            {
                NormalBulletDelayUpdate();
            }
        }
    }

    void NormalBulletDelayUpdate()
    {
        if(bulletPrefab == null || shootPosition == null) return;
        if(fireCoolTime > 0) return;

        AudioManager.instance.PlaySound(AudioManager.EAudioType.EAT_EnemyShoot, 1, transform.position);

        GameObject clone = Instantiate(bulletPrefab);
        clone.transform.position = shootPosition.transform.position;
        clone.transform.rotation = shootPosition.transform.rotation;

        if(bulletMuzzle)
        {
            clone = Instantiate(bulletMuzzle);
            clone.transform.position = shootPosition.transform.position;
            clone.transform.rotation = shootPosition.transform.rotation;
        }

        fireCoolTime = fireCoolTimeUnit;

    }
}
