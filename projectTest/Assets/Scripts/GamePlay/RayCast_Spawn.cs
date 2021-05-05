using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class RayCast_Spawn : MonoBehaviour
{
    private GameUI ui;
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
        ui = GameObject.Find("PlayManager").GetComponent<GameUI>();
        
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
                        hit.collider.gameObject.transform.GetChild(5).GetComponent<ParticleSystem>().Play(true);
                        Destroy(hit.collider.gameObject);
                        ui.incrementScore();
                       
                        
                    }
                }
                if (Physics.Raycast(ray, out hit,portionmask))
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
