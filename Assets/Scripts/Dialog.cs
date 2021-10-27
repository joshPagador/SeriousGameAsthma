using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public static Dialog instance;

    public PlayerCamera playerCam;
    public PlayerMovement playerMove;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index = 0;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject restartButton;
    public GameObject dialoguePanel;
    public GameObject uiMeters;

    public bool dialogueEnabled;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
        StartCoroutine(Type());
    }

    private void OnEnable()
    {
        uiMeters = GameObject.Find("Meters");
        playerCam = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCamera>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        dialogueEnabled = true;
        uiMeters.SetActive(false);
        playerCam.enabled = false;
        playerMove.enabled = false;
        MouseCursorManager.Instance.DeactivateFirstPersonControl();
        PlayerInput.Instance.enabled = false;
        TimerSystem.Instance.StopTimer = true;
        
    }

    void Update()
    {

        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);

            if (SearchItemsManager.Instance.SearchFailed == true)
            {
                if (SearchItemsManager.Instance.arrivedOnTime == true)
                {
                    restartButton.SetActive(false);
                }
                else
                {
                    restartButton.SetActive(true);
                }               
            }     
        }


    }

    IEnumerator Type()
    {

        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }


        
    }

    public void NextSentence(float timer)
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            CloseDialogue(timer);
        }
    }

    // restart the Player behaviour
    private void CloseDialogue(float timer)
    {

        textDisplay.text = "";
        uiMeters.SetActive(true);
        continueButton.SetActive(false);
        dialoguePanel.SetActive(false);
        MouseCursorManager.Instance.ActivateFirstPersonControl();
        TimerSystem.Instance.StartTimer(timer);
        playerCam.enabled = true;
        playerMove.enabled = true;
        PlayerInput.Instance.enabled = true;
        dialogueEnabled = false;
        this.gameObject.SetActive(false);
        
    
    }
}
