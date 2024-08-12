using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls behavior of enemy bullets. If they hit the player, player takes damage and the enemy bullet is destroyed. 
// If they last for longer than timeAlive, destroy them to keep the game objects clean.

public class EnemyBullet : MonoBehaviour
{
    private float timeAlive = 0f;
    public float maxSeconds = 10f;

    void Start(){
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
        if(other.gameObject.tag == "Player"){
            other.GetComponent<PlayerLifeManager>().loseLife();
            Destroy(gameObject);
        }
    }
}
