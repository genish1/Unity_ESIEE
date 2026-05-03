using UnityEngine;
using TMPro;

public class Picker : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;

    public TextMeshProUGUI interactionText;

    //void Update()
    //{
    //    Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

    //    if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayer))
    //        interactionText.text = "Object in range";
    //    else
    //        interactionText.text = "+";
    //}
    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactionText.text = interactable.GetInteractionText();

                if (Input.GetKeyDown(KeyCode.R))
                    interactable.PerformAction(KeyCode.R, gameObject);
            }
        }
        else
            interactionText.text = "+";
    }
}