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
        if (Input.GetKey(KeyCode.LeftControl)) { rigidbody.velocity = Vector3.zero; return;}

        float moveSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift)) { moveSpeed = moveSpeed * 1.5f;}

        if (Input.GetKey(KeyCode.W)) { rigidbody.AddRelativeForce(0, 0, moveSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { rigidbody.AddRelativeForce(0, 0, -moveSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.D)) { rigidbody.AddRelativeForce(moveSpeed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.A)) { rigidbody.AddRelativeForce(-moveSpeed * Time.deltaTime, 0, 0); }
    }
}
