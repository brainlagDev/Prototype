using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupindicator;

    public float speed = 5.0f;
    public bool hasPowerup;
    public float powerupStrength = 15.0f;

    private Vector3 offsetForPowerUp = new Vector3(0, 0.5f, 0);
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        powerupindicator.transform.position = transform.position - offsetForPowerUp;
        float VerticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * VerticalInput);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            powerupindicator.gameObject.SetActive(true);
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine("PowerupActive");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 fromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(fromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Hit the enemy with PU");
        }
    }
    IEnumerator PowerupActive()
    {
        yield return new WaitForSeconds(7);
        powerupindicator.gameObject.SetActive(false);
        hasPowerup = false;
    }
}
