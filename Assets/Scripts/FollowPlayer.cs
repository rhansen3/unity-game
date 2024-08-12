using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// gameObject follows the player maintaining their same relative position

public class FollowPlayer : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerMovement playerMovement;

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
    }
    

    // Just copy the player's movement onto gameObject's Rigidbody2D in order to maintain same relative distance
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerMovement.moveSpeed * Time.fixedDeltaTime);
    }
}
