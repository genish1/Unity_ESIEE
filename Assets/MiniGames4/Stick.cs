using UnityEngine;

public class Stick : MonoBehaviour, IInteractable
{
    public string GetInteractionText()
    {
        return "Press R to collect";
    }

    public void PerformAction(KeyCode c, GameObject Character)
    {
        if (c == KeyCode.R)
        {
            Backpack backpack = Character.GetComponent<Backpack>();

            if (backpack != null)
            {
                backpack.AddItem("stick");
                Destroy(gameObject);
            }
        }
    }

}
