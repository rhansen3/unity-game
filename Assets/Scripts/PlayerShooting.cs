using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public float bulletSpeed = 10f;
    public float fireRate = 0.3f;
    public float bulletStartDistance = 0.5f;
    public GameObject bulletPrefab;
    public bool canFire = true;

    // Update is called once per frame
    void Update(){
        // Check if player is firing bullets
        if(Input.GetButton("Fire1") && canFire){
            StartCoroutine(fireBullet());
        }
    }

    void FixedUpdate(){
        pointMouse();
    }

    // Fires a bullet from the player
    IEnumerator fireBullet(){
        // Disable firing to prevent shooting more than once
        canFire = false;
        // Instantiate new bullet prefab and give it initial velocity
        GameObject newBullet = Instantiate(bulletPrefab, gameObject.transform.position + transform.up * bulletStartDistance, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
        // Wait fireRate seconds until able to shoot next bullet
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    
    // Point the player sprite towards the mouse
    void pointMouse(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
