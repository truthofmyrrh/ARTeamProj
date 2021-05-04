using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class monsterController : MonoBehaviour
{
    public GameObject target;
    public float movementSpeed = 0.6f;
    public  ParticleSystem particle;
    private PlayerInfo pinfo;
    private ARSession arsession;

    void Start()
    {
        target = GameObject.Find("Player");
        arsession = GameObject.FindObjectOfType<ARSession>();
        pinfo = target.GetComponent<PlayerInfo>();
        particle = GetComponent<ParticleSystem>();
    }
 
    void FixedUpdate()
    {
        Vector3 forward = target.transform.position - transform.position;
        transform.Translate(forward * Time.fixedDeltaTime * movementSpeed);

    }

    public void setParticlePos(Vector3 pos)
    {
        particle.transform.Translate(pos);
    }
    public void PlayParticle()
    {
        Debug.Log("Pop");

        //play children as well
        particle.Play(true);
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
