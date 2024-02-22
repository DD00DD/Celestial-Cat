using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = -10f;
    public Rigidbody2D bossBullet;

    void Start()
    {
        bossBullet.velocity = transform.right * speed;
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
