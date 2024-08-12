using UnityEngine;

// Controls the anchors for player weapon rotation. Points them towards the mouse at all times.

public class GunAnchorRotate : MonoBehaviour
{
    void FixedUpdate(){
        pointMouse();
    }

    // Point the player sprite towards the mouse
    void pointMouse(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
