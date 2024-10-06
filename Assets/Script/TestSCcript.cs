using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSCcript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shootPosition;

    public float speed = 0.1f;
    public float currentHealth = 50;
    public float MaxHealth = 100;
    public float Offence = 20;
    public float Defence = 50;


    public float mouseSensitivility = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { transform.Translate(0, 0, speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(0, 0, -speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.E)) { transform.Translate(0, speed * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.Q)) { transform.Translate(0, -speed * Time.deltaTime, 0); }

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * mouseSensitivility * Time.deltaTime, 0);


        if (Input.GetKey(KeyCode.Mouse0)) {
            GameObject clone = Instantiate(bulletPrefab);
            clone.transform.position = shootPosition.transform.position;
            clone.transform.rotation = shootPosition.transform.rotation;

        }

    }
}
