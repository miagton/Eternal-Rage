using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject SpawningItem1;
    public GameObject SpawningItem2;
    float SpawningTimer;
    float TimetoSpawn;

    void Start()
    {
        TimetoSpawn = Random.Range(4, 7);
            
        SpawningTimer = TimetoSpawn;
    }


    void Update()
    {
        TimertoSpawn();
        SpawningItem();
    }
    void SpawningItem()
    {
        if (SpawningTimer <= 0)
        {
            int SpawningChance = Random.Range(1, 5);
            if (SpawningChance > 1 && SpawningChance <= 4)
            {
                Instantiate(SpawningItem1, transform.position, Quaternion.identity);
                SpawningTimer = TimetoSpawn;
            }
            else if (SpawningChance == 1)
            {
                Instantiate(SpawningItem2, transform.position, Quaternion.identity);
                SpawningTimer = TimetoSpawn;
            }
        }
       
    }
    void TimertoSpawn()
    {
        SpawningTimer -= Time.deltaTime;
        if (SpawningTimer <= 0)
        {
            SpawningTimer = 0;
        }

    }
}
