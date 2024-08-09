using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> enemyTypes;
    private bool spawnEnemies = true;
    public float enemySpawnDelay = 5f;
    public GameObject player;
    public Camera mainCamera;
    public float spawnDistanceFromCameraEdge = 1f;

    // Value should ideally cause enemies to spawn directly off-screen
    private float enemySpawnDistance;

    // Start is called before the first frame update
    void Start()
    {
        if(mainCamera == null){
            mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnEnemies){
            StartCoroutine(spawnEnemy());
        }
    }

    // Spawns a random enemy type from the list of enemy types, uniformly random
    public IEnumerator spawnEnemy(){
        spawnEnemies = false;
        // Choose a random enemy from the list of possible enemies
        GameObject enemyToSpawn = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];

        // Find position to spawn using main camera
        Vector2 spawnPos = mainCamera.ViewportToWorldPoint(new Vector2(UnityEngine.Random.Range(0, 1), UnityEngine.Random.Range(0, 1)));
        // Move the object a little away from  the player at new position
        spawnPos = Vector2.MoveTowards(spawnPos, player.transform.position, -spawnDistanceFromCameraEdge);

        // Spawn the enemy a distance away from the player at a random angle
        GameObject newEnemy = Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(enemySpawnDelay);
        spawnEnemies = true;
    }
}
