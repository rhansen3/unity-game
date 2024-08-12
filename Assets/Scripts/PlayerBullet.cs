using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls behavior of the player's bullets. Adds score when hitting an enemy, destroys bullets if they live for a certain amount of time, 
// and despawns bullet if they hit an enemy.

public class PlayerBullet : MonoBehaviour
{

    private float timeAlive = 0f;
    public float maxSeconds = 5f;
    public PlayerScore playerScore;
    public float bulletScore = 10f;
    public float bulletDamage = 10f;

    void Start(){
        if(playerScore == null){
            playerScore = GameObject.FindWithTag("Player").GetComponent<PlayerScore>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if(timeAlive >= maxSeconds){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<EnemyLifeManager>().takeDamage(bulletDamage);
            playerScore.addScore(bulletScore);
            Destroy(gameObject);
        }
    }

}
