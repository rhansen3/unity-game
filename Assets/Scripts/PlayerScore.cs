using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public float score = 0f;
    public TMP_Text scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(float toAdd){
        score += toAdd;
        scoreUI.text = "Score: " + score;
    }

}
