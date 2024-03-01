using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public float bulletSpeed = 5f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            fireBullet();
        }
    }

    void fireBullet(){
        Instantiate(bulletPrefab, transform);
    }
}
