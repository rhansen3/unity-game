using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public float bulletSpeed = 5f;
    public float fireRate = 0.5f;
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

    IEnumerator fireBullet(){
        // Disable firing to prevent shooting more than once
        canFire = false;
        // Get the position for the bullet to spawn at
        Vector3 newPosition = gameObject.transform.position;
        newPosition += new Vector3(0, bulletStartDistance, 0);
        // Instantiate new bullet prefab and give it initial velocity
        GameObject newBullet = Instantiate(bulletPrefab, newPosition, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
        // Wait fireRate seconds until able to shoot next bullet
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
