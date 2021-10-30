using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Giao dien nguoi dung va trinh quan ly su kien
public class UiManager : MonoBehaviour
{
	//Ui Level moi
	public string nextLevel;
    // Man hinh pause
    public GameObject pauseMenu;
    // Man hinh thua
    public GameObject defeatMenu;
    // Man hinh thang
    public GameObject victoryMenu;
    // Giao dien cap do
    public GameObject levelUI;
    // Game dang pause?
    private bool paused;
	void Awake()
	{
        Debug.Assert(pauseMenu && defeatMenu && victoryMenu && levelUI, "Tham so ban dau sai");
	}
    //Dung boi canh hien tai va tai boi canh moi
    private void LoadScene(string sceneName)
	{
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}
    public void NewGame()
	{
        
	}
    public void Resume()
    {

    }
    private void PauseGame(bool pause)
	{
        pause = pause;
        Time.timeScale = pause ? 0f : 1f;
	}
}
