using UnityEngine;

// Controls the life of an enemy as well as both level and player score when the enemy is destroyed.

public class EnemyLifeManager : MonoBehaviour
{

    public float enemyHealth = 100f;
    public float enemyDeathScore = 100f;
    public PlayerScore playerScore;
    public Material spritesDefaultMaterial;
    public Material spritesFlashMaterial;
    public float damageFlashTime = 0.15f;
    private float flashTimeStart;
    private bool flashingDamage = false;
    protected LevelManager levelManager;
    public float levelPointsOnDeath = 5f;
    public int enemyDictID = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(playerScore == null){
            playerScore = GameObject.FindWithTag("Player").GetComponent<PlayerScore>();
        }
        if(levelManager == null){
            levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
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

    public virtual void enemyDeath(){
        playerScore.addScore(enemyDeathScore);
        levelManager.addLevelPoints(levelPointsOnDeath);
        levelManager.enemyDict.Remove(enemyDictID);
        Destroy(gameObject);
    }

    private void damageAnimation(){
        flashTimeStart = Time.time;
        GetComponent<SpriteRenderer>().material = spritesFlashMaterial;
        flashingDamage = true;
    }
}
