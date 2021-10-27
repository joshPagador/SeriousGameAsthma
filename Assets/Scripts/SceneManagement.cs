using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;

    public GameObject gameOverPanel;

    public PlayerCamera playerCam;
    public PlayerMovement playerMove;

    public GameObject[] allDialogues;

    void Awake()
    {
        instance = this;   
    }

    public void thisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GamerOver()
    {   
        foreach (GameObject e in allDialogues)
            Destroy(e);

        gameOverPanel.SetActive(true);
        MouseCursorManager.Instance.DeactivateFirstPersonControl();
        playerCam.enabled = false;
        playerMove.enabled = false;
        Time.timeScale = 0f;
    }



}
