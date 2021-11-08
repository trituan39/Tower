using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	//Tao bien static so luong quai song = 0
	public static int EnemiesAlive = 0;

	//Vi tri gameobject
	public Wave[] waves;	

	//Vi tri spawnPoint
	public Transform spawnPoint;

	// thoi gian giua cac wave
    public float timeBetweenWaves = 5f;
	// thoi gian dem nguoc ra quai khi bat dau wave
	private float countdown = 2f;

	//thoi gian dem nguoc wave tiep theo
	public Text waveCountdownText;

	//Text rounds
	public Text roundsText;

	// dat wax hien tai la 1
	private int waveIndex = 0;

	void Update()
	{
		if (GameManager.GameIsOver)
		{
			this.enabled = false;
			return;
		}
		if (EnemiesAlive>0)
		{
			return;
		}
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}",countdown);		
	}

	IEnumerator SpawnWave()
	{		
		Wave wave = waves[waveIndex];
		PlayerStat.Rounds++;

		for (int i = 0; i< wave.count;i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f/ wave.rate);
		}
		waveIndex++;

		if (waveIndex == waves.Length)
		{
			Debug.Log("Level Won!");
			this.enabled = false;
		}
	}
	void SpawnEnemy(GameObject enemy)
	{
		roundsText.text = "Wave: " + PlayerStat.Rounds.ToString();
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		EnemiesAlive++;		
	}
}
