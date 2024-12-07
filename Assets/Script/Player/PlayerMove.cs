using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 10f;

    private Animator animator;

    float ActionLockTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator == null) return;

        ActionLockTime -= Time.deltaTime;
        ActionLockTime = Mathf.Max(ActionLockTime, 0);
        if(ActionLockTime > 0) return;

        float moveSpeed = speed;

        float yInputValue = 0;
        float xInputValue = 0;

        if (Input.GetKey(KeyCode.W)) { 
            transform.Translate(0, 0, moveSpeed * Time.deltaTime); 
            yInputValue = 1;
            }

        if (Input.GetKey(KeyCode.S)) { 
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime); 
            yInputValue = -1;
            }

        if (Input.GetKey(KeyCode.D)) { 
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0); 
            xInputValue = 1;
            }

        if (Input.GetKey(KeyCode.A)) { 
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0); 
            xInputValue = -1;
            }

        
        animator.SetFloat("xInput", xInputValue);
        animator.SetFloat("yInput", yInputValue);
    }
}
