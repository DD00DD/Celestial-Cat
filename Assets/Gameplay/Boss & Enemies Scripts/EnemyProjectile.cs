using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = -10f;
    public Rigidbody2D enemyBullet;

    void Start()
    {
        enemyBullet.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        Destroy(gameObject);
        Player hearts = hit.GetComponent<Player>();

        if (hearts != null)
        {
            hearts.PlayerDamage(1);
        }
    }
}
