using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemy : MonoBehaviour
{
    //public GameObject theEnemy;
    //public float xPos;
    //public float zPos;
    //public int enemyCount;

    //private void Start()
    //{
    //    StartCoroutine(EnemyDrop());
    //}
    //IEnumerator EnemyDrop()
    //{
    //    if (enemyCount == 0)
    //    {
    //        while (enemyCount < 1)
    //        {
    //            xPos = Random.Range(4.2f, 4.808f);
    //            zPos = Random.Range(-29f, -29.192f);
    //            Instantiate(theEnemy, new Vector3(xPos, 1.17f, zPos), Quaternion.identity);

    //            yield return new WaitForSeconds(0.1f);
    //            enemyCount += 1;
    //        }
    //    }
    //}
    ////private void OnTriggerEnter(Collider other)
    ////{
    ////    if(other.CompareTag("Player"))
    ////    {

    ////    }
    ////}
    ///
    //public GameObject enemyPrefab;
    //public Transform[] spawnPoints;

    //void Start()
    //{
    //    SpawnEnemies();
    //}

    //void SpawnEnemies()
    //{
    //    foreach (Transform spawnPoint in spawnPoints)
    //    {
    //        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    //        NavMeshAgent navMeshAgent = enemy.GetComponent<NavMeshAgent>();
    //        if (navMeshAgent != null)
    //        {
    //            // Set a random destination on the NavMesh for each enemy
    //            Vector3 randomPoint = GetRandomPointOnNavMesh();
    //            navMeshAgent.SetDestination(randomPoint);
    //        }
    //    }
    //}

    //Vector3 GetRandomPointOnNavMesh()
    //{
    //    NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
    //    int t = Random.Range(0, navMeshData.indices.Length - 3);
    //    Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
    //    point = Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);
    //    return point;
    //}


    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public int waveCount = 5;
    public float spawnInterval = 2f;
    public float timeBetweenWaves = 10f;

    private int currentWave = 0;
    private float timer = 0f;
    private bool isSpawning = false;

    void Start()
    {
        // Start spawning waves
        StartNextWave();
    }

    void Update()
    {
        if (isSpawning)
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnEnemy1();
                timer = 0f;
            }
        }
    }

    void SpawnEnemy1()
    {
        // Instantiate the enemy prefab at the spawn point position
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Get the NavMeshAgent component of the enemy
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();

        // Set the destination on the NavMeshAgent to a random point on the NavMesh
        Vector3 randomPoint = GetRandomPointOnNavMesh();
        agent.SetDestination(randomPoint);
    }

    Vector3 GetRandomPointOnNavMesh()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        int randomTriangleIndex = Random.Range(0, navMeshData.indices.Length - 3);
        Vector3 randomPoint = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[randomTriangleIndex]],
                                           navMeshData.vertices[navMeshData.indices[randomTriangleIndex + 1]],
                                           Random.value);
        randomPoint = Vector3.Lerp(randomPoint,
                                   navMeshData.vertices[navMeshData.indices[randomTriangleIndex + 2]],
                                   Random.value);

        return randomPoint;
    }

    void StartNextWave()
    {
        if (currentWave < waveCount)
        {
            currentWave++;
            isSpawning = true;

            // Call the StopSpawning method after timeBetweenWaves seconds
            Invoke("StopSpawning", timeBetweenWaves);
        }
    }

    void StopSpawning()
    {
        isSpawning = false;

        // Start the next wave
        StartNextWave();
    }

}
