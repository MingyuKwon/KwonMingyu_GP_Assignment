using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 10f;

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
        float moveSpeed = speed;

        if (Input.GetKey(KeyCode.W)) { transform.Translate(0, 0, moveSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(0, 0, -moveSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(moveSpeed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(-moveSpeed * Time.deltaTime, 0, 0); }
    }
}
