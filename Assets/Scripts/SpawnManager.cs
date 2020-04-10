using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private int n = 1;
    private int enemyCount;
    private int powerupCount;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            duplicateEnemy(n++);
            duplicatePowerup();
        }

        

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPostX = Random.Range(-spawnRange, spawnRange);
        float spawnPostZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPostX, 0, spawnPostZ);
    }

    private void duplicateEnemy(int t)
    {
        for(int i=0; i<t; i++)
        {
            Vector3 randomPos = GenerateSpawnPosition();
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
            enemyCount++;
        }
    }

    private void duplicatePowerup()
    {
        Vector3 randomPos = GenerateSpawnPosition();
        Instantiate(powerupPrefab, randomPos, powerupPrefab.transform.rotation);
    }
}
