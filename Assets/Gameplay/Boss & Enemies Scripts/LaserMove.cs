using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hit)
    {
        Player hearts = hit.GetComponent<Player>();

        if (hearts != null)
        {
            hearts.PlayerDamage(1);
        }
    }
}
