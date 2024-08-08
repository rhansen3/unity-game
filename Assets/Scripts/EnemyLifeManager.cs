using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour
{

    public float enemyHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage){
        enemyHealth -= damage;
        if(enemyHealth <= 0){
            enemyDeath();
        }
    }

    public void enemyDeath(){
        Destroy(gameObject);
    }
}
