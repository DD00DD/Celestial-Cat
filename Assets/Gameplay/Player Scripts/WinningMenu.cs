using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningMenu : MonoBehaviour
{
    public void Reward()
    {
        GameObject thePlayer = GameObject.Find("Cat Girl");
        Player catGirl = thePlayer.GetComponent<Player>();

        if (catGirl.health >= 3)
        {
            SceneManager.LoadScene("Good ending");
        }

        else
        {
            SceneManager.LoadScene("Bad Ending");
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Game Screen");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
