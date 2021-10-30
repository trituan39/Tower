using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
	{
		SceneManager.LoadScene("Level1", LoadSceneMode.Single);
	}
	public void Quit()
	{
		Application.Quit();
	}
}
