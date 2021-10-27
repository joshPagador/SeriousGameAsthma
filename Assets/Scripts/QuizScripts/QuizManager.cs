using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public GameObject questionPanel;
    public GameObject scorePanel;
    public PlayerCamera playerCamera;
    public PlayerMovement playerMovement;

    public Question question;
    public Answer answer;
    public Option[] options;

    public static int score = 0;
    public bool QuizHasEnded = false;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        questionPanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (QuizHasEnded == true)
        {
            if (Input.anyKeyDown)
            {
                scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Score goes here!";
                scorePanel.SetActive(false);

                StartCoroutine(Reset());
            }
        }

        //if (RandomQuestionSpawner.numberOfQuestionsAnswered == 7)
        //{
        //    EndRandomQuestionQuiz();
        //    RandomQuestionSpawner.numberOfQuestionsAnswered = 0;
        //}

        if (score >= 0)
        {
            return;
        }

        if (score < 0)
        {
            score = 0;
        }


    }

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(2f);
        //reset the score
        score = 0;

        answer.numberOfClicks = 0;

        QuizHasEnded = false;
    }

    public void StartQuiz()
    {
        if (questionPanel.activeInHierarchy == true)
        {
            return;
        }

        if (QuizHasEnded == true)
        {
            return;
        }
        //the camera should stop moving left and right
        playerCamera.enabled = false;

        //the player should stop moving
        playerMovement.enabled = false;

        MouseCursorManager.Instance.DeactivateFirstPersonControl();

        questionPanel.SetActive(true);

        //deactivate options c and d in the answers gameobject
        //option c
        answer.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        //option d
        answer.gameObject.transform.GetChild(3).gameObject.SetActive(false);

        //change the question text to question 1;
        question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = question.questions[0].questionText;

        //change the answers text
        answer.optionA.text = "True";
        answer.optionB.text = "False";

        //know which option is wrong
        options[0].isCorrectOption = true;
        options[1].isCorrectOption = false;
    }

    public void EndQuiz()
    {
        if (questionPanel.activeInHierarchy == false)
        {
            return;
        }

        //the camera should stop moving left and right
        playerCamera.enabled = true;

        //the player should stop moving
        playerMovement.enabled = true;

        MouseCursorManager.Instance.ActivateFirstPersonControl();

        //change the question text to question 1;
        question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Question goes here";

        //change the answers text
        answer.optionA.text = "Option A";
        answer.optionB.text = "Option B";
        answer.optionC.text = "Option C";
        answer.optionD.text = "Option D";

        questionPanel.SetActive(false);

        //show the player score
        scorePanel.SetActive(true);
        switch (score)
        {
            case 0:
                {
                    scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, you lose!";
                }
                break;
            case 1:
                {
                    scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, please try again";
                }
                break;
            case 2:
                {
                    scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7. try again!";
                }
                break;
            case 3:
                {
                    scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, do better next time";
                }
                break;
            case 4:
                {
                    scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, do better next time";
                }
                break;
            case 5:
                {
                    scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, do better next time";
                }
                break;
            case 6:
                {
                    scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, you can do better";

                }
                break;
            case 7:
                {
                    scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = " Congratulations! You got " + score + " out of 7";
                }
                break;
            default:
                break;
        }
    }

    //public void EndRandomQuestionQuiz()
    //{

    //    //the camera should stop moving left and right
    //    playerCamera.enabled = true;

    //    //the player should stop moving
    //    playerMovement.enabled = true;

    //    MouseCursorManager.Instance.ActivateFirstPersonControl();


    //    //change the question text to question 1;
    //    question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Question goes here";

    //    //change the answers text
    //    answer.optionA.text = "Option A";
    //    answer.optionB.text = "Option B";
    //    answer.optionC.text = "Option C";
    //    answer.optionD.text = "Option D";

    //    questionPanel.SetActive(false);

      
    //        //end quiz
    //        QuizHasEnded = true;
    //        //show the player score
    //        scorePanel.SetActive(true);

    //    switch (score)
    //    {
    //        case 0:
    //            {
    //                scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, you lose!";
    //            }
    //            break;
    //        case 1:
    //            {
    //                scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, please try again";
    //            }
    //            break;
    //        case 2:
    //            {
    //                scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7. try again!";
    //            }
    //            break;
    //        case 3:
    //            {
    //                scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, do better next time";
    //            }
    //            break;
    //        case 4:
    //            {
    //                scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, do better next time";
    //            }
    //            break;
    //        case 5:
    //            {
    //                scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, do better next time";
    //            }
    //            break;
    //        case 6:
    //            {
    //                scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You got " + score + " out of 7, you can do better";

    //            }
    //            break;
    //        case 7:
    //            {
    //                scorePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = " Congratulations! You got " + score + " out of 7";
    //            }
    //            break;

    //    }
    //}

    public void StopTheQuestion()
    {
        if (questionPanel.activeInHierarchy == false)
        {
            return;
        }

        //the camera should stop moving left and right
        playerCamera.enabled = true;

        //the player should stop moving
        playerMovement.enabled = true;


        MouseCursorManager.Instance.ActivateFirstPersonControl();


        //change the question text to question 1;
        question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Question goes here";

        //change the answers text
        answer.optionA.text = "Option A";
        answer.optionB.text = "Option B";
        answer.optionC.text = "Option C";
        answer.optionD.text = "Option D";

        questionPanel.SetActive(false);
    }
}
