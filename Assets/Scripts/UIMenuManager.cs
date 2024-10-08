using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls UI menus. If player presses the corresponding buttons, open the inventory or pause menu.

public class UIMenuManager : MonoBehaviour
{

    public bool gamePaused = false;
    public bool pauseMenuOpen = false;
    public bool inventoryMenuOpen = false;
    public GameObject pauseMenu;
    public GameObject inventoryMenu;
    public GameObject player;
    public LevelManager levelManager;

    void Start(){
        pauseMenu.SetActive(false);
        pauseMenuOpen = false;
        inventoryMenu.SetActive(false);
        inventoryMenuOpen = false;

        if(levelManager == null){
            levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        }
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
}

    // Update is called once per frame
    void Update()
    {
        if(!levelManager.levelEnded){
            // Player opens/closes pause menu or closes inventory menu
            if(Input.GetKeyDown(KeyCode.Escape)){
                if(gamePaused){
                    unpauseGame();
                } else{
                    pauseGame();
                }

                if(pauseMenuOpen){
                    pauseMenu.SetActive(false);
                    pauseMenuOpen = false;
                } else if(inventoryMenuOpen){
                    inventoryMenu.SetActive(false);
                    inventoryMenuOpen = false;
                } else{
                    pauseMenu.SetActive(true);
                    pauseMenuOpen = true;
                }
            }

            // Player opens/closes inventory menu
            else if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Tab)){
                if(gamePaused){
                    unpauseGame();
                } else{
                    pauseGame();
                }
                if(inventoryMenuOpen){
                    inventoryMenu.SetActive(false);
                    inventoryMenuOpen = false;
                } else if(!pauseMenuOpen){
                    inventoryMenu.SetActive(true);
                    inventoryMenuOpen = true;
                }
            }
        }
    }

    void pauseGame(){
        Time.timeScale = 0;
        gamePaused = true;
        player.GetComponent<PlayerShooting>().canFire = false;
    }

    public void unpauseGame(){
        Time.timeScale = 1;
        gamePaused = false;
        player.GetComponent<PlayerShooting>().canFire = true;
    }
}
