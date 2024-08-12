using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls enemy movement. Constantly move them towards the player with a speed of enemySpeed.

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public float enemySpeed = 2f;

    void Start(){
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
    }

    void FixedUpdate(){
        pointPlayer();
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.fixedDeltaTime);
    }

    // Point the enemy sprite towards the player
    void pointPlayer(){
        transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
    }
}
