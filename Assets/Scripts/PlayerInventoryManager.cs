using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

// Controls the list of weapons as well as the inventory of the player. Loads in the weapon list from Assets/Data/Weapons.json 
// and stores them in weaponList.

public class PlayerInventoryManager : MonoBehaviour
{
    // List for storing all weapons. int is the weapon ID
    public List<WeaponBehavior.Weapon> weaponList = new List<WeaponBehavior.Weapon>();

    // List for storing weapons inside inventory. Int is the ID of the weapon in weaponList
    public List<int> inventory = new List<int>();
    
    // Each of the player's 4 guns
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    public GameObject Weapon4;

    void Start(){
        readweaponList();
        Weapon1.GetComponent<WeaponBehavior>().equippedWeaponID =
        Weapon2.GetComponent<WeaponBehavior>().equippedWeaponID =
        Weapon3.GetComponent<WeaponBehavior>().equippedWeaponID =
        Weapon4.GetComponent<WeaponBehavior>().equippedWeaponID = 0;

        //TODO: delete this, for testing inventory
        inventory.Add(1);
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

    public void cycleWeapons(){
        inventory.Add(Weapon1.GetComponent<WeaponBehavior>().equippedWeaponID);
        Weapon1.GetComponent<WeaponBehavior>().equippedWeaponID = Weapon2.GetComponent<WeaponBehavior>().equippedWeaponID;
        Weapon2.GetComponent<WeaponBehavior>().equippedWeaponID = Weapon3.GetComponent<WeaponBehavior>().equippedWeaponID;
        Weapon3.GetComponent<WeaponBehavior>().equippedWeaponID = Weapon4.GetComponent<WeaponBehavior>().equippedWeaponID;
        Weapon4.GetComponent<WeaponBehavior>().equippedWeaponID = inventory.FirstOrDefault();
        inventory.RemoveAt(0);
    }
}