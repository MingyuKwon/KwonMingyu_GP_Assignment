using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 0.1f;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody == null) return;

        if (Input.GetKey(KeyCode.W)) { rigidbody.AddRelativeForce(0, 0, speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { rigidbody.AddRelativeForce(0, 0, -speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.D)) { rigidbody.AddRelativeForce(speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.A)) { rigidbody.AddRelativeForce(-speed * Time.deltaTime, 0, 0); }
    }
}
