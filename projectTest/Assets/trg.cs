using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trg : MonoBehaviour
{
    public GameObject User_Health;
    public Text myHealth;
    public int health=100;
    // Start is called before the first frame update
    void Start()
    {
        myHealth = User_Health.GetComponent<Text>();
        myHealth.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       myHealth.text = health.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("Hi");
            health-=10;
            myHealth.text = health.ToString();
        }
    }
}
