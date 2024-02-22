using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public int health = 8000;
    public Transform enemyTwoWeapon;
    public GameObject enemyTwoBullet;
    public Animator animator;
    private float enemyTwoFireRate = 0.3f;
    private float enemyTwoNextFire = 0.0f;

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

    void OnTriggerEnter2D(Collider2D hit) // player is damaged when they touch enemy two
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
        if (Time.time > enemyTwoNextFire)
        {
            enemyTwoNextFire = Time.time + enemyTwoFireRate;

            enemyTwoWeapon.rotation = Quaternion.Euler(0, 0, 95);
            Instantiate(enemyTwoBullet, enemyTwoWeapon.position, enemyTwoWeapon.rotation);
            enemyTwoWeapon.rotation = Quaternion.Euler(0, 0, 85);
            Instantiate(enemyTwoBullet, enemyTwoWeapon.position, enemyTwoWeapon.rotation);
        }
    }
}
