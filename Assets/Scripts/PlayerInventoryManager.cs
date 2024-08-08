using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PlayerInventoryManager : MonoBehaviour
{
    // Dictionary for storing all weapons. int is the weapon ID
    List<WeaponBehavior.Weapon> weaponList;
    
    // Each of the player's 4 guns
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    public GameObject Weapon4;

    void Start(){
        readweaponList();
        // TODO: CHANGE THIS TO melee default weapon
        Weapon1.GetComponent<WeaponBehavior>().equippedWeapon = Weapon2.GetComponent<WeaponBehavior>().equippedWeapon = weaponList[0];
        Weapon3.GetComponent<WeaponBehavior>().equippedWeapon = Weapon4.GetComponent<WeaponBehavior>().equippedWeapon = weaponList[1];
    }

    [Serializable]
    private class WeaponListObject{
        public List<WeaponBehavior.Weapon> list;
    }

    // read in the .json list of weapons
    void readweaponList(){
        WeaponListObject weaponListObject = JsonUtility.FromJson<WeaponListObject>(File.ReadAllText(Application.dataPath + "/Data/Weapons.json"));
        weaponList = weaponListObject.list;
    }
}