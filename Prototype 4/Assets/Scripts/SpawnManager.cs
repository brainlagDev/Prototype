using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9.0f;
    public int amountOfEnemies;
    public int wave = 1;
    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerUpPrefab, SpawnEnemy(), powerUpPrefab.transform.rotation);
        SpawnEnemyWave(wave);
    }

    private void SpawnEnemyWave(int enemies)
    {
        for(int i = 0; i < enemies; i++)
        {
            Instantiate(enemyPrefab, SpawnEnemy(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        amountOfEnemies = FindObjectsOfType<EnemyBehavior>().Length;
        if(amountOfEnemies == 0)
        {
            Instantiate(powerUpPrefab, SpawnEnemy(), powerUpPrefab.transform.rotation);
            wave++;
            SpawnEnemyWave(wave);
        }
    }
    private Vector3 SpawnEnemy()
    {
        var xPos = Random.Range(-spawnRange, spawnRange);
        var zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(xPos, 0, zPos);
        return randomPos;
    }
}
