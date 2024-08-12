using UnityEngine;

// Controls the player's movement.

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // Runs 50 times a second
    void FixedUpdate(){
        // Move and collide RigidBody with current position + direction * movespeed * amount of time since last time function was called (Results in const. move speed)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(movement != Vector2.zero){
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        }
    }
}
