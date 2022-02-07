using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;

    ObjectPool pool;
    float timeFromLastSpawn;
    float StartingWaitTime = 2;

    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        timeFromLastSpawn = StartingWaitTime;
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return null;
            timeFromLastSpawn += Time.deltaTime;
            if (timeFromLastSpawn > NextSpawnTime())
            {
                SpawnEnemy();
                timeFromLastSpawn = 0f;
            }
        }
    }
    private float NextSpawnTime()
    {
        // TODO think about the formula in order to get minor ratio depending on the spawned moles
        return 1;
    }

    private void SpawnEnemy()
    {
        GameObject spawnPoint = ChooseRandomSpawnPoint();
        PoolableObject spawnable = (PoolableObject)pool.getNext();
        // TODO remove
        if (spawnable != null)
        {
            spawnable.transform.position = spawnPoint.transform.position;
            spawnPoint.gameObject.GetComponent<SpawnPoint>().spawnable = spawnable;
            spawnable.gameObject.SetActive(true);
        }
    }

    private GameObject ChooseRandomSpawnPoint()
    {
        GameObject element;
        int idx;
        int counter = 0;
        do
        {
            idx = Random.Range(0, spawnPoints.Length);
            element = spawnPoints[idx];
            counter++;
        } while (!element.gameObject.GetComponent<SpawnPoint>().isEmpty && counter < 100);

        return element;
    }
}
