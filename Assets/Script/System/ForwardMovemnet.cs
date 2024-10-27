using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovemnet : MonoBehaviour
{
    public float speed = 40.0f;
    public GameObject HitParticle;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime); 

    }

    private void OnTriggerEnter(Collider other) {
        if (HitParticle) {
            GameObject hitClone = Instantiate(HitParticle, other.ClosestPoint(transform.position), Quaternion.identity);
            hitClone.transform.rotation = Quaternion.LookRotation(transform.position - other.transform.position);
        }
    }
}
