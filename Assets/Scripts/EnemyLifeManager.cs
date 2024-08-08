using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour
{

    public float enemyHealth = 100f;
    public float enemyDeathScore = 100f;
    public PlayerScore playerScore;
    public Material spritesDefaultMaterial;
    public Material spritesFlashMaterial;
    private float damageFlashTime = 0.25f;
    private float flashTimeStart;
    private bool flashingDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        if(playerScore == null){
            playerScore = GameObject.FindWithTag("Player").GetComponent<PlayerScore>();
        }
        if(spritesDefaultMaterial == null){
            Debug.LogError("No default sprite material set for enemy damage flash");
        }
        if(spritesFlashMaterial == null){
            Debug.LogError("No sprite flash material set for enemy damage flash");
        }
    }

    void Update(){
        if((flashingDamage) && (Time.time > flashTimeStart + damageFlashTime)){
            GetComponent<SpriteRenderer>().material = spritesDefaultMaterial;
            flashingDamage = false;
        }
    }

    public void takeDamage(float damage){
        enemyHealth -= damage;
        if(enemyHealth <= 0){
            enemyDeath();
        } else{
            damageAnimation();
        }
    }

    public void enemyDeath(){
        playerScore.addScore(enemyDeathScore);
        Destroy(gameObject);
    }

    private void damageAnimation(){
        flashTimeStart = Time.time;
        GetComponent<SpriteRenderer>().material = spritesFlashMaterial;
        flashingDamage = true;
    }
}
