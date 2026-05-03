using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class CharacterMover : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 5f;                // Speed of the character
    public float rotationSpeed = 200f;      // Speed of rotation

    public Transform cameraPivot;
    public float tiltSpeed = 120f;
    public float minmax = 60f;
    float pitch = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        // Rotate character
        transform.Rotate(Vector3.up, hInput * rotationSpeed * Time.deltaTime);

        // Moves the character forward
        characterController.SimpleMove(transform.forward * vInput * speed);

        // US keycode
        if (Input.GetKey(KeyCode.Q)) pitch += tiltSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) pitch -= tiltSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -minmax, minmax);

        // localRotation.Xrot = pitch
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
