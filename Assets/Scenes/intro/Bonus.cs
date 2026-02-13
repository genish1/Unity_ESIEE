using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public float RotSpeed;
    public Material m1;
    public Material m2;
    void Start() { }

    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        int vTime = (int) Time.time;
        if (vTime % 2 == 0)
            r.material = m1;
        else
            r.material = m2;
        float angle = Time.deltaTime * RotSpeed;   
        transform.Rotate(0,angle, 0);
    }
}