using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{

    public int lives = 3;

    public GameObject uiCanvas;

    void Start(){
        if(uiCanvas == null){
            uiCanvas = GameObject.FindWithTag("UICanvas");
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
        lives--;
        uiCanvas.GetComponent<CanvasLifeManager>().loseLife();
    }
}
