using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Yeu cau tra ve Enemy
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
	//Vi tri hien tai cua muc tieu
	private Transform target;

	//Wave mac dinh
	private int wavePointIndex = 0;

	//track ve enemy
	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();

		target = Waypoint.points[0];
	}
	void Update()
	{

		Vector2 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if(GameManager.GameIsOver)
		{
			this.enabled = false;
			return;
		}

		if (Vector2.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWavePoint();
		}
	}
	void GetNextWavePoint()
	{
		if (wavePointIndex >= Waypoint.points.Length - 1)
		{
			EndPath();
			return;
		}
		wavePointIndex++;
		target = Waypoint.points[wavePointIndex];
	}
	void EndPath()
	{
		PlayerStat.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
}
