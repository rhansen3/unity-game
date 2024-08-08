using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
