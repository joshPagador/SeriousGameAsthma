using UnityEngine;

public class Inhaler : Item
{

    public static Inhaler instance;

    AsthmaManager asthmaMeter;

    Animator anim;

    [SerializeField] private AudioClip inhalerClip;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        UIElement = GameObject.FindGameObjectWithTag("Inhaler");
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        asthmaMeter = FindObjectOfType<AsthmaManager>();
        anim.enabled = false;
        CheckListManager.Instance.AddItem(this);
    }


    public override void UseItem()
    {
        if(PlayerInput.Instance.currentlyUsing == false)
            UseInhaler();
    }

    void UseInhaler()
    {
        if (ItemsManager.Instance.inhalerUses > 0)
        {
            if (asthmaMeter.currentAsthma < 100)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    PlayerInput.Instance.currentlyUsing = true;
                    gameObject.SetActive(true);
                    anim.enabled = true;
                    anim.SetTrigger("UseInhaler");
                }
            }
        }
    }

    public void ActivateInhalerEvent()
    {
        PlayInhalerSound();
        ItemsManager.Instance.UpdateInhalerUses(-1);
        asthmaMeter.currentAsthma += Time.deltaTime * asthmaMeter.inhalerMultiplier;
    }

    public void DeactivateInhaler()
    {
        gameObject.SetActive(false);
        PlayerInput.Instance.currentlyUsing = false;
    }

    public void PlayInhalerSound()
    {
        audioSource.clip = inhalerClip;
        audioSource.Play();
    }

}
