using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : ManagersSingleton<PlayerInput>
{


    public Animator checklistAnim;

    [SerializeField] bool checklistOpen;


    public bool currentlyUsing;



    void Update()
    {
        OpenChecklist();

        //We check if the Player wants to use the Items in his Inventory
        for (int i = 0; i < PlayerInventory.Instance.Items.Count; i++)
            PlayerInventory.Instance.Items[i].UseItem();
    }

    void OpenChecklist()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            checklistOpen = !checklistOpen;
        }

        if(checklistOpen)
        {
            checklistAnim.SetBool("Open", true);
        }
        else
        {
            checklistAnim.SetBool("Open", false);
        }
    }
}
