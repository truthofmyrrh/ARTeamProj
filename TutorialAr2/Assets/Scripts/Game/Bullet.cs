using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    public float speed = 1.0f;
    private Vector3 dir;
    void Start()
    {
        player = GameObject.Find("Player");
        dir = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir.normalized * Time.deltaTime * speed);
    }
}
