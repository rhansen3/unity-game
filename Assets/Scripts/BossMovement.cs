using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows for managing movement behavior of the level boss. Can either follow the player maintaining relative 
// position or stay stationary to attack.

public class BossMovement : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerMovement playerMovement;
    public bool stationary = false;
    private Vector3 positionRelativeToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
        if(rb == null){
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        playerMovement = player.GetComponent<PlayerMovement>();

        stationary = false;
    }
    

    // Just copy the player's movement onto gameObject's Rigidbody2D in order to maintain same relative distance
    void Update()
    {
        if(!stationary){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        if(!stationary){
            rb.MovePosition(rb.position + movement * playerMovement.moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void still(){
        positionRelativeToPlayer = transform.position - player.transform.position;
        stationary = true;
    }

    public void move(){
        transform.position = player.transform.position + positionRelativeToPlayer;
        stationary = false;
    }
}
