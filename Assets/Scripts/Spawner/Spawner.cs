using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;

    ObjectPool pool;
    float timeFromLastSpawn;
    float currentSpawnTime;
    float StartingWaitTime = 2;
    float initialTimeBetweenSpawns = 3;
    float decrementTime = 0.1f;
    float minTime = 0.8f;
    Coroutine spawnerCoroutineReference;

    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        timeFromLastSpawn = StartingWaitTime;
        currentSpawnTime = initialTimeBetweenSpawns;
        spawnerCoroutineReference = StartCoroutine(SpawnCoroutine());
    }

    public void StopSpawner()
    {
        StopCoroutine(spawnerCoroutineReference);
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return null;
            timeFromLastSpawn += Time.deltaTime;
            if (timeFromLastSpawn > currentSpawnTime)
            {
                SpawnEnemy();
                NextSpawnTime();
                timeFromLastSpawn = 0f;
            }
        }
    }
    private void NextSpawnTime()
    {
        if (currentSpawnTime > minTime)
        {
            currentSpawnTime -= decrementTime;
        }
    }

    private void SpawnEnemy()
    {
        GameObject spawnPoint = ChooseRandomSpawnPoint();
        PoolableObject spawnable = (PoolableObject)pool.getNext();
        // TODO remove
        if (spawnable != null && spawnPoint != null)
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

        if (counter == 100)
        {
            return null;
        }

        return element;
    }
}
