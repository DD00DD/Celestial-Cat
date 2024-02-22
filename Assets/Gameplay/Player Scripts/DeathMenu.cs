using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Game Screen");
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
