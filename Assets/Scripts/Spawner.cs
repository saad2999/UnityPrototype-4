using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    float spawnrange = 9.0f;
    public GameObject powerup;
    int EnemyCount = 0;
    int WaveCount = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
        SpawnEnemyWave(WaveCount);
        Instantiate(powerup, GenrateSpawnPosition(), powerup.transform.rotation);
    }
    void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i=0;i<enemyToSpawn;i++)
        {
            Instantiate(EnemyPrefab, GenrateSpawnPosition(), EnemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = FindObjectsOfType<Enemy>().Length;
        if(EnemyCount==0)
        {
            WaveCount++;
            SpawnEnemyWave(WaveCount);
            Instantiate(powerup, GenrateSpawnPosition(), powerup.transform.rotation);
        }
        
    }
    Vector3 GenrateSpawnPosition()
    {
        float spawnX = Random.Range(spawnrange, -spawnrange);
        float spawnZ = Random.Range(spawnrange, -spawnrange);
        Vector3 spawnpos = new Vector3(spawnX, 0, spawnZ);
        return spawnpos;

    }
    
}
