using UnityEngine;

public class Fireplace : MonoBehaviour, IInteractable
{
    private bool isLit = false;
    public Renderer interiorRenderer;
    public Material Mat_in;

    public string GetInteractionText()
    {
        return isLit ? "The fire is burning" : "Press R to light the fire";
    }

    public void PerformAction(KeyCode c, GameObject character)
    {
        if (c == KeyCode.R && !isLit)
        {
            Backpack backpack = character.GetComponent<Backpack>();

            if (backpack == null) return;

            if (!backpack.HasItems("stick", 5))
            {
                Debug.Log("You need 5 sticks to light the fire.");
                return;
            }

            backpack.RemoveItems("stick", 5);
            isLit = true;

            if (interiorRenderer != null)
                interiorRenderer.material = Mat_in;
        }
    }
}
