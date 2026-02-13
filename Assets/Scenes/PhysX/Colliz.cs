using UnityEngine;

public class Colliz : MonoBehaviour
{
    public Material Mat_in, Mat_out;

    void OnTriggerEnter(Collider other)
    {
        Renderer objectRenderer = other.gameObject.GetComponent<Renderer>();
        objectRenderer.material = Mat_in;
    }

    void OnTriggerExit(Collider other)
    {
        Renderer objectRenderer = other.gameObject.GetComponent<Renderer>();
        objectRenderer.material = Mat_out;
    }
}