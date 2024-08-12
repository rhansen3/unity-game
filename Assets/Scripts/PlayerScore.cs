using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Keeps track of the player's score and prints it to the UI.

public class PlayerScore : MonoBehaviour
{
    public float score = 0f;
    public TMP_Text scoreUI;

    public void addScore(float toAdd){
        score += toAdd;
        scoreUI.text = "Score: " + score;
    }

}
