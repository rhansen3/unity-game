using System;
using System.Collections;
using UnityEngine;

// Controls the behavior of the boss's attacks and causes the boss to either go stationary or start moving again

public class BossAttack : MonoBehaviour
{

    private int attackNums = 3;
    private float attackCooldown = 5f;
    private bool canAttack = true;
    public GameObject enemyBullet;
    public BossMovement bossMovement;
    public GameObject player;
    private float timeBetweenSpiralShots = 0.2f;
    public float bulletStartDistance = 0.5f;
    public float bulletSpeed = 7f;
    private float tripleAttackPrimaryAngle = 30f;
    private float tripleAttackSecondaryAngle = 20f;
    private float timeBetweenTripleShots = 0.75f;
    private float circleShotWait = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        if(bossMovement == null){
            bossMovement = gameObject.GetComponent<BossMovement>();
        }
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canAttack){
            StartCoroutine(randomBossAttack());
        }
    }

    private IEnumerator randomBossAttack(){
        canAttack = false;
        int attack = UnityEngine.Random.Range(0, attackNums);
        if(attack == 0){
            bossMovement.still();
            StartCoroutine(spiralAttack());
        } else if(attack == 1){
            bossMovement.still();
            StartCoroutine(circleAttack());
        } else if(attack == 2){
            StartCoroutine(tripleAttack());
        }
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private IEnumerator spiralAttack(){
        for(float angle = 0; angle <= 360; angle += 30){
            yield return new WaitForSeconds(timeBetweenSpiralShots);
            Vector3 shootVec = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up;
            GameObject newEnemyBullet = Instantiate(enemyBullet, transform.position + shootVec * bulletStartDistance, Quaternion.identity);
            newEnemyBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * shootVec;
        }
        bossMovement.move();
    }

    private IEnumerator circleAttack(){
        for(float angle = 0; angle < 360; angle += 15){
            Vector3 shootVec = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up;
            GameObject newEnemyBullet = Instantiate(enemyBullet, transform.position + shootVec * bulletStartDistance, Quaternion.identity);
            newEnemyBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * shootVec;
        }
        yield return new WaitForSeconds(circleShotWait);
        bossMovement.move();
    }

    private IEnumerator tripleAttack(){
        Vector3 shootVec;
        // First round of shots, tight cone of three
        for(float angle = -tripleAttackPrimaryAngle; angle <= tripleAttackPrimaryAngle; angle += tripleAttackPrimaryAngle / 2){
            shootVec = Quaternion.AngleAxis(angle, Vector3.forward) * (player.transform.position - transform.position).normalized;
            GameObject newEnemyBullet = Instantiate(enemyBullet, transform.position + shootVec * bulletStartDistance, Quaternion.identity);
            newEnemyBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * shootVec;
        }
        yield return new WaitForSeconds(timeBetweenTripleShots);
        // Second round of shots, wider cone of three
        for(float angle = -tripleAttackSecondaryAngle; angle <= tripleAttackSecondaryAngle; angle += tripleAttackSecondaryAngle / 2){
            shootVec = Quaternion.AngleAxis(angle, Vector3.forward) * (player.transform.position - transform.position).normalized;
            GameObject newEnemyBullet = Instantiate(enemyBullet, transform.position + shootVec * bulletStartDistance, Quaternion.identity);
            newEnemyBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * shootVec;
        }
    }
}
