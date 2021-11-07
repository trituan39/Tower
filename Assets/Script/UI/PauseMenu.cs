using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField]
	GameObject pauseMenu;

	public void Pause()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
	}
	public void Continous()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
	}
	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void Menu()
	{

	}
}
