using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float intensity = 2000f;
    public float maxSpeed;
    private Rigidbody rb;
    private GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
        maxSpeed = 5f * 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        float dT = Time.deltaTime;

        Vector3 V = Player.transform.position - transform.position;
        V.y = 0;
        V.Normalize();

        rb.AddForce(V * intensity * dT);

        Vector3 velocity = rb.linearVelocity;
        Debug.Log(velocity.magnitude);

        if (velocity.magnitude > maxSpeed)
            rb.linearVelocity = velocity.normalized * maxSpeed;
    }
}
