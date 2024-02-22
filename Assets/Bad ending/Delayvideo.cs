using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delayvideo : MonoBehaviour
{
    public GameObject text;
    public GameObject button;

    void Start()
    {
        text = GameObject.Find("Ending");
        text.SetActive(false);

        button = GameObject.Find("ButtonMain");
        button.SetActive(false);
    }
    public void DoStart()
    {
        Destroy(GameObject.Find("Button"));
        Invoke("Delay", 1);
    }

    public void Delay()
    {
        Destroy(GameObject.Find("chest_0"));
        Destroy(GameObject.Find("Text"));

        GameObject video = GameObject.Find("Vibe Check");
        var videoPlayer = video.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.Play();
        Invoke("EndScene", 45);
    }

    public void EndScene()
    {
        Destroy(GameObject.Find("Vibe Check"));
        text.SetActive(true);

        Invoke("EndScene2", 2);
    }

    public void EndScene2()
    {
        button.SetActive(true);
    }
}
