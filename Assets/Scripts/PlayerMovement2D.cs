using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
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
        pointMouse();
    }

    // Point the player sprite towards the mouse
    void pointMouse(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
