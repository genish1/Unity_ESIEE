using UnityEngine;

public class FInish : MonoBehaviour
{
    public Renderer aFLag;
    public Material Mat_in;

    void OnTriggerEnter(Collider other)
    {
        aFLag.material = Mat_in;
    }
}