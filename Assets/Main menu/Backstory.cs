using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backstory : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    public void SceneChange()
    {
        SceneManager.LoadScene ("Backstory");
    }
}
