using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject EnemyPrefabToInstantiate;
    public List<GameObject> EnemiesSpawned;
    public float time = 3.0f;

    public GameObject EnemySpawnPosition;

    public float RanMinX = 0;
    public float RanMaxX = 5f;

    public float RanMaxY = 5f;
    public float RanMinZ = 0;
    public float RanMaxZ = 5f;

    public const float SpawnInterval = 1.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = SpawnInterval;

            EnemiesSpawned.Add(Instantiate(EnemyPrefabToInstantiate, new Vector3(Random.Range(-RanMaxX, RanMaxX),  Random.Range(-RanMaxY, RanMaxY),Random.Range(-RanMaxZ,RanMaxZ)),transform.rotation));
            transform.position = new Vector3(0, 0, 0);
        }

        
    }

    //Create Random Pos to EnemySpawnPosition that make spawn enemies randomly centered to player

}