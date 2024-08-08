using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A single of the player's 4 guns. Handles its own shooting when called by the player
public class WeaponBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject Bullet_BasicGun;
    public Weapon equippedWeapon;
    public bool canFire = true;
    public float xOffset = 0f;
    public float yOffset = 0f;

    [Serializable]
    public class Weapon
    {
        public int id = 0;
        public string name = "Basic Gun";
        public float bulletSpeed = 10f;
        public float fireRate = 0.3f;
        public float bulletDamage = 10f;
        public float bulletStartDistance = 0.5f;
        public string fireFunction = "BasicGun";
    }

    void Start(){
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
    }

    // Functions for firing different kinds of weapons
    public IEnumerator fireWeapon(){
        if(canFire){
            canFire = false;
            switch(equippedWeapon.fireFunction){
                case "BasicGun":
                    // Instantiate new bullet prefab and give it initial velocity
                    GameObject newBullet = Instantiate(Bullet_BasicGun, transform.position + transform.up * equippedWeapon.bulletStartDistance, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * equippedWeapon.bulletSpeed;
                    newBullet.GetComponent<PlayerBullet>().bulletDamage = equippedWeapon.bulletDamage;
                    break;
                default:
                    Debug.LogError("Error: Invalid fireFunction.");
                    break;
            }
            yield return new WaitForSeconds(equippedWeapon.fireRate);
            canFire = true;
        }
    }
}
