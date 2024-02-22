using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D playerBullet;

    void Start()
    {
        playerBullet.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        Destroy(gameObject);
        Boss  bossHit = hit.GetComponent<Boss>();

        if (bossHit != null)
        {       
            bossHit.Damage(50);
        }

        EnemyOne enemyNumOne = hit.GetComponent<EnemyOne>();
        if (enemyNumOne != null)
        {
            enemyNumOne.EnemyDamage(50);
        }

        EnemyTwo enemyNumTwo = hit.GetComponent<EnemyTwo>();
        if (enemyNumTwo != null)
        {
            enemyNumTwo.EnemyDamage(50);
        }
    }
}
