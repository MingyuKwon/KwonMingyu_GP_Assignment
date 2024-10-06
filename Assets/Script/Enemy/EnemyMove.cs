using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int RandomLifeSpanStart = 3;
    public int RandomLifeSpanEnd = 10;
    public float moveSpeed = 5.0f; 

    Vector3 targetposition;
    float targetDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        int lifespan = Random.Range(RandomLifeSpanStart, RandomLifeSpanEnd);
        Destroy(gameObject, lifespan);

        targetposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirectrion = (targetposition - transform.position).normalized;
        transform.Translate(moveDirectrion * moveSpeed * Time.deltaTime);
        targetDistance -= (moveDirectrion * moveSpeed * Time.deltaTime).magnitude;

        if(targetDistance > 0) return;

        float randomX = Random.Range(-5.0f, 5.0f);
        float randomZ = Random.Range(-5.0f, 5.0f);

        targetDistance = Vector3.Distance(targetposition , transform.position);
        targetposition = transform.position + new Vector3(randomX, 0 , randomZ);


    }
}
