using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//Toc do quai
    public float speed = 0.5f;

	//Mau
	public int health;

	//Cost enemy die
	public int value;

	//Vi tri hien tai cua muc tieu
    private Transform target;

	//Wave mac dinh
    private int wavePointIndex = 0;

	void Start()
	{
		target = Waypoint.points[0];
	}

	// Nhan dame
	public void TakeDamage(int amount)
	{
		health -= amount;

		if(health <= 0)
		{
			Die();
		}
	}

	//Chet
	void Die()
	{
		PlayerStat.Money += value; 
		Destroy(gameObject);
	}

	void Update()
	{
		Vector2 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

		if(Vector2.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWavePoint();
		}
	}
	void GetNextWavePoint()
	{ 
		if(wavePointIndex >= Waypoint.points.Length - 1)
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
		Destroy(gameObject);
	}

}
