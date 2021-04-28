using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class monsterController : MonoBehaviour
{
    
    
    public float movementSpeed = 0.1f;
    
    public GameObject target;
    private PlayerInfo pinfo;
    private ARSession arsession;

    void Start()
    {
        
        arsession = GameObject.FindObjectOfType<ARSession>();
        pinfo = target.GetComponent<PlayerInfo>();
        target.transform.Translate(Vector3.zero);
        
    }
 
    void Update()
    {
        Vector3 forward = target.transform.position - transform.position;
        
        transform.Translate(forward.normalized * Time.deltaTime * movementSpeed);

       // Debug.Log("target : " + target.transform.position);

    }

    
    

    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.CompareTag("Player"))
        {
            // collision with player
            pinfo.ChangeHealth(pinfo.health - 1);
            
            Destroy(gameObject);

            Debug.Log("oops");
            
            
        }
    }
    
}
