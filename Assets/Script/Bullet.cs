using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	//vi tri muc tieu
	private Transform target;
	[SerializeField]
	float speed;
	[SerializeField]
	float explosionRadious;
	[SerializeField]
	int damage;

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
		//Tao kha nang no cua bullet bom
		if(explosionRadious>0f)
		{
			Explode();
		}
		//ko thi dame don muc tieu
		else
		{
			Damage(target);
		}
		Destroy(gameObject);
	}

	void Explode()
	{
		//Xac dinh collider 
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadious);

		foreach(Collider collider in colliders)
		{
			if(collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
	}

	void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if(e != null)
		{
			e.TakeDamage(damage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadious);
	}
}
