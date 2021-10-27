using UnityEngine;

public class NoteBook : Item
{

    Animator anim;

    [SerializeField] bool notebookOpen;

    [SerializeField] private AudioClip notebookClip;

    private AudioSource audioSource;

    void Start()
    {
        UIElement = GameObject.FindGameObjectWithTag("Notebook");

        audioSource = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        anim.enabled = false;

        CheckListManager.Instance.AddItem(this);
    }

    public override void UseItem()
    {
        if (PlayerInput.Instance.currentlyUsing == false || notebookOpen == true)
        {
            OpenNotebook();
        }

    }

    void OpenNotebook()
    {

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            notebookOpen = !notebookOpen;
        }

        if (notebookOpen)
        {
            gameObject.SetActive(true);

            anim.enabled = true;

            anim.SetBool("isOpen", true);

            PlayerInput.Instance.currentlyUsing = true;

            Dialog.instance.playerCam.enabled = false;
            Dialog.instance.playerMove.enabled = false;

            MouseCursorManager.Instance.DeactivateFirstPersonControl();

        }
        else
        {
            anim.SetBool("isOpen", false);
        }

    }

    public void ActivateNotebookEvent()
    {
        PlayNotebookSound();
        ItemsManager.Instance.notebookPanel.SetActive(true);
    }

    public void ClosingNotebookEvent()
    {
        ItemsManager.Instance.notebookPanel.SetActive(false);
        Dialog.instance.playerCam.enabled = true;
        Dialog.instance.playerMove.enabled = true;
        MouseCursorManager.Instance.ActivateFirstPersonControl();
    }

    public void DeactivateNotebook()
    {
        gameObject.SetActive(false);
        PlayerInput.Instance.currentlyUsing = false;

    }

    public void PlayNotebookSound()
    {
        audioSource.clip = notebookClip;
        audioSource.Play();
    }



}
