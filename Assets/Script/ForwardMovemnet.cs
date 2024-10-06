using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovemnet : MonoBehaviour
{
    public float speed = 40.0f;
    public float lifespan = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime); 

    }
}
