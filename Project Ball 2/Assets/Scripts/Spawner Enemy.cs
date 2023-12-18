using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private LevelData LD;
    [SerializeField] private GameObject[] SpawnPoints;
    [SerializeField] private GameObject[] Enemies;


    void Start()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        float randomTimer = UnityEngine.Random.Range(LD.MinTimer, LD.MaxTimer);
        yield return new WaitForSeconds(randomTimer);
        GetRandomSpawnPoint();
        if (LD.CountSpawnedEnemys > 0)
        {
        StartCoroutine(StartTimer());
        }
    }
    
    private void GetRandomSpawnPoint()
    {
        int RandomSpawnPoint = UnityEngine.Random.Range(0, SpawnPoints.Length);
        SpawnEnemy(RandomSpawnPoint);
    }

    public void SpawnEnemy(int NumberSpawnPoint)
    {
        int indexEnemy;
        Vector3 PositionPoint = SpawnPoints[NumberSpawnPoint].transform.position;
        if (LD.maxBigEnemiesInLevel == 0)
        {
            indexEnemy = 0;
        }
        else
        {
            indexEnemy = Random.Range(0, Enemies.Length);
            if (indexEnemy == 1)
            {
                LD.maxBigEnemiesInLevel--;
            }
        }

        Instantiate(Enemies[indexEnemy], PositionPoint, Quaternion.identity);
        LD.EnemySpawned();
    }

    void Update()
    {
        
    }
}
