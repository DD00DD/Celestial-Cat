using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clown : MonoBehaviour
{
    public AudioSource audio;
    public GameObject clown1;
    public GameObject clown2;
    public GameObject clown3;
    public GameObject clown4;
    public GameObject mirror1;
    public GameObject mirror2;
    public GameObject clownImg;
    public GameObject button;
    void Start()
    {
        clown1 = GameObject.Find("Clown1");
        clown1.SetActive(false);

        clown2 = GameObject.Find("Clown2");
        clown2.SetActive(false);

        clown3 = GameObject.Find("Clown3");
        clown3.SetActive(false);

        clown4 = GameObject.Find("Clown4");
        clown4.SetActive(false);

        mirror1 = GameObject.Find("Mirror1");
        mirror1.SetActive(false);

        mirror2 = GameObject.Find("Mirror2");
        mirror2.SetActive(false);

        clownImg = GameObject.Find("clown");
        clownImg.SetActive(false);

        button = GameObject.Find("ButtonMain");
        button.SetActive(false);
    }

    public void DoStart()
    {
        Destroy(GameObject.Find("Button"));
        Invoke("Initiate", 1);      
    }

    public void Initiate()
    {
        Destroy(GameObject.Find("chest_0"));
        Destroy(GameObject.Find("Text"));


        AudioSource clown = GameObject.Find("Audio").GetComponent<AudioSource>();
        clown.Play(0);

        clown1.SetActive(true);
        mirror1.SetActive(true);

        Invoke("Clown2", 4);
    }

    public void Clown2()
    {
        Destroy(GameObject.Find("Clown1"));
        clown2.SetActive(true);

        Invoke("Clown3", 3);
    }

    public void Clown3()
    {
        System.Threading.Thread.Sleep(800);
        Destroy(GameObject.Find("Clown2"));
        clown3.SetActive(true);

        Invoke("Clown4", 4);
    }

    public void Clown4()
    {
        Destroy(GameObject.Find("Clown3"));       
        Destroy(GameObject.Find("Mirror1"));

        mirror2.SetActive(true);
        clown4.SetActive(true);
        clownImg.SetActive(true);

        Invoke("Button", 5);
    }

    public void Button()
    {
        button.SetActive(true);
    }
}
