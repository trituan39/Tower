using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main menu operate.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Load level.
    /// </summary>
    public void NewGame()
    {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

    /// <summary>
    /// Close application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
