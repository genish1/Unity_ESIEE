using UnityEngine;

public class carControler : MonoBehaviour
{
    public float rotSpeed;
    public float maxSpeed;
    void Start() { }

    void Update()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("Horizontal");
        Debug.Log(hInput);

        float vInput = Input.GetAxis("Vertical");
        Debug.Log(vInput);
        if(hInput == 1)
            transform.Rotate(Vector3.up,rotSpeed*dt,0);
        if (hInput == -1)
            transform.Rotate(Vector3.up, -1 * rotSpeed * dt, 0);
        if (vInput == 1)
            transform.Translate(dt * maxSpeed*Vector3.left);
        if (vInput == -1)
            transform.Translate(dt * maxSpeed * Vector3.right);

    }
}