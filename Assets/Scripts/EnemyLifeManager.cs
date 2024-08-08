using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour
{

    public float enemyHealth = 100f;
    public float enemyDeathScore = 100f;
    public PlayerScore playerScore;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 100f;
        enemyDeathScore = 100f;
        if(playerScore == null){
            playerScore = GameObject.FindWithTag("Player").GetComponent<PlayerScore>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage){
        enemyHealth -= damage;
        if(enemyHealth <= 0){
            enemyDeath();
        }
    }

    public void enemyDeath(){
        playerScore.addScore(enemyDeathScore);
        Destroy(gameObject);
    }
}
