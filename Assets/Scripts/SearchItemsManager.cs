using UnityEngine;

public class SearchItemsManager : ManagersSingleton<SearchItemsManager>
{
    public GameObject[] SucceedDialogue;
    public GameObject[] SucceedDialoguePanels;
    public GameObject[] FailedDialogue;
    public GameObject[] FailedDialoguePanels;

    public bool SearchFailed = false;
    public bool arrivedOnTime = false;
    private int succeedIndex;
    private int failedIndex;

    //Show the next FailedDialogue
    public void UpdateFailedDialgue(bool updateSucceedDialogue, bool searchFailed)
    {
        if (failedIndex < FailedDialogue.Length)
        {
            FailedDialogue[failedIndex].SetActive(true);
            FailedDialoguePanels[failedIndex].SetActive(true);
            failedIndex++;
            SearchFailed = searchFailed;

            if (updateSucceedDialogue)
                succeedIndex++;
        }
        else
            Debug.LogError("The index is greater than the number of dialogues");
    }

    //Show the next SucceedDiallogue
    public void UpdateSuceedDialogue(bool updateFailedDialogue)
    {
        if (succeedIndex < SucceedDialogue.Length)
        {
            SucceedDialogue[succeedIndex].SetActive(true);
            SucceedDialoguePanels[succeedIndex].SetActive(true);
            succeedIndex++;

            if (updateFailedDialogue)
                failedIndex++;
        }
        else
        {
            Debug.LogError("The index is greater of the number of dialogues");

        }
    }
}
