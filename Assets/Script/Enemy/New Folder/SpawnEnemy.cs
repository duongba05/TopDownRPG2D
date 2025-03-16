using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefabs;
    private float spawnRange = 11f;
    private int enemyCount = 0;
    private int wave = 1;
    private int maxWave = 10;
    void Start()
    {
        SpawnEnemyWave(wave);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<EnemyAI>(FindObjectsSortMode.None).Length;
        if(enemyCount == 0 && wave <maxWave)
        {
            wave++;
            SpawnEnemyWave(wave);
        }

    }
    private void SpawnEnemyWave(int number)
    {
        for (int i = 0; i < number; i++) 
        {
            Instantiate(prefabs,EnemyPosSpawn(),prefabs.transform.rotation);
        }
    }
    private Vector3 EnemyPosSpawn()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;    
    }
}
