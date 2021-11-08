using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

	public string nextLevel;
	public int levelToUnlock;

	public void Continue()
	{
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
		SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
	}
    public void Menu()
	{
		SceneManager.LoadScene(menuSceneName, LoadSceneMode.Single);
	}
}
