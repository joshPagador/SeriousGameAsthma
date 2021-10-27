using UnityEngine;

public class Medicine : Item
{

    public static Medicine instance;

    Animator anim;

    [SerializeField] private AudioClip medicineClip;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UIElement = GameObject.FindGameObjectWithTag("Medicine");

        audioSource = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        anim.enabled = false;

        CheckListManager.Instance.AddItem(this);
    }



    public override void UseItem()
    {
        //EXAMPLE
        if (PlayerInput.Instance.currentlyUsing == false)
            UseMedicine();
            
    }

    void UseMedicine()
    {
        if (ItemsManager.Instance.medicine > 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PlayerInput.Instance.currentlyUsing = true;

                gameObject.SetActive(true);

                anim.enabled = true;

                anim.SetTrigger("UseMedicine");

                Debug.Log("Medicine used!");
            }
        }
    }

    public void ActivateMedicineEvent()
    {
        PlayMedicineSound();
        AsthmaManager.instance.asthmaOverTime = 3f;
        AsthmaManager.instance.asthmaThreshold = 60f;
        ItemsManager.Instance.UpdateMedicineLeft(-1);
    }

    public void DeactivateMedicine()
    {
        gameObject.SetActive(false);
        PlayerInput.Instance.currentlyUsing = false;
    }

    public void PlayMedicineSound()
    {
        audioSource.clip = medicineClip;
        audioSource.Play();
    }
}
