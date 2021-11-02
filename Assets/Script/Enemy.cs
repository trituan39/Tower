using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f;

    private Transform target;
    private int wavePointIndex = 0;

	void Start()
	{
		target = Waypoint.points[0];
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
			Destroy(gameObject);
			return;
		}
		wavePointIndex++;
		target = Waypoint.points[wavePointIndex];
	}
}
