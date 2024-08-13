using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Controls the level. Spawns enemies when able to. Controls win and loss screens depending on state of level. Controls victory conditions.

public class LevelManager : MonoBehaviour
{
    public List<GameObject> enemyTypes;
    public bool spawnEnemies = true;
    public float enemySpawnDelay = 5f;
    public GameObject player;
    public Camera mainCamera;
    public float spawnDistanceFromCameraEdge = 10f;
    public UIMenuManager uiMenuManager;
    public bool levelEnded = false;
    public GameObject levelBoss;

    // How many "death points" enemies need to contribute before level ends. Points assigned and managed by enemy objects
    public float levelMaxPoints = 100f;
    public float levelPoints = 0;
    public GameObject winScreen;
    public GameObject lossScreen;

    public ProgressBar levelProgressBar;
    private EnemyLifeManager bossLifeManager;
    private bool bossAlive = false;
    public float bossSpawnDistance = 5f;
    public Dictionary<int, GameObject> enemyDict = new Dictionary<int, GameObject>();
    public int currentEnemyID = 0;
    public float bossSpawnDelay = 1f;
    public bool bossKilled = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if(mainCamera == null){
            mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }

        if(uiMenuManager == null){
            uiMenuManager = GameObject.FindWithTag("UICanvas").GetComponent<UIMenuManager>();
        }

        if(winScreen == null){
            winScreen = GameObject.FindWithTag("WinScreen");
        }

        if(lossScreen == null){
            lossScreen = GameObject.FindWithTag("LossScreen");
        }

        if(levelProgressBar == null){
            levelProgressBar = GameObject.FindWithTag("LevelBar").GetComponent<ProgressBar>();
        }
        levelProgressBar.maxValue = levelMaxPoints;
        levelProgressBar.changeProgressBarVal(levelPoints);
        if(bossLifeManager == null){
            bossLifeManager = levelBoss.GetComponent<EnemyLifeManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnEnemies){
            StartCoroutine(spawnEnemy());
        }
        if(bossAlive && !bossKilled){
            levelProgressBar.changeProgressBarVal(bossLifeManager.enemyHealth);
        }
    }

    // Spawns a random enemy type from the list of enemy types, uniformly random
    public IEnumerator spawnEnemy(){
        spawnEnemies = false;
        // Choose a random enemy from the list of possible enemies
        GameObject enemyToSpawn = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];

        // Find position to spawn using main camera
        Vector2 spawnPos = mainCamera.ViewportToWorldPoint(new Vector2(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f)));
        // Move the object a little away from  the player at new position
        spawnPos = Vector2.MoveTowards(spawnPos, player.transform.position, -spawnDistanceFromCameraEdge);

        // Spawn the enemy a distance away from the player at a random angle
        GameObject newEnemy = Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        newEnemy.GetComponent<EnemyLifeManager>().enemyDictID = enemyDict.Count;
        enemyDict.Add(currentEnemyID, newEnemy);
        currentEnemyID++;
        yield return new WaitForSeconds(enemySpawnDelay);
        if(!bossAlive){
            spawnEnemies = true;
        }
    }

    public IEnumerator spawnBoss(float delay){
        yield return new WaitForSeconds(delay);
        bossAlive = true;
        GameObject newEnemy = Instantiate(levelBoss, player.transform.position + new Vector3(-bossSpawnDistance, 0, 0), Quaternion.identity);
        enemyDict.Add(currentEnemyID, newEnemy);
        currentEnemyID++;
    }

    public void killAllEnemies(){
        foreach(var enemyEntry in enemyDict){
            Destroy(enemyEntry.Value);
        }
    }

    public void addLevelPoints(float points){
        levelPoints += points;
        levelProgressBar.changeProgressBarVal(levelPoints);
        if(levelPoints >= levelMaxPoints){
            spawnEnemies = false;
            killAllEnemies();
            if(!bossKilled && !bossAlive){
                StartCoroutine(spawnBoss(bossSpawnDelay));
            }
        }
    }

    // End the current level. If playerVictory == true, the player playerVictory. If false, player lost
    public void endLevel(bool playerVictory){
        levelEnded = true;
        uiMenuManager.gamePaused = true;
        Time.timeScale = 0;
        player.GetComponent<PlayerShooting>().canFire = false;
        if(playerVictory){
            winScreen.SetActive(true);
        } else{
            lossScreen.SetActive(true);
        }
    }
}
