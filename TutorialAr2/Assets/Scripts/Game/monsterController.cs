using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class monsterController : MonoBehaviour
{
    
    
    public float movementSpeed = 0.1f;
    
    private GameObject target;
    private PlayerInfo pinfo;
    private ARSession arsession;
    

    void Start()
    {
        
        arsession = GameObject.FindObjectOfType<ARSession>();
        
        target = GameObject.Find("AR Session Origin").transform.GetChild(1).gameObject;
        pinfo = target.GetComponent<PlayerInfo>();
    }
 
    void Update()
    {
        Debug.Log(target.name);
        Vector3 forward = target.transform.position - transform.position;
        
        transform.Translate(forward.normalized * Time.deltaTime * movementSpeed);

       // Debug.Log("target : " + target.transform.position);

    }

    
    

    private void OnTriggerEnter(Collider other)
    {

       
        if(other.gameObject.CompareTag("User"))
        {
            
            // collision with player
            pinfo.ChangeHealth(pinfo.health - 1);
            
            Destroy(gameObject);

            
            
            
        }
    }
    
}
