using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject BigbulletPrefab;

    public GameObject shootPosition;
    public float fireDelayUnit = 1;
    public float BigfireDelayUnit = 1.5f;

    float normalfireDelay = 0;
    float BigfireDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normalfireDelay -= Time.deltaTime;
        normalfireDelay = Mathf.Clamp(normalfireDelay, 0, fireDelayUnit);

        BigfireDelay -= Time.deltaTime;
        BigfireDelay = Mathf.Clamp(BigfireDelay, 0, BigfireDelayUnit);

        NormalBulletDelayUpdate();
        BigBulletDelayUpdate();
    }

    void NormalBulletDelayUpdate()
    {
        if(bulletPrefab == null || shootPosition == null) return;
        if(normalfireDelay > 0) return;

        if (Input.GetKey(KeyCode.Mouse0)) {
            GameObject clone = Instantiate(bulletPrefab);
            clone.transform.position = shootPosition.transform.position;
            clone.transform.rotation = shootPosition.transform.rotation;

            normalfireDelay = fireDelayUnit;
        }
    }

    void BigBulletDelayUpdate()
    {
        if(BigbulletPrefab == null || shootPosition == null) return;
        if(BigfireDelay > 0) return;

        if (Input.GetKey(KeyCode.Mouse1)) {
            GameObject clone = Instantiate(BigbulletPrefab);
            clone.transform.position = shootPosition.transform.position;
            clone.transform.rotation = shootPosition.transform.rotation;

            BigfireDelay = BigfireDelayUnit;
        }
    }
}
