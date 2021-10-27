using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomQuestionSpawner : MonoBehaviour
{

    public QuizManager quizManager;

    public static int numberOfQuestionsAnswered = 0;

    public bool isRandomQuestion = false;

    public static List<int> numbersChosenPreviously = new List<int>();

    //choose number from 1 to 7
    public int randomNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    //spawn random quiz question
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Spawn Random Question");

            //assign the randomQuestionSpawner variable in answer script
            quizManager.answer.randomQuestionSpawner = this;

            SpawnRandomQuestion();

        }
    }

    public void SpawnRandomQuestion()
    {

        //pick number zero

        for (int i = 0; i < quizManager.question.questions.Capacity; i++)
        {
            if (!quizManager.question.questions[i].HasBeenChosen)
            {
                randomNumber = quizManager.question.questions[i].number;
                i = quizManager.question.questions.Capacity;
                break;
            }
           
        }
        

        if (quizManager.questionPanel.activeInHierarchy == true)
        {
            return;
        }

        //the camera should stop moving left and right
        quizManager.playerCamera.enabled = false;

        //the player should stop moving
        quizManager.playerMovement.enabled = false;



        MouseCursorManager.Instance.DeactivateFirstPersonControl();


        quizManager.questionPanel.SetActive(true);

        switch (randomNumber)
        {

            case 0:
                {
                    //deactivate options c and d in the answers gameobject
                    //option c
                    quizManager.answer.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    //option d
                    quizManager.answer.gameObject.transform.GetChild(3).gameObject.SetActive(false);

                    //change the question text to question 1;
                    quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[0].questionText;

                    //change the answers text
                    quizManager.answer.optionA.text = "True";
                    quizManager.answer.optionB.text = "False";

                    //know which option is wrong
                    quizManager.options[0].isCorrectOption = true;
                    quizManager.options[1].isCorrectOption = false;

                    isRandomQuestion = true;

                    //has been chosen is true
                    quizManager.question.questions[0].HasBeenChosen = true;
                }
                break;
            case 1:
                {
                    //what is the cure for asthma question

                    //change the question text
                    if (quizManager.answer.transform.GetChild(2).gameObject.activeInHierarchy == false && quizManager.answer.transform.GetChild(3).gameObject.activeInHierarchy == false)
                    {
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[1].questionText;
                    }
                    else
                    {
                        //deactivate options c and d in the answers gameobject
                        //option c
                        quizManager.answer.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                        //option d
                        quizManager.answer.gameObject.transform.GetChild(3).gameObject.SetActive(false);

                        //change the question text to question 1;
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[1].questionText;
                    }

                    //change the options text
                    quizManager.answer.optionA.text = "There is no cure";
                    quizManager.answer.optionB.text = "It depends on the patient";


                    //know which option is wrong
                    quizManager.options[0].isCorrectOption = true;
                    quizManager.options[1].isCorrectOption = false;

                    isRandomQuestion = true;

                    //has been chosen is true
                    quizManager.question.questions[1].HasBeenChosen = true;
                }
                break;
            case 2:
                {
                    //How long does an asthma attack last?

                    //change the question text
                    if (quizManager.answer.transform.GetChild(2).gameObject.activeInHierarchy == false && quizManager.answer.transform.GetChild(3).gameObject.activeInHierarchy == false)
                    {
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[2].questionText;
                    }

                    else
                    {
                        //deactivate options c and d in the answers gameobject
                        //option c
                        quizManager.answer.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                        //option d
                        quizManager.answer.gameObject.transform.GetChild(3).gameObject.SetActive(false);

                        //change the question text to question 1;
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[2].questionText;
                    }

                    //change the options text
                    quizManager.answer.optionA.text = "Usually about 2 hours";
                    quizManager.answer.optionB.text = "Several hours or days";


                    //know which option is wrong
                    quizManager.options[0].isCorrectOption = false;
                    quizManager.options[1].isCorrectOption = true;

                    isRandomQuestion = true;

                    //has been chosen is true
                    quizManager.question.questions[2].HasBeenChosen = true;
                }
                break;
            case 3:
                {
                    if (quizManager.answer.transform.GetChild(2).gameObject.activeInHierarchy == false && quizManager.answer.transform.GetChild(3).gameObject.activeInHierarchy == false)
                    {
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[3].questionText;

                        //release options c and d
                        quizManager.answer.optionC.transform.parent.parent.gameObject.SetActive(true);
                        quizManager.answer.optionD.transform.parent.parent.gameObject.SetActive(true);
                    }
                    else
                    {

                        //change the question text to question 1;
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[3].questionText;
                    }

                    //change the options text
                    quizManager.answer.optionA.text = "Crisis";
                    quizManager.answer.optionB.text = "Attack";
                    quizManager.answer.optionC.text = "Event";
                    quizManager.answer.optionD.text = "All of the above";

                    //know which option is wrong
                    quizManager.answer.options[0].isCorrectOption = false;
                    quizManager.answer.options[1].isCorrectOption = true;
                    quizManager.answer.options[2].isCorrectOption = false;
                    quizManager.answer.options[3].isCorrectOption = false;

                    isRandomQuestion = true;

                    //has been chosen is true
                    quizManager.question.questions[3].HasBeenChosen = true;
                }
                break;
            case 4:
                {
                    if (quizManager.answer.transform.GetChild(2).gameObject.activeInHierarchy == true && quizManager.answer.transform.GetChild(3).gameObject.activeInHierarchy == true)
                    {
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[4].questionText;
                    }

                    else
                    {
                        //activate options c and d in the answers gameobject
                        //option c
                        quizManager.answer.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        //option d
                        quizManager.answer.gameObject.transform.GetChild(3).gameObject.SetActive(true);

                        //change the question text to question 1;
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[4].questionText;
                    }

                    //change the options text
                    quizManager.answer.optionA.text = "Allergens or the flu";
                    quizManager.answer.optionB.text = "Smoke";
                    quizManager.answer.optionC.text = "Exercise";
                    quizManager.answer.optionD.text = "All of the above";

                    //know which option is wrong
                    quizManager.answer.options[0].isCorrectOption = false;
                    quizManager.answer.options[1].isCorrectOption = false;
                    quizManager.answer.options[2].isCorrectOption = false;
                    quizManager.answer.options[3].isCorrectOption = true;

                    isRandomQuestion = true;

                    //has been chosen is true
                    quizManager.question.questions[4].HasBeenChosen = true;
                }
                break;
            case 5:
                {
                    if (quizManager.answer.transform.GetChild(2).gameObject.activeInHierarchy == true && quizManager.answer.transform.GetChild(3).gameObject.activeInHierarchy == true)
                    {
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[5].questionText;
                    }

                    else
                    {
                        //activate options c and d in the answers gameobject
                        //option c
                        quizManager.answer.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        //option d
                        quizManager.answer.gameObject.transform.GetChild(3).gameObject.SetActive(true);

                        //change the question text to question 1;
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[5].questionText;
                    }

                    //change the options text
                    quizManager.answer.optionA.text = "Respiratory failure";
                    quizManager.answer.optionB.text = "Pulmonary hypertension";
                    quizManager.answer.optionC.text = "Allergy-related asthma";
                    quizManager.answer.optionD.text = "Exercise-induced asthma";


                    //know which option is wrong
                    quizManager.answer.options[0].isCorrectOption = true;
                    quizManager.answer.options[1].isCorrectOption = false;
                    quizManager.answer.options[2].isCorrectOption = false;
                    quizManager.answer.options[3].isCorrectOption = false;

                    isRandomQuestion = true;

                    //has been chosen is true
                    quizManager.question.questions[5].HasBeenChosen = true;
                }
                break;
            case 6:
                {
                    if (quizManager.answer.transform.GetChild(2).gameObject.activeInHierarchy == true && quizManager.answer.transform.GetChild(3).gameObject.activeInHierarchy == true)
                    {
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[6].questionText;

                        //Lock options c and d
                        quizManager.answer.optionC.transform.parent.parent.gameObject.SetActive(false);
                        quizManager.answer.optionD.transform.parent.parent.gameObject.SetActive(false);
                    }

                    else
                    {

                        //change the question text to question 1;
                        quizManager.question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizManager.question.questions[6].questionText;
                    }

                    //change the options text
                    quizManager.answer.optionA.text = "True";
                    quizManager.answer.optionB.text = "False";

                    //know which option is wrong
                    quizManager.answer.options[0].isCorrectOption = false;
                    quizManager.answer.options[1].isCorrectOption = true;

                    isRandomQuestion = true;

                    //has been chosen is true
                    quizManager.question.questions[6].HasBeenChosen = true;
                }
                break;
        }
    }
}
