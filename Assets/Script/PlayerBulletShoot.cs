using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shootPosition;
    public float fireDelayUnit = 1;

    float fireDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireDelay -= Time.deltaTime;
        fireDelay = Mathf.Clamp(fireDelay, 0, fireDelayUnit);

        if(bulletPrefab == null || shootPosition == null) return;
        if(fireDelay > 0) return;

        if (Input.GetKey(KeyCode.Mouse0)) {
            GameObject clone = Instantiate(bulletPrefab);
            clone.transform.position = shootPosition.transform.position;
            clone.transform.rotation = shootPosition.transform.rotation;

            fireDelay = fireDelayUnit;
        }
    }
}
