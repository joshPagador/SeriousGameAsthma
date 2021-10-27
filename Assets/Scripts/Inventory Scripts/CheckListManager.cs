using System.Collections.Generic;
using UnityEngine;

public class CheckListManager : ManagersSingleton<CheckListManager>
{
    [Tooltip("List that represents the items in the CheckList")]
    public List<Item> CheckListItems = new List<Item>();

    //Add an Item to the CheckList for the Player to find
    public void AddItem(Item item)
    {
        CheckListItems.Add(item);
    }


    //Remove an Item from the CheckList for the Player to find
    public void RemoveItem(Item item)
    {
        item.UIElement.SetActive(false);

        CheckListItems.Remove(item);

        if (CheckListItems.Count == 0 && !SearchItemsManager.Instance.SearchFailed)
            SearchItemsManager.Instance.UpdateSuceedDialogue(true);
    }
}
