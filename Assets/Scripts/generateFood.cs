using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateFood : MonoBehaviour
{
    public Transform[] SpawnPoints;//生成一個座標陣列
    public float spawnTime = 2.5f;//多久生成
    public GameObject[] Items;
    // Start is called before the first frame update
    void Start()
    {
        int spawnIndex = Random.Range(0,SpawnPoints.Length);
        int ItemIndex = Random.Range(0,Items.Length);
        Instantiate(Items[ItemIndex],SpawnPoints[spawnIndex].position,SpawnPoints[spawnIndex].rotation);
        InvokeRepeating("SpawnItems",spawnTime,spawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnItems(){
        int spawnIndex = Random.Range(0,SpawnPoints.Length);
        int ItemIndex = Random.Range(0,Items.Length);
        Instantiate(Items[ItemIndex],SpawnPoints[spawnIndex].position,SpawnPoints[spawnIndex].rotation);
    }
}
