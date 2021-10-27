using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsthmaManager : MonoBehaviour
{
    public static AsthmaManager instance;

    //Stamina
    public float currentStamina;
    public float regenStamina;
    public Slider staminaBar;

    //Asthma
    public float currentAsthma;
    public float asthmaThreshold;
    public float asthmaOverTime;
    public float inhalerMultiplier;
    public Slider asthmaBar;
    public Animator asthmaAnim;

    public PlayerMovement player;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        staminaBar.maxValue = currentStamina;
        asthmaBar.maxValue = currentAsthma;

        UIUpdate();
    }

    void Update()
    {
        UIUpdate();
        AffectAsthma();
        AffectStamina();
    }

    void AffectStamina()
    {
        //Keep lowering asthma if stamina is below a certain point
        if (currentStamina < asthmaThreshold)
        {
            currentAsthma -= asthmaOverTime * Time.deltaTime;
        }
        if (currentStamina < 30)
        {
            player.walkSpeed = 1f;
            player.runSpeed = 3f;
        }
        if (currentStamina <= 0)
        {
            player.walkSpeed = 1f;
            player.runSpeed = 1f;
        }
    }

    void AffectAsthma()
    {
        //Asthma
        if (currentAsthma <= 30)
        {
            asthmaAnim.SetBool("AsthmaAttackIncoming", true);
            player.walkSpeed = 1f;
            player.runSpeed = 3f;

            if (currentAsthma <= 0)
            {
                SceneManagement.instance.GamerOver();
                Debug.Log("You are having an asthma attack!");
            }
        }      
        else
        {
            asthmaAnim.SetBool("AsthmaAttackIncoming", false);
            player.walkSpeed = 3f;
            player.runSpeed = 7f;
        }
    }

    //Function called to lower asthma
    public void LowerAsthma(int multiplier)
    {
        //Lower stamina when sprinting or jumping
        if (currentAsthma >= 0)
        {
            currentAsthma -= Time.deltaTime * multiplier;
        }

    }


    //Function called to lower stamina when sprinting or jumping
    public void LowerStamina(int multiplier)
    {
        //Lower stamina when sprinting or jumping
        if(currentStamina > 0)
        {
            currentStamina -= Time.deltaTime * multiplier;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(StaminaRegen());
        }
        else
        {    
            Debug.Log("No stamina");
        }
    }

    //regen stamina after a few seconds
    private IEnumerator StaminaRegen()
    {
        yield return new WaitForSeconds(1);
        while(currentStamina < 100)
        {
            currentStamina += regenStamina;

            yield return regenTick;
        }

        regen = null;
        
    }


    //Make sure values are between 0 - 100
    void UIUpdate()
    {
        currentStamina = Mathf.Clamp(currentStamina, 0, 100f);
        currentAsthma = Mathf.Clamp(currentAsthma, 0, 100f);


        staminaBar.value = currentStamina;
        asthmaBar.value = currentAsthma;
    }

   
}
