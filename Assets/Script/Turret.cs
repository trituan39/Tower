using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //dat vi tri quai la muc tieu
    public Transform target;
    
    [Header("thuoc tinh")]
    //dat khoang cach tru la float
    public float range;
    //Toc do ban
    public float fireRate = 1f;
    //Thoi gian ban fire hoi
    private float fireCountdown = 0f;

    [Header("Cai dat")]
    //Dat tag quai vat la Enemy
    public string enemyTag = "Enemy";
    //Vat the dan
    public GameObject bulletprefab;
    //vi tri ban
    public Transform firepoint;
    

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        //Xac dinh quai bang tag
        GameObject[] enimies = GameObject.FindGameObjectsWithTag(enemyTag);
        //goi khoang cach gan nhat 
        float shortestDistance = Mathf.Infinity;
        //quai vat gan nhat bang null   
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enimies)
		{
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
			{
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
			}
        }
        if(nearestEnemy != null && shortestDistance <= range)
		{
            target = nearestEnemy.transform;
		}
        else
		{
            target = null;
		}
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        if(fireCountdown <= 0f)
		{
            Shoot();
            fireCountdown = 1f / fireRate;
		}
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
	{
        GameObject bulletGo = (GameObject)Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet != null)
		{
            bullet.Seek(target);
		}
	}

    //Ve tam danh cua tru
	void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
	}
}
