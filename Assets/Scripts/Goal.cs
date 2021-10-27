using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SearchItemsManager.Instance.UpdateSuceedDialogue(true);
            SearchItemsManager.Instance.arrivedOnTime = true;
        }
      
    }

}
