using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Controls player's lives. Keeps track of current life count, if player has lost their last life then ends the game.
// Tells the UI to print life icons as needed.

public class PlayerLifeManager : MonoBehaviour
{

    public int lives = 3;

    public GameObject uiCanvas;
    public LevelManager levelManager;

    void Start(){
        if(uiCanvas == null){
            uiCanvas = GameObject.FindWithTag("UICanvas");
        }
        if(levelManager == null){
            levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        }
        for(int i = 1; i <= lives; i++){
            uiCanvas.GetComponent<CanvasLifeManager>().gainLife();
        }
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag == "Enemy"){
            loseLife();
        }
    }

    public void gainLife(){
        lives++;
        uiCanvas.GetComponent<CanvasLifeManager>().gainLife();
    }

    public void loseLife(){
        // If player has lost their final life, end the level in a loss
        if(lives <= 0){
            levelManager.endLevel(false);
        } else{
            lives--;
            uiCanvas.GetComponent<CanvasLifeManager>().loseLife();
        }
    }
}
