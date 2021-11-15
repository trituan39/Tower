using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
	public Button[] levelButton;

	void Start()
	{
		int levelReached = PlayerPrefs.GetInt("levelReached", 1);

		for(int i = 0; i < levelButton.Length;i++)
		{
			if(i + 1 > levelReached)
			levelButton[i].interactable = false;
		}
	}
	public void Select(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}
	public void Back(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}
}
