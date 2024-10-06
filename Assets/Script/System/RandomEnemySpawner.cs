using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int randValue = Random.Range(0, 10);
        if(randValue < 5)
        {
            if(enemyPrefab)
            {
                GameObject clone = Instantiate(enemyPrefab);
                clone.transform.position = transform.position;
                clone.transform.rotation = transform.rotation;
            }
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
