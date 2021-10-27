using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    //List of items inside the collider "sight" of the Player
    public List<GameObject> GameObjectsToPickUp = new List<GameObject>();

    public Text equipText;

    private void Update()
    {
        //We Pick up the Items with the E key, if we have items in our sight
        if (Input.GetKeyDown(KeyCode.E) && GameObjectsToPickUp.Count > 0)
        {
            GameObject gameObjectToPickUp = GameObjectsToPickUp[0];

            for (int i = 1; i < GameObjectsToPickUp.Count; i++)
            {
                if (Vector3.Distance(this.transform.position, GameObjectsToPickUp[i].transform.position) < Vector3.Distance(this.transform.position, gameObjectToPickUp.transform.position))
                    gameObjectToPickUp = GameObjectsToPickUp[i];
            }

            Item item = gameObjectToPickUp.GetComponent<Item>();
            gameObjectToPickUp.GetComponent<Rigidbody>().isKinematic = true;

            equipText.text = "";

            //Remove item from the CheckList and Add it on the Inventory
            CheckListManager.Instance.RemoveItem(item);
            PlayerInventory.Instance.AddItem(item);

            //Remove the item from our PickUp list
            GameObjectsToPickUp.Remove(gameObjectToPickUp);
        }
    }

    //Item inside our "sight" are added to our PickUp list
    private void OnTriggerStay(Collider other)
    {

        if (!GameObjectsToPickUp.Contains(other.gameObject))
        {
            equipText.text = "Press E to pickup" + " " + other.gameObject.GetComponent<Item>().nameOfItem;
            GameObjectsToPickUp.Add(other.gameObject);
        }    
    }


    //Removing an Item from our "sight" we remove it from the PickUp list
    private void OnTriggerExit(Collider other)
    {
        if (GameObjectsToPickUp.Contains(other.gameObject))
        {
            equipText.text = "";
            GameObjectsToPickUp.Remove(other.gameObject);

        }
            
    }
}
