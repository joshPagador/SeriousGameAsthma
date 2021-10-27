using UnityEngine;

public class Item : MonoBehaviour
{
    [Tooltip("Name of the Item")]
    public string nameOfItem;

    [Tooltip("UiElement of this Item")]
    public GameObject UIElement;

    public bool Equipped;

    // Function to override to provide functionality to every item
    public virtual void UseItem()
    {
    }
}
