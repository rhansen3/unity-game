using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    private float timeAlive = 0f;
    public float maxSeconds = 20f;
    public float bulletDamage = 10f;

    void Start(){
        bulletDamage = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if(timeAlive >= maxSeconds){
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<EnemyLifeManager>().takeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
