using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{
    public float intensity;
    private float maxSpeed = 5f;
    public bool hasPowerUp = false;
    public GameObject powerUpIndicator;

    void Start()
    {

    }

    void Update()
    {
        float dT = Time.deltaTime;
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");
        Rigidbody rb = GetComponent<Rigidbody>();
        GameObject cam = GameObject.Find("Main Camera");
        GameObject center = GameObject.Find("Focal Point");

        Vector3 V = center.transform.position - cam.transform.position;
        V.y = 0;
        V.Normalize();
        Vector3 V2 = Quaternion.Euler(0, 90, 0) * V;

        rb.AddForce(V * intensity * dT * vInput);
        rb.AddForce(V2 * intensity * dT * hInput);

        Vector3 velocity = rb.linearVelocity;
        Debug.Log(velocity.magnitude);
        if (velocity.magnitude > maxSpeed)
            rb.linearVelocity = velocity.normalized * maxSpeed;
    }

    private void TakePowerup(GameObject powerupObject)
    {
        hasPowerUp = true;
        Destroy(powerupObject);
        powerUpIndicator.SetActive(true);
        StartCoroutine(EndPowerup());
    }

    IEnumerator EndPowerup()
    {
        yield return new WaitForSeconds(5);

        // Stop powerup
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            TakePowerup(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            hasPowerUp = false;
            powerUpIndicator.SetActive(false);
            Debug.Log("Enemy touché ! hasPowerUp = " + hasPowerUp);
            Vector3 pushDirection = collision.transform.position - transform.position;
            pushDirection.y = 0;
            pushDirection.Normalize();

            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            enemyRb.AddForce(pushDirection * 25, ForceMode.Impulse);

            EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            enemyScript.enabled = false;

            StartCoroutine(FreezeEnemyAfterDelay(enemyRb, 0.3f));
        }
    }

    IEnumerator FreezeEnemyAfterDelay(Rigidbody enemyRb, float delay)
    {
        yield return new WaitForSeconds(delay);
        enemyRb.constraints = RigidbodyConstraints.FreezeAll;
    }
}