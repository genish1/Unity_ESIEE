using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    private List<string> items = new List<string> { "stick", "stick" };
    public Transform inventoryUI;
    public List<Sprite> sprites;

    void Start() { RefreshUI(); }

    void RefreshUI()
    {
        int i = 0;

        foreach (Transform child in inventoryUI)
        {
            Image img = child.GetComponent<Image>();

            if (i < items.Count)
            {
                img.sprite = sprites.Find(s => s.name == items[i]);
                img.enabled = true;
                i++;
            }
            else
            {
                img.sprite = null;
                img.enabled = false;
            }
        }
    }

    public void AddItem(string name)
    {
        items.Add(name);
        RefreshUI();
    }

    public bool HasItems(string name, int count)
    {
        int found = 0;
        foreach (string item in items)
            if (item == name) found++;
        return found >= count;
    }

    public void RemoveItems(string name, int count)
    {
        int removed = 0;
        for (int i = items.Count - 1; i >= 0 && removed < count; i--)
        {
            if (items[i] == name)
            {
                items.RemoveAt(i);
                removed++;
            }
        }
        RefreshUI();
    }
    void Update() { }
}
