using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        anim.SetBool("openDoor", true);

    }

    void OnTriggerExit(Collider other)
    {
        anim.SetBool("openDoor", false);
    }



}
