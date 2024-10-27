using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; 

    private NavMeshAgent agent;
    private Vector3 BasePosition;
    Vector3 targetposition;
    float targetDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        targetposition = transform.position;
        BasePosition = GameObject.Find("Main Base").transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;

        
        agent.isStopped = false;
        agent.SetDestination(BasePosition);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 moveDirectrion = (targetposition - transform.position).normalized;
        transform.parent.Translate(moveDirectrion * moveSpeed * Time.deltaTime);
        targetDistance -= (moveDirectrion * moveSpeed * Time.deltaTime).magnitude;

        if(targetDistance > 0) return;

        float randomX = Random.Range(-5.0f, 5.0f);
        float randomZ = Random.Range(-5.0f, 5.0f);

        targetDistance = Vector3.Distance(targetposition , transform.position);
        targetposition = transform.position + new Vector3(randomX, 0 , randomZ);
        */



    }
}
