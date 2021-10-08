using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject playerObj;
    public float speed = 4.0f;
    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }
        Vector3 lookDirection = (playerObj.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);
    }
}
