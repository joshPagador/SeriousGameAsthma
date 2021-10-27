using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : ManagersSingleton<PlayerInventory>
{

    public List<Item> Items = new List<Item>();

    public void AddItem(Item item)
    {
        item.Equipped = true;
        Items.Add(item);

        item.gameObject.transform.SetParent(this.gameObject.transform);

        //item.gameObject.transform.position = this.gameObject.transform.forward;
        item.gameObject.transform.localPosition = new Vector3(0, -1, 0);
        item.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        item.gameObject.SetActive(false);
    }
}
