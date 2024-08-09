using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A single of the player's 4 guns. Handles its own shooting when called by the player
public class WeaponBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject Bullet_BasicGun;
    public GameObject Bullet_BasicMelee;
    public int equippedWeaponID = -1;
    public bool canFire = true;
    public float xOffset = 0f;
    public float yOffset = 0f;

    [Serializable]
    public class Weapon
    {
        public int id;
        public string name;
        public float bulletSpeed;
        public float fireRate;
        public float bulletDamage;
        public float bulletStartDistance;
        public string fireFunction;
        public float maxSeconds;
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
            GameObject newBullet;
            Weapon equippedWeapon;
            if(equippedWeaponID == -1){
                equippedWeapon = player.GetComponent<PlayerInventoryManager>().weaponList[0];
            } else{
                equippedWeapon = player.GetComponent<PlayerInventoryManager>().weaponList[equippedWeaponID];
            }

            switch(equippedWeapon.fireFunction){
                case "BasicMelee":
                    newBullet = Instantiate(Bullet_BasicMelee, transform.position + transform.up * equippedWeapon.bulletStartDistance, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * equippedWeapon.bulletSpeed;
                    newBullet.GetComponent<PlayerBullet>().bulletDamage = equippedWeapon.bulletDamage;
                    newBullet.GetComponent<PlayerBullet>().maxSeconds = equippedWeapon.maxSeconds;
                    newBullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.up * equippedWeapon.bulletSpeed);
                    break;
                case "BasicGun":
                    newBullet = Instantiate(Bullet_BasicGun, transform.position + transform.up * equippedWeapon.bulletStartDistance, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * equippedWeapon.bulletSpeed;
                    newBullet.GetComponent<PlayerBullet>().bulletDamage = equippedWeapon.bulletDamage;
                    newBullet.GetComponent<PlayerBullet>().maxSeconds = equippedWeapon.maxSeconds;
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
