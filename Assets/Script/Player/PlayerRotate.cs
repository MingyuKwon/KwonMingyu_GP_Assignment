using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float mouseSensitivility = 0.1f;

    float ActionLockTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ActionLockTime -= Time.deltaTime;
        ActionLockTime = Mathf.Max(ActionLockTime, 0);
        if(ActionLockTime > 0) return;

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * mouseSensitivility * Time.deltaTime, 0);

    }
}
