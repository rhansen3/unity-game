using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    private float timeAlive = 0f;
    public float maxSeconds = 20f;
    public float bulletDamage = 10f;
    public PlayerScore playerScore;
    public float bulletScore = 10f;

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

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<EnemyLifeManager>().takeDamage(bulletDamage);
            playerScore.addScore(bulletScore);
            Destroy(gameObject);
        }
    }

}
