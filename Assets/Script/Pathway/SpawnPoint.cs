using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Noi sinh ra quai
public class SpawnPoint : MonoBehaviour
{
    //Cau truc wave linh
    [System.Serializable]
    public class Wave
	{
        //Thoi gian tre wave hoat dong
        public float timeBeforeWave;
        //Danh sach quai duoc sinh ra trong 1 wave
        public List<GameObject> enemies;
	}

    //Neu linh khong duoc cai dat thi, lay quai tu folder su dung random
    public string enemiesPrefabsFolder = "Enemies";
    //Linh co toc do di chuyen khac nhau
    public float speedRandomizer = 0.2f;
    // Do tre sinh ra giua linh trong wave 
    public float unitSpawnDelay = 0.8f;
    //Danh sach wave trong vi tri sinh ra linh
    public List<Wave> waves;

    //Linh di chuyen tren duong thang
    private Pathway path;
    //Wave gan nhat

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
