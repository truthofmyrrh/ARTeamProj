using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class RayCast_Spawn : MonoBehaviour
{
    private GameUI ui;
    private RaycastHit2D hit;
    private Vector2[] touches = new Vector2[5];
    private float waittime = 1.0f;
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
                        ui.incrementScore();
                        Transform t = hit.transform;
                        Destroy(hit.collider.gameObject);
                        GameObject portion = Instantiate(Clear_Portion, t.position, t.rotation);


                        StartCoroutine(WaitTime());
                        PortionSpawned.Add(portion);
                        portion.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
                        
                       
                        
                    }
                }
                else if (Physics.Raycast(ray, out hit,portionmask))
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

    IEnumerator WaitTime()
    { 
            yield return new WaitForSeconds(waittime);
        
    }

}
