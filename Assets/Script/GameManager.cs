using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Tao bien GameIsOver
    public static bool GameIsOver;

    //Vat the bien gameOverUI
    public GameObject gameOverUI;

	void Start()
	{
        //Dat Game da xoong la false
        GameIsOver = false;
	}
	// Update is called once per frame
	void Update()
    {
        //Khi gameEnd thi tra ve true
        if (GameIsOver)
            return;

        //neu mau khong con thi tra ve gameEnded
        if(PlayerStat.Lives <= 0)
		{
            EndGame();
		}
    }
    void EndGame()
	{
        GameIsOver = true;

        gameOverUI.SetActive(true);
	}
}
