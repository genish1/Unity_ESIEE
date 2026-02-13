using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public GameObject pizzaSlice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("Horizontal");

        if (hInput == 1 && transform.position.x <=5)
            transform.Translate(dt * maxSpeed * Vector3.right);
        if (hInput == -1 && transform.position.x >= -5)
            transform.Translate(dt * maxSpeed * Vector3.left);
        if (Input.GetKeyDown(KeyCode.Space))
            Object.Instantiate(pizzaSlice, transform.position, Quaternion.Euler(0f,0f,0f));
    }
}
