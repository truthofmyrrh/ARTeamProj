using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class RayCast_Spawn : MonoBehaviour
{
   
    private RaycastHit2D hit;
    private Vector2[] touches = new Vector2[5];
    public Camera camera;
    public LayerMask layermask;
    public LayerMask portionmask;
    public GameObject Clear_Portion;
    public GameObject EnemyPrefabToInstantiate;
    public List<GameObject> EnemiesSpawned;
    public List<GameObject> PortionSpawned;
    public float time = 3.0f;
    public int count = 0;
    public GameObject EnemySpawnPosition;

    public float RanMinX = 0;
    public float RanMaxX = 5f;

    public float RanMaxY = 5f;
    public float RanMinZ = 0;
    public float RanMaxZ = 5f;

    public const float SpawnInterval = 1.0f;
    private void Start()
    {
        
    }
    void Update()
    {
        
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = SpawnInterval;

            EnemiesSpawned.Add(Instantiate(EnemyPrefabToInstantiate, new Vector3(Random.Range(-RanMaxX, RanMaxX),  Random.Range(-RanMaxY, RanMaxY),Random.Range(-RanMaxZ,RanMaxZ)),transform.rotation));
            transform.position = new Vector3(0, 0, 0);
            count++;
        }

        
    }
    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {

                if (Input.GetTouch(t.fingerId).phase == TouchPhase.Began)
                {
                    checkTouch(Input.GetTouch(0).position);

                }
            }

            void checkTouch(Vector3 pos)
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit,layermask))
                {
                    if(hit.collider.gameObject.CompareTag("Enemy"))
                    {
                        PortionSpawned.Add(Instantiate(Clear_Portion, hit.transform.position,transform.rotation));
                        Destroy(hit.collider.gameObject);
                        
                    }
                }
                if (Physics.Raycast(ray, out hit,portionmask))
                {
                    if(hit.collider.gameObject.CompareTag("Clear"))
                    {
                        Destroy(hit.collider.gameObject);
                        for(int i=0;i<=count;i++){
                            Destroy(EnemiesSpawned[i]);
                        }
                    }
                }
                
            }
        }

    }

    /*
    public void DestroyEnemy(Vector3 pos)
    {

        foreach (GameObject enemy in spawns.EnemiesSpawned)
        {
            float xGap = pos.x - enemy.transform.position.x;
            float zGap = pos.z - enemy.transform.position.z;
            float yGap = pos.y - enemy.transform.position.y;

            bool includeY = Mathf.Abs(yGap) <= enemy.transform.localScale.y;
            bool includeX = Mathf.Abs(xGap) <= enemy.transform.localScale.x;
            bool includeZ = Mathf.Abs(zGap) <= enemy.transform.localScale.z;


            Debug.Log("pos.x " + pos.x + " pos.z " + pos.z + "pos.y " + pos.y);
            Debug.Log("inx " + includeX + "iny " + includeY + "includez " + includeZ);
            if (includeY && includeZ)
            {
                spawns.EnemiesSpawned.Remove(enemy);
                
                break;
            }
        }
    }*/
}
