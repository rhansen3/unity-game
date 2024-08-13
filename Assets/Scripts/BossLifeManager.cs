using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tells the level manager when the boss has died to prevent respawning

public class BossLifeManager : EnemyLifeManager
{
    public override void enemyDeath(){
        playerScore.addScore(enemyDeathScore);
        levelManager.addLevelPoints(levelPointsOnDeath);
        levelManager.enemyDict.Remove(enemyDictID);
        levelManager.bossKilled = true;
        levelManager.endLevel(true);
        Destroy(gameObject);
    }
}
