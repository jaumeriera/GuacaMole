using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    // General info about scenes
    // 0: MainMenu
    // 1: Gameplay

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        SceneManager.LoadScene(2);
    }


}
