using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyManager : MonoBehaviour
{
    public float lifespan = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        if(lifespan <= 0) return;

        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }

}
