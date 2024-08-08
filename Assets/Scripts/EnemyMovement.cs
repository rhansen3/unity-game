using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public float enemyspeed = 0.1f;

    void Start(){
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
    }

    void FixedUpdate(){
        pointPlayer();
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyspeed * Time.fixedDeltaTime);
    }

    // Point the enemy sprite towards the player
    void pointPlayer(){
        transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
    }
}
