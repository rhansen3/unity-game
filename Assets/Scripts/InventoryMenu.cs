using UnityEngine;
using UnityEngine.UIElements;

// Controls the inventory menu. Prints currently equipped weapons as well as weapons in the inventory. 
// Allows for changing of equipped weapons with ones from the inventory.

public class InventoryMenu : MonoBehaviour
{
    private Button _cycleWeaponsButton;
    private Label _equippedWeapons;
    private Label _inventoryList;
    public PlayerInventoryManager playerInventoryManager;

    //Add logic that interacts with the UI controls in the `OnEnable` methods
    private void OnEnable()
    {
        // The UXML is already instantiated by the UIDocument component
        var uiDocument = GetComponent<UIDocument>();

        _equippedWeapons = uiDocument.rootVisualElement.Q("equippedWeapons") as Label;
        _cycleWeaponsButton = uiDocument.rootVisualElement.Q("cycleWeaponsButton") as Button;
        _inventoryList = uiDocument.rootVisualElement.Q("inventoryList") as Label;
        printWeapons();

        _cycleWeaponsButton.RegisterCallback<ClickEvent>(cycleWeapons);
    }

    private void cycleWeapons(ClickEvent evt)
    {
        playerInventoryManager.cycleWeapons();
        printWeapons();
    }

    // Print the user's equipped and inventory weapons to the UI text
    private void printWeapons(){
        _equippedWeapons.text = "Currently equipped weapons: " 
        + playerInventoryManager.weaponList[playerInventoryManager.Weapon1.GetComponent<WeaponBehavior>().equippedWeaponID].name 
        + ", " + playerInventoryManager.weaponList[playerInventoryManager.Weapon2.GetComponent<WeaponBehavior>().equippedWeaponID].name 
        + ", " + playerInventoryManager.weaponList[playerInventoryManager.Weapon3.GetComponent<WeaponBehavior>().equippedWeaponID].name 
        + ", " + playerInventoryManager.weaponList[playerInventoryManager.Weapon4.GetComponent<WeaponBehavior>().equippedWeaponID].name;

        _inventoryList.text = "Inventory contents:\n";
        foreach(int weaponID in playerInventoryManager.inventory){
            _inventoryList.text += playerInventoryManager.weaponList[weaponID].name + "\n";
        }
    }
}