using UnityEngine;
using System.Collections;

public class WaterBottle : Item
{

    public static WaterBottle instance;

    Animator anim;

    [SerializeField] private AudioClip waterClip;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        UIElement = GameObject.FindGameObjectWithTag("Waterbottle");

        audioSource = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        anim.enabled = false;

        CheckListManager.Instance.AddItem(this);
    }



    public override void UseItem()
    {
        if (PlayerInput.Instance.currentlyUsing == false)
            DrinkWater();


    }

    void DrinkWater()
    {
        if (ItemsManager.Instance.waterLeft > 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                PlayerInput.Instance.currentlyUsing = true;

                gameObject.SetActive(true);

                anim.enabled = true;

                anim.SetTrigger("UseWater");

                Debug.Log("Waterbottle used!");
            }
        }
            
    }

    private IEnumerator StaminaRegenFaster()
    {
        AsthmaManager.instance.regenStamina = 4;
        yield return new WaitForSeconds(1);
        AsthmaManager.instance.regenStamina = 1;
    }


    public void ActivateWaterEvent()
    {

        StartCoroutine(StaminaRegenFaster());

        PlayWaterSound();

        ItemsManager.Instance.UpdateWaterLeft(-1);
    }

    public void DeactivateWater()
    {
        gameObject.SetActive(false);
        PlayerInput.Instance.currentlyUsing = false;
    }

    public void PlayWaterSound()
    {
        audioSource.clip = waterClip;
        audioSource.Play();
    }



}
