using UnityEngine;

public class TrajectoirePizza : MonoBehaviour
{
    public float aMaxSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        transform.Translate(dt * aMaxSpeed* Vector3.forward);
        if(transform.position.z>10)
            Destroy(gameObject);
    }
}
