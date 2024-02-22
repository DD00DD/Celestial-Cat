using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public float health;
    public float bossFireRate = 0.5f;
    public float bossNextFire = 0.0f;
    public bool fadeOne = false;
    public bool fadeTwo = false;
    public bool fadeThree = false;
    public int counterOne;
    public int counterTwo;
    public int counterThree;

    public Image healthBar;
    public Animator animator;
    public GameObject bossBullet;
    public GameObject stageTwoLaser;
    public GameObject stageThreeLaser;
    public Transform bossWeapon;

    public GameObject enemyOne;
    public GameObject enemyTwo;
    public Transform enemyOnePositionOne;
    public Transform enemyOnePositionTwo;
    public Transform enemyTwoPositionOne;
    public Transform enemyTwoPositionTwo;

    public GameObject fadeTransition; // transitions
    public GameObject stageOneTransition;
    public GameObject stageTwoTransition;
    public GameObject stageThreeTransition;
    public GameObject bossDialogueOne;   
    public GameObject bossDialogueTwo;
    public GameObject bossDialogueThree;
    public GameObject catGirlDialogueOne;
    public GameObject catGirlDialogueTwo;  
    public GameObject winningScreen;

    public GameObject stageOneBackground; // background changes
    public GameObject stageTwoBackground;
    public GameObject stageThreeBackground;

    public Transform laserSpotOne; //laser field
    public Transform laserSpotTwo;
    public Transform laserSpotThree;
    public Transform laserSpotFour;
    public Transform laserSpotFive;
    public Transform laserSpotSix;
    public Transform laserSpotSeven;
    public Transform laserSpotEight;
    public Transform laserSpotNine;
    public Transform laserSpotTen;

    public AudioClip musicClipOne; // sounds and music
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;
    public AudioClip winningMusic;
    public AudioClip bossDeathSound;
    public AudioClip talking;
    public AudioSource musicSource;

    private float startHealth = 100000f;
    
    void Start()
    {        
        health = startHealth;
        fadeTransition.SetActive(true);
        StartCoroutine("TransitionOne");
    }

    void Update()
    {
        if (health > 80000 && health <= 100000 && fadeOne == true) // Stage 1
        {                  
            if (Time.time > bossNextFire)
            {
                bossNextFire = Time.time + bossFireRate;
                counterOne += 1;

                if (counterOne <= 10 && counterOne > 1)
                {
                    animator.SetBool("BossAttacking", false);
                    Invoke("Stage1Move1", 2);
                }

                else if (counterOne <= 20 && counterOne > 10)
                {
                    animator.SetBool("BossAttacking", true);
                    Invoke("Stage1Move2", 2);
                }

                else if (counterOne <= 30 && counterOne > 20)
                {
                    animator.SetBool("BossAttacking", false);
                    Invoke("Stage1Move3", 2);
                }
                else if (counterOne <= 40 && counterOne > 30)
                {
                    animator.SetBool("BossAttacking", true);
                    Invoke("Stage1Move4", 2);
                }
                else if (counterOne > 40)
                {
                    counterOne = 0;
                }
            }
        }

        else if (health > 50000 && health <= 80000) // Stage 2
        {
            if (!fadeTwo)
            {
                fadeTwo = true;
                StartCoroutine("TransitionTwo");               
            }
          
            else if (Time.time > bossNextFire && fadeTwo == true)
            {
                bossNextFire = Time.time + bossFireRate;
                counterTwo += 1;

                if (counterTwo <= 25 && counterTwo > 15)
                {
                    animator.SetBool("BossAttacking", true);
                    Invoke("Stage2Move1", 2);
                }

                else if (counterTwo <= 35 && counterTwo > 25)
                {
                    animator.SetBool("BossAttacking", false);
                    Invoke("Stage2Move2", 2);
                }

                else if (counterTwo <= 45 && counterTwo > 35)
                {
                    animator.SetBool("BossAttacking", true);
                    Invoke("Stage2Move3", 2);
                }

                else if (counterTwo <= 55 && counterTwo > 45)
                {
                    animator.SetBool("BossAttacking", false);
                    Invoke("Stage2Move4", 2);
                }

                else if (counterTwo > 55)
                {
                    counterTwo = 15;
                }
            }
        }

        else if (health > 0 && health <= 50000) // stage 3
        {
            if (!fadeThree)
            {
                fadeThree = true;
                StartCoroutine("TransitionThree");
            }

            else if (Time.time > bossNextFire && fadeThree == true)
            {
                bossNextFire = Time.time + bossFireRate;
                counterThree += 1;

                if (counterThree <= 25 && counterThree > 15)
                {
                    animator.SetBool("BossAttacking", false);
                    Invoke("Stage3Move1", 2);
                }

                else if (counterThree <= 35 && counterThree > 25)
                {
                    animator.SetBool("BossAttacking", true);
                    Invoke("Stage3Move2", 2);
                }

                else if (counterThree <= 45 && counterThree > 35)
                {
                    animator.SetBool("BossAttacking", false);
                    Invoke("Stage3Move3", 2);
                }

                else if (counterThree <= 55 && counterThree > 45)
                {
                    animator.SetBool("BossAttacking", true);
                    Invoke("Stage3Move4", 2);
                }

                else if (counterThree > 55)
                {
                    counterThree = 15;
                }
            }
        }
    }

    public void Damage(int damageTaken) // boss HP
    {
        health -= damageTaken;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            GameObject thePlayer = GameObject.Find("Cat Girl");
            Shoot user = thePlayer.GetComponent<Shoot>();

            user.powerUp = 0;
            musicSource.Stop();
            musicSource.clip = bossDeathSound;
            musicSource.Play();
            animator.SetBool("BossAttacking", false);
            animator.SetBool("BossDying", true);
            DestroyBossProjectiles();          
            Invoke("WinningBox", 5);
        }
    }

    void OnTriggerEnter2D(Collider2D hit) // player is damaged when they touch the boss
    {
        Player hearts = hit.GetComponent<Player>();

        if (hearts != null)
        {
            hearts.PlayerDamage(1);
        }
    }

    void DestroyBossProjectiles() // deletes enemies and projectiles once boss dies
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Enemy Bullets");

        foreach (GameObject itemOne in projectiles)
        {
            GameObject.Destroy(itemOne);
        }

        GameObject[] enemiesAlive = GameObject.FindGameObjectsWithTag("Enemies");

        foreach (GameObject itemTwo in enemiesAlive)
        {
            GameObject.Destroy(itemTwo);
        }
    }

    void WinningBox()
    {
        musicSource.Stop();
        musicSource.clip = winningMusic;
        musicSource.Play();
        fadeTransition.SetActive(true);            
        winningScreen.SetActive(true);
    }

    IEnumerator TransitionOne() // stage one transition
    {
        GameObject thePlayer = GameObject.Find("Cat Girl");
        Shoot user = thePlayer.GetComponent<Shoot>();
        Player catGirl = thePlayer.GetComponent<Player>();

        stageOneTransition.SetActive(true); 
        catGirl.speed = 0f;

        musicSource.clip = talking;
        musicSource.Play();
        yield return new WaitForSeconds(3); 
        fadeTransition.SetActive(false);
        bossDialogueOne.SetActive(false);
        catGirlDialogueOne.SetActive(true);

        yield return new WaitForSeconds(3);
        musicSource.Stop();
        stageOneTransition.SetActive(false);
        catGirlDialogueOne.SetActive(false);
        fadeOne = true;
        fadeTransition.SetActive(true);

        yield return new WaitForSeconds(1); 
        fadeTransition.SetActive(false);
        user.powerUp = 1f;
        catGirl.speed = 5f;
        musicSource.clip = musicClipOne;
        musicSource.Play();
    }

    IEnumerator TransitionTwo() // stage two transition
    {
        GameObject thePlayer = GameObject.Find("Cat Girl");
        Shoot user = thePlayer.GetComponent<Shoot>();
        Player catGirl = thePlayer.GetComponent<Player>();

        musicSource.Stop();
        musicSource.clip = talking;
        musicSource.Play();
        user.powerUp = 0f;
        catGirl.speed = 0f;      
        fadeTransition.SetActive(true);
        stageTwoTransition.SetActive(true);
        stageOneBackground.SetActive(false);

        enemyOnePositionOne.rotation = Quaternion.Euler(0, 0, 270);
        Instantiate(enemyOne, enemyOnePositionOne.position, enemyOnePositionOne.rotation);
        enemyOnePositionTwo.rotation = Quaternion.Euler(0, 0, 270);
        Instantiate(enemyOne, enemyOnePositionTwo.position, enemyOnePositionTwo.rotation);

        yield return new WaitForSeconds(3);
        fadeTransition.SetActive(false);
        bossDialogueTwo.SetActive(false);
        catGirlDialogueTwo.SetActive(true);

        yield return new WaitForSeconds(2);
        transform.position = new Vector2(9, 1);
        user.powerUp = 2f;
        catGirl.speed = 5f;
        bossFireRate = 0.4f;

        catGirlDialogueTwo.SetActive(false);
        bossDialogueThree.SetActive(true);

        yield return new WaitForSeconds(2);
        musicSource.Stop();
        stageTwoTransition.SetActive(false);
        fadeTransition.SetActive(true);
   
        yield return new WaitForSeconds(1);
        fadeTransition.SetActive(false);
        bossDialogueThree.SetActive(false);
        musicSource.clip = musicClipTwo;
        musicSource.Play();
    }

    IEnumerator TransitionThree() // stage three transition
    {
        stageTwoLaser = null;
        GameObject thePlayer = GameObject.Find("Cat Girl");
        Shoot user = thePlayer.GetComponent<Shoot>();
        Player catGirl = thePlayer.GetComponent<Player>();

        musicSource.Stop();
        musicSource.clip = talking;
        musicSource.Play();
        user.powerUp = 0f;
        catGirl.speed = 0f;
        fadeTransition.SetActive(true);
        stageThreeTransition.SetActive(true);
        stageTwoBackground.SetActive(false);

        enemyTwoPositionOne.rotation = Quaternion.Euler(0, 0, 90);
        Instantiate(enemyTwo, enemyTwoPositionOne.position, enemyTwoPositionOne.rotation);
        enemyTwoPositionTwo.rotation = Quaternion.Euler(0, 0, 90);
        Instantiate(enemyTwo, enemyTwoPositionTwo.position, enemyTwoPositionTwo.rotation);

        yield return new WaitForSeconds(1);
        fadeTransition.SetActive(false);

        yield return new WaitForSeconds(5);
        musicSource.Stop();
        user.powerUp = 3f;
        catGirl.speed = 5f;
        bossFireRate = 0.3f;

        stageThreeTransition.SetActive(false);
        fadeTransition.SetActive(true);
        
        yield return new WaitForSeconds(1);
        fadeTransition.SetActive(false);      
        musicSource.clip = musicClipThree;
        musicSource.Play();
    }

    void Stage1Move1() // horizontal fire
    {
        transform.position = new Vector2(9, 1);
        bossWeapon.rotation = Quaternion.Euler(0, 0, 0);
        Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
    }

    void Stage1Move2() // First circle move
    {
        transform.position = new Vector2(0, 1);
        int bulletRotationOne = 0;

        for (int i = 0; i <= 8; i++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationOne);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationOne += 45;
        }
    }

    void Stage1Move3() // 2 diagonal fires
    {
        transform.position = new Vector2(9, 1);
        bossWeapon.rotation = Quaternion.Euler(0, 0, 5);
        Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
        bossWeapon.rotation = Quaternion.Euler(0, 0, -5);
        Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
    }

    void Stage1Move4() // star shape fire
    {
        transform.position = new Vector2(0, 1);
        int bulletRotationTwo = 0;

        for (int i = 0; i <= 5; i++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationTwo);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationTwo += 72;
        }
    }

    void Stage2Move1() // first laser move 
    {
        transform.position = new Vector2(9, 1);
        bossWeapon.rotation = Quaternion.Euler(0, 0, 180);

        GameObject laserBeam = Instantiate(stageTwoLaser, bossWeapon.position, bossWeapon.rotation);
        Destroy(laserBeam, 1);
    }

    void Stage2Move2() // half circle
    {
        transform.position = new Vector2(9, 1);
        int bulletRotationThree = 0;

        for (int i = 0; i <= 10; i++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationThree);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationThree += 10;
        }

        int bulletRotationFour = 0;

        for (int i = 0; i <= 10; i++)
        {
            bulletRotationFour -= 10;
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationFour);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
        }
    }

    void Stage2Move3() // smaller circle
    {
        transform.position = new Vector2(0, 1);
        int bulletRotationFive = 0;

        for (int i = 0; i <= 12; i++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationFive);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationFive += 30;
        }
    }

    void Stage2Move4() // 7 diagonals
    {
        transform.position = new Vector2(9, 1);
        int bulletRotationSix = 0;

        for (int i = 0; i <= 4; i++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationSix);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationSix += 20;
        }

        int bulletRotationSeven = 0;

        for (int i = 0; i <= 3; i++)
        {
            bulletRotationSeven -= 20;
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationSeven);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
        }
    }

    void Stage3Move1() //Tight circle
    {
        transform.position = new Vector2(0, 1);
        int bulletRotationEight = 0;

        for (int i = 0; i <= 36; i++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationEight);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationEight += 10;
        }
    }

    void Stage3Move2() // Laser field
    {
        laserSpotOne.rotation = Quaternion.Euler(0, 0, 0);
        GameObject laserBeamOne = Instantiate(stageThreeLaser, laserSpotOne.position, laserSpotOne.rotation);
        Destroy(laserBeamOne, 1);

        laserSpotTwo.rotation = Quaternion.Euler(0, 0, 45);
        GameObject laserBeamTwo = Instantiate(stageThreeLaser, laserSpotTwo.position, laserSpotTwo.rotation);
        Destroy(laserBeamTwo, 1);

        laserSpotThree.rotation = Quaternion.Euler(0, 0, 45);
        GameObject laserBeamThree = Instantiate(stageThreeLaser, laserSpotThree.position, laserSpotThree.rotation);
        Destroy(laserBeamThree, 1);

        laserSpotFour.rotation = Quaternion.Euler(0, 0, -60);
        GameObject laserBeamFour = Instantiate(stageThreeLaser, laserSpotFour.position, laserSpotFour.rotation);
        Destroy(laserBeamFour, 1);

        laserSpotFive.rotation = Quaternion.Euler(0, 0, -110);
        GameObject laserBeamFive = Instantiate(stageThreeLaser, laserSpotFive.position, laserSpotFive.rotation);
        Destroy(laserBeamFive, 1);

        laserSpotSix.rotation = Quaternion.Euler(0, 0, -75);
        GameObject laserBeamSix = Instantiate(stageThreeLaser, laserSpotSix.position, laserSpotSix.rotation);
        Destroy(laserBeamSix, 1);

        laserSpotSeven.rotation = Quaternion.Euler(0, 0, -75);
        GameObject laserBeamSeven = Instantiate(stageThreeLaser, laserSpotSeven.position, laserSpotSeven.rotation);
        Destroy(laserBeamSeven, 1);

        laserSpotEight.rotation = Quaternion.Euler(0, 0, 110);
        GameObject laserBeamEight = Instantiate(stageThreeLaser, laserSpotEight.position, laserSpotEight.rotation);
        Destroy(laserBeamEight, 1);

        laserSpotNine.rotation = Quaternion.Euler(0, 0, 160);
        GameObject laserBeamNine = Instantiate(stageThreeLaser, laserSpotNine.position, laserSpotNine.rotation);
        Destroy(laserBeamNine, 1);

        laserSpotTen.rotation = Quaternion.Euler(0, 0, -80);
        GameObject laserBeamTen = Instantiate(stageThreeLaser, laserSpotTen.position, laserSpotTen.rotation);
        Destroy(laserBeamTen, 1);
    }

    void Stage3Move3() // 11 diagonals on both sides
    {
        int bulletRotationNine = 0;

        for (int i = 0; i <= 6; i++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationNine);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationNine += 10;
        }

        int bulletRotationTen = 0;

        for (int i = 0; i <= 5; i++)
        {
            bulletRotationTen -= 10;
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationTen);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
        }

        int bulletRotationEleven = 180;

        for (int i = 0; i <= 6; i++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationEleven);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationEleven += 10;
        }

        int bulletRotationTwelve = -180;

        for (int i = 0; i <= 5; i++)
        {
            bulletRotationTwelve -= 10;
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationTwelve);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
        }
    }

    void Stage3Move4() // Tight circle with only 3 way to dodge
    {
        transform.position = new Vector2(0, 1);

        int bulletRotationThirteen = 140;

        for (int index = 0; index <= 20; index++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationThirteen);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationThirteen += 5;
        }

        int bulletRotationFourteen = 25;

        for (int index = 0; index <= 19; index++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationFourteen);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationFourteen += 5;
        }

        int bulletRotationFifthteen = 260;

        for (int index = 0; index <= 20; index++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationFifthteen);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationFifthteen += 5;
        }

        int bulletRotationSixteen = 0;

        for (int index = 0; index <= 3; index++)
        {
            bossWeapon.rotation = Quaternion.Euler(0, 0, bulletRotationSixteen);
            Instantiate(bossBullet, bossWeapon.position, bossWeapon.rotation);
            bulletRotationSixteen += 5;
        }
    }
}