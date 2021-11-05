using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	//Vi tri gameobject
    public Transform enemyPrefab;
	//Vi tri spawnPoint
	public Transform spawnPoint;
	// thoi gian giua cac wave
    public float timeBetweenWaves = 5f;
	// thoi gian dem nguoc ra quai khi bat dau wave
	private float countdown = 2f;
	// thoi gian dem nguoc wave tiep theo
	public Text waveCountDownText;
	// dat wax hien tai la 1
	private int waveIndex = 0;

	void Update()
	{
		if (GameManager.GameIsOver)
		{
			this.enabled = false;
			return;
		}

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;

		waveCountDownText.text = "Wave: " + Mathf.Round(waveIndex).ToString();
	}

	IEnumerator SpawnWave()
	{
		waveIndex++;

		for (int i = 0; i< waveIndex;i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
		
	}
	void SpawnEnemy()
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
