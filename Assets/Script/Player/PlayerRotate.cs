using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float mouseSensitivility = 100;

    float ActionLockTime = 5;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        ActionLockTime -= Time.deltaTime;
        ActionLockTime = Mathf.Max(ActionLockTime, 0);
    }

    private void FixedUpdate() {
        if(ActionLockTime > 0) return;
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * mouseSensitivility * Time.fixedDeltaTime, 0);

    }
}
