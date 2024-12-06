using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float sampleRadius = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        int randValue = Random.Range(0, 10);
        if(randValue < 7)
        {
            if(enemyPrefab)
            {
                SpawnEnemy(transform.position);
            }
        }

        Destroy(gameObject);
    }


    void SpawnEnemy(Vector3 spawnPosition)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(spawnPosition, out hit, sampleRadius, NavMesh.AllAreas))
        {
            GameObject enemy = Instantiate(enemyPrefab, hit.position, Quaternion.identity);
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();

            if (agent != null)
            {
                Vector3 targetPosition = GameObject.Find("Main Base").transform.position;
                agent.SetDestination(targetPosition);
            }
        }
        else
        {
            Debug.LogWarning("유효한 NavMesh 위치를 찾지 못했습니다.");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
