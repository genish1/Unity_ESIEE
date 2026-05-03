using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;

    public string GetInteractionText()
    {
        return isOpen ? "Press R to close" : "Press R to open";
    }

    public void PerformAction(KeyCode c, GameObject Character)
    {
        if (c == KeyCode.R)
        {
            isOpen = !isOpen;

            if (isOpen)
                transform.rotation = Quaternion.Euler(-89.98f, 0, 1.975f);  // ouverte
            else
                transform.rotation = Quaternion.Euler(-89.97f, 0, 90);  // fermée
        }
    }
}
