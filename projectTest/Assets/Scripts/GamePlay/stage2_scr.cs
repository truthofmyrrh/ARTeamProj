using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
public class stage2_scr : MonoBehaviour
{
   
    private RaycastHit2D hit;
    private Vector2[] touches = new Vector2[5];
    public Camera camera;

    public LayerMask layermask;
    public LayerMask portionmask;

    public GameObject Clear_Item;
    public GameObject Slow_Item;
    public GameObject Fast_Item;
    public GameObject Plus_Item;
    public GameObject EnemyPrefabToInstantiate;
    public GameObject User_Score;
    public GameObject User_Health;
    public GameObject temp;

    public List<GameObject> EnemiesSpawned;
    public List<GameObject> PortionSpawned;

    public float time = 3.0f;
    public int count = 0;
    public int item_count = 0;
    public int score = 0;
    public int health = 100;
    public float s = 0.3F;
    public int item_rand = 0;

    public GameObject EnemySpawnPosition;

    public Transform target;

    public float RanMinX = 0;
    public float RanMaxX = 5f;

    public float RanMaxY = 5f;
    public float RanMinZ = 0;
    public float RanMaxZ = 5f;

    public Text myScore;
    public Text myHealth;
    public const float SpawnInterval = 1.0f;
    private void Start()
    {
        myScore = User_Score.GetComponent<Text>();
        myHealth = User_Health.GetComponent<Text>();
        myScore.text = score.ToString();
        myHealth.text = health.ToString();
    }
    void Update()
    {
        time -= Time.deltaTime;
        float speed = s * Time.deltaTime;
        if (time <= 0)
        {
            time = SpawnInterval;
            temp = Instantiate(EnemyPrefabToInstantiate, new Vector3(Random.Range(-RanMaxX, RanMaxX),  Random.Range(-RanMaxY, RanMaxY),Random.Range(0,RanMaxZ)),transform.rotation);
            EnemiesSpawned.Add(temp);
            EnemiesSpawned[count].transform.LookAt(target);
            EnemiesSpawned[count].transform.position = Vector3.MoveTowards(EnemiesSpawned[count].transform.position,target.position,speed);
            transform.position = new Vector3(0, 0, 0);
            count++;
        }
        for(int i=0;i<=count;i++){
            EnemiesSpawned[i].transform.position = Vector3.MoveTowards(EnemiesSpawned[i].transform.position,target.position,speed);
            if(EnemiesSpawned[i].transform.position==target.position){
                Destroy(EnemiesSpawned[i]);
                health-=15;
            }
        }
    }
    private void FixedUpdate()
    {
        // float speed = s * Time.deltaTime;
        // for(int i=0;i<=count;i++){
        //     if(EnemiesSpawned[i].transform.position==target.position){
        //         EnemiesSpawned[count].transform.LookAt(target);
        //         EnemiesSpawned[count].transform.position = Vector3.MoveTowards(EnemiesSpawned[count].transform.position,target.transform.position,speed);
        //     }
        // }
        // for(int i=0;i<=count;i++){
        //     if(EnemiesSpawned[i].transform.position==target.position){
        //         Destroy(EnemiesSpawned[i]);
        //         health-=10;
        //     }
        // }
        myScore.text = score.ToString();
        myHealth.text = health.ToString();
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
                        item_rand = Random.Range(1,101);
                        if(item_rand>=1&&item_rand<=10){
                            PortionSpawned.Add(Instantiate(Clear_Item, hit.transform.position,transform.rotation));
                            
                        }
                        else if(item_rand>=11&&item_rand<=20){
                            PortionSpawned.Add(Instantiate(Plus_Item, hit.transform.position,transform.rotation));
                            
                        }
                        else if(item_rand>=21&&item_rand<=30){
                            PortionSpawned.Add(Instantiate(Fast_Item, hit.transform.position,transform.rotation));
                            
                        }
                        else if(item_rand>=31&&item_rand<=40){
                            PortionSpawned.Add(Instantiate(Slow_Item, hit.transform.position,transform.rotation));
                        
                        }
                        Destroy(hit.collider.gameObject);
                        // for(int k=i;k<count;k++){
                        //     EnemiesSpawned[k]=EnemiesSpawned[k+1];
                        // }
                        score+=10;
                    }
                }
                if (Physics.Raycast(ray, out hit,portionmask))
                {
                    if(hit.collider.gameObject.CompareTag("Clear"))
                    {
                        Destroy(hit.collider.gameObject);
                        // for(int i=0;i<=count;i++){
                        //     Destroy(EnemiesSpawned[i]);
                        //     count=0;
                        // }
                        EnemiesSpawned.Clear();
                        count=0;
                    }
                    else if(hit.collider.gameObject.CompareTag("Plus"))
                    {
                        Destroy(hit.collider.gameObject);
                        EnemiesSpawned.Add(Instantiate(EnemyPrefabToInstantiate, new Vector3(Random.Range(-RanMaxX, RanMaxX),  Random.Range(-RanMaxY, RanMaxY),Random.Range(-RanMaxZ,RanMaxZ)),transform.rotation));
                        count++;
                        EnemiesSpawned.Add(Instantiate(EnemyPrefabToInstantiate, new Vector3(Random.Range(-RanMaxX, RanMaxX),  Random.Range(-RanMaxY, RanMaxY),Random.Range(-RanMaxZ,RanMaxZ)),transform.rotation));
                        count++;
                        EnemiesSpawned.Add(Instantiate(EnemyPrefabToInstantiate, new Vector3(Random.Range(-RanMaxX, RanMaxX),  Random.Range(-RanMaxY, RanMaxY),Random.Range(-RanMaxZ,RanMaxZ)),transform.rotation));
                        count++;
                    }
                    else if(hit.collider.gameObject.CompareTag("Fast"))
                    {
                        Destroy(hit.collider.gameObject);
                        s+=0.1F;
                    }
                    else if(hit.collider.gameObject.CompareTag("Slow"))
                    {
                        Destroy(hit.collider.gameObject);
                        if(s>=0.1F){
                            s-=0.05F;
                        }
                    }
                }
                
            }
        }

    }

}
