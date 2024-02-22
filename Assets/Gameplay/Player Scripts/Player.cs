using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health = 3f;
    public Image[] hearts;
    public Sprite full;
    public Sprite empty;
    public GameObject death;
    public Animator animator;
    public GameObject shield;
    public GameObject fade;
    public AudioClip playerDeathSound;
    public AudioSource musicSource;
    public AudioSource deathSource;
    public float speed = 5f;
    
    void Start()
    {
        Time.timeScale = 1;
        Physics2D.IgnoreLayerCollision(12, 11, false);
        Physics2D.IgnoreLayerCollision(12, 9, false);
    }

    public void PlayerDamage(int hitpoints)
    {       
        health -= hitpoints;  

        if (health > 0) //health indicator
        {
            animator.SetBool("GotHit", true);
            Invoke("PlayerHit", 1);
            StartCoroutine("TempInvincibility", 3f);
        }

        else if (health <= 0)
        {
            animator.SetBool("Dead", true);
            speed = 0;

            musicSource.Stop();          
            Invoke("DeathScreen", 2);
        }
    }
    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * speed;

        // Hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = full;
            }

            else
            {
                hearts[i].sprite = empty;
            }
        }

        GameObject theBoss = GameObject.Find("Boss");
        Boss bossMan = theBoss.GetComponent<Boss>();

        if (bossMan.counterTwo > 0 && bossMan.counterTwo < 15)
        {           
            TempInvincibility(5);
            transform.position = new Vector2(-9, 0);
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Enemy Bullets");
            foreach (GameObject itemOne in projectiles)
            {
                GameObject.Destroy(itemOne);
            }
        }

        else if (bossMan.counterThree > 0 && bossMan.counterThree < 15)
        {           
            TempInvincibility(5);
            transform.position = new Vector2(-9, 0);
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Enemy Bullets");
            foreach (GameObject itemOne in projectiles)
            {
                GameObject.Destroy(itemOne);
            }
        }

        else if (bossMan.health <= 0)
        {
            StartCoroutine("TempInvincibility", 10f);
        }
    }

    public void DeathScreen() //death screen
    {
        Time.timeScale = 0;
        death.SetActive(true);
        deathSource.clip = playerDeathSound;
        deathSource.Play();     
    }

    public void PlayerHit() // Hit animnation reset
    {
        animator.SetBool("GotHit", false);
    }

    public IEnumerator TempInvincibility(int numOfSeconds)
    {
        Physics2D.IgnoreLayerCollision(12, 11, true);
        Physics2D.IgnoreLayerCollision(12, 9, true);
        Physics2D.IgnoreLayerCollision(12, 8, true);
        shield.SetActive(true);

        yield return new WaitForSeconds(numOfSeconds);

        shield.SetActive(false);
        Physics2D.IgnoreLayerCollision(12, 11, false);
        Physics2D.IgnoreLayerCollision(12, 9, false);
        Physics2D.IgnoreLayerCollision(12, 8, false);
    }
}