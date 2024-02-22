using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public int health = 5000;
    public Transform enemyOneWeapon;
    public GameObject enemyOneBullet;
    public Animator animator;
    private float enemyOneFireRate = 0.4f;
    private float enemyOneNextFire = 0.0f;  

    public void EnemyDamage(int hitDamage)
    {
        // Enemy HP
        health -= hitDamage;
        
        if (health <= 0)
        { 
            animator.SetBool("Dying", true);
            Destroy(gameObject, 2);
        }
    }
    void OnTriggerEnter2D(Collider2D hit) // player is damaged when they touch the enemy one
    {
        Player hearts = hit.GetComponent<Player>();

        if (hearts != null)
        {
            hearts.PlayerDamage(1);
        }
    }

    void Update()
    {
        // Enemy shoot
        if (Time.time > enemyOneNextFire)
        {
            enemyOneNextFire = Time.time + enemyOneFireRate;
            Instantiate(enemyOneBullet, enemyOneWeapon.position, enemyOneWeapon.rotation);
        }
    }
}
