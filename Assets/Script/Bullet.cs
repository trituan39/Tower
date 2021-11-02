using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	//vi tri muc tieu
	private Transform target;
	[SerializeField]
	public float speed;

	//tim muc tieu
	public void Seek (Transform _target)
	{
		target = _target;
	}

	void Update()
	{
		if(target== null)
		{
			Destroy(gameObject);
			return;
		}
		//rut ngan khoang cach vi tri muc tieu va vien dan
		Vector2 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget()
	{
		Destroy(gameObject);
	}
}
