using UnityEngine;

public class YellowScript : MonoBehaviour
{
    public int rotSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dT = Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.up, rotSpeed * dT);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up, -rotSpeed * dT);
    }
}

