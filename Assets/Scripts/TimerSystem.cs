using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSystem : ManagersSingleton<TimerSystem>
{

    public GameObject dialogueOne;

    [SerializeField] private TextMeshProUGUI uiText;

    public float timer;
    public bool StopTimer;
    private bool canCount = false;
    private bool doOnce = false;

    void Start()
    {

    }

    void Update()
    {
        if (timer >= 0.0f && canCount && !StopTimer)
        {

            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }
        else if(timer <= 0.0f && !doOnce && !StopTimer)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            SearchItemsManager.Instance.UpdateFailedDialgue(true, true);
        }
    }



    public void StartTimer(float externalTimer)
    {
        StopTimer = false;
        timer = externalTimer;
        canCount = true;
        doOnce = false;
    }
}
