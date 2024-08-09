using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public float fireRate = 1f;
    public bool canFire = true;
    public GameObject enemyBullet;
    public GameObject player;
    public float bulletStartDistance = 0.5f;
    public float bulletSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canFire){
            StartCoroutine(fireEnemyBullet());
        }
    }

    public IEnumerator fireEnemyBullet(){
        canFire = false;
        GameObject newEnemyBullet = Instantiate(enemyBullet, transform.position + transform.up * bulletStartDistance, Quaternion.identity);
        newEnemyBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * (player.transform.position - transform.position).normalized;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
