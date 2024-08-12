using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of the player's ability to fire their weapons and controls firing of each of the 4 weapons

public class PlayerShooting : MonoBehaviour
{
    public bool canFire = true;
    
    // Each of the player's 4 guns
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    public GameObject Weapon4;

    private float weapondelay = 0.05f;

    // Update is called once per frame
    void Update(){
        // Check if player is firing bullets
        if(Input.GetButton("Fire1") && canFire){
            StartCoroutine(fireWeapons());
        }
    }

    // Fires each of the player's weapons
    public IEnumerator fireWeapons(){
        StartCoroutine(Weapon1.GetComponent<WeaponBehavior>().fireWeapon());
        yield return new WaitForSeconds(weapondelay);
        StartCoroutine(Weapon2.GetComponent<WeaponBehavior>().fireWeapon());
        yield return new WaitForSeconds(weapondelay);
        StartCoroutine(Weapon3.GetComponent<WeaponBehavior>().fireWeapon());
        yield return new WaitForSeconds(weapondelay);
        StartCoroutine(Weapon4.GetComponent<WeaponBehavior>().fireWeapon());
        yield return new WaitForSeconds(weapondelay);
    }
}
