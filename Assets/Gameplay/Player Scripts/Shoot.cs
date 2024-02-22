using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform weaponOne;
    public Transform weaponTwo;
    public Transform weaponThree;
    public GameObject playerBullet;
    public float powerUp = 1f;
    private float fireRate = 0.1f;
    private float nextFire = 0.0f;

    void Start()
    {
        powerUp = 0;
    }

    void Update()
    {
        // Disable Player fire when there is 0 or less hearts
        GameObject thePlayer = GameObject.Find("Cat Girl");
        Player user = thePlayer.GetComponent<Player>();

        if (user.health <= 0)
        {
            powerUp = 0;
        }

        // Player shooting patterns
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            if (powerUp == 1) // stage 1 player bullet patterns
            {
                weaponOne.rotation = Quaternion.Euler(0, 0, 3);
                Instantiate(playerBullet, weaponOne.position, weaponOne.rotation);
                weaponOne.rotation = Quaternion.Euler(0, 0, -3);
                Instantiate(playerBullet, weaponOne.position, weaponOne.rotation);
            }

            else if (powerUp == 2) // stage 2 player bullet patterns
            {
                weaponOne.rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(playerBullet, weaponOne.position, weaponOne.rotation);
                weaponOne.rotation = Quaternion.Euler(0, 0, 10);
                Instantiate(playerBullet, weaponOne.position, weaponOne.rotation);
                weaponOne.rotation = Quaternion.Euler(0, 0, -10);
                Instantiate(playerBullet, weaponOne.position, weaponOne.rotation);
            }

            else if (powerUp == 3) // stage 3 player bullet patterns
            {
                weaponOne.rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(playerBullet, weaponOne.position, weaponOne.rotation);
                weaponTwo.rotation = Quaternion.Euler(0, 0, 10);
                Instantiate(playerBullet, weaponTwo.position, weaponTwo.rotation);
                weaponTwo.rotation = Quaternion.Euler(0, 0, -10);
                Instantiate(playerBullet, weaponTwo.position, weaponTwo.rotation);
                weaponThree.rotation = Quaternion.Euler(0, 0, 10);
                Instantiate(playerBullet, weaponThree.position, weaponThree.rotation);
                weaponThree.rotation = Quaternion.Euler(0, 0, -10);
                Instantiate(playerBullet, weaponThree.position, weaponThree.rotation);
            }
        }
    }

    public void PlusOne(int enhanceAbility)
    {
        powerUp += enhanceAbility;
    }
}
