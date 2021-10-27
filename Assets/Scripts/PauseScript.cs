using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : ManagersSingleton<PauseScript>
{

    public bool gamePaused = false;  //whether or not game is paused
    public GameObject pauseMenuCanvas;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Dialog.instance.dialogueEnabled == false)
        {
            gamePaused = !gamePaused;  

        }

        if (gamePaused == true)
        {
            pauseMenuCanvas.SetActive(true); //sets pause canvas to be visible
            MouseCursorManager.Instance.DeactivateFirstPersonControl();
            Time.timeScale = 0f;  //freezes the game
        }
        else
        {


            pauseMenuCanvas.SetActive(false); // sets pause canvas to be invisible
            Time.timeScale = 1f; //unfreeze game  - moves in realtime
        }
    
    }


    public void Resume()
    {
        MouseCursorManager.Instance.ActivateFirstPersonControl();

        gamePaused = false; //function that is called upon in game when resume button is pressed 

    }
}
