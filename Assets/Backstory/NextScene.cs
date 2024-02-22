using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Game Screen");

        Destroy(GameObject.Find("AudioSource"));
    }
}
