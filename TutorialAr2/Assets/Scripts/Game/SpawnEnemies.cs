using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject EnemyPrefabToInstantiate;
    public List<GameObject> EnemiesSpawned;
    public float time = 1.0f;


    public float RanMinX = 0;
    public float RanMaxX = 1f;

    public float RanMaxY = 0.3f;
    public float RanMinZ = 0;
    public float RanMaxZ = 1f;

    public const float SpawnInterval = 0.3f;
    // Start is called before the first frame update

    private void Start()
    {
        time = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
      time -= Time.deltaTime;
        Debug.Log("Wating For Spawning");
        if (time <= 0)
        {
            time = SpawnInterval;
            Debug.Log("Chicken is going now");
            EnemiesSpawned.Add(Instantiate(EnemyPrefabToInstantiate, new Vector3(Random.Range(-RanMaxX, RanMaxX),  Random.Range(-RanMaxY, RanMaxY),Random.Range(-RanMaxZ,RanMaxZ)),transform.rotation));
            //transform.position = new Vector3(0, 0, 0);
        }

        
    }

    //Create Random Pos to EnemySpawnPosition that make spawn enemies randomly centered to player

}
