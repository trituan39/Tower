using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //dat vi tri quai la muc tieu
    public Transform target;
    //dat khoang cach tru la float
    public float range;
    //Dat tag quai vat la Enemy
    public string enemyTag = "Enemy";
    // Start is called before the first frame update
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
    }

    //Ve tam danh cua tru
	void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
	}
}
