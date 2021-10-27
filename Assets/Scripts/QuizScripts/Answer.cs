using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public Question question;
    public Option[] options;
    public QuizManager quizManager;

    public int numberOfClicks = 0;

    public TextMeshProUGUI optionA;
    public TextMeshProUGUI optionB;
    public TextMeshProUGUI optionC;
    public TextMeshProUGUI optionD;

    public RandomQuestionSpawner randomQuestionSpawner;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChangeQuestion(Option option)
    {
        if (randomQuestionSpawner.isRandomQuestion)
        {
            switch (randomQuestionSpawner.randomNumber)
            {
                case 0:
                    {
                        //know which option is chosen
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        
                        randomQuestionSpawner.isRandomQuestion = false;
                        quizManager.StopTheQuestion();
                        ++RandomQuestionSpawner.numberOfQuestionsAnswered;
                    }
                    break;
                case 1:
                    {
                        //know which option is chosen
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        
                        randomQuestionSpawner.isRandomQuestion = false;
                        quizManager.StopTheQuestion();
                        ++RandomQuestionSpawner.numberOfQuestionsAnswered;
                    }
                    break;

                case 2:
                    {
                        //know which option is chosen
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        
                        randomQuestionSpawner.isRandomQuestion = false;
                        quizManager.StopTheQuestion();
                        ++RandomQuestionSpawner.numberOfQuestionsAnswered;
                    }
                    break;

                case 3:
                    {
                        //know which option is chosen
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        
                        randomQuestionSpawner.isRandomQuestion = false;
                        quizManager.StopTheQuestion();
                        ++RandomQuestionSpawner.numberOfQuestionsAnswered;
                    }
                    break;

                case 4:
                    {
                        //know which option is chosen
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        
                        randomQuestionSpawner.isRandomQuestion = false;
                        quizManager.StopTheQuestion();
                        ++RandomQuestionSpawner.numberOfQuestionsAnswered;
                    }
                    break;

                case 5:
                    {
                        //know which option is chosen
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        randomQuestionSpawner.isRandomQuestion = false;
                        quizManager.StopTheQuestion();
                        ++RandomQuestionSpawner.numberOfQuestionsAnswered;
                    }
                    break;

                case 6:
                    {
                        //know which option is chosen
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }


                        randomQuestionSpawner.isRandomQuestion = false;
                        quizManager.StopTheQuestion();
                        ++RandomQuestionSpawner.numberOfQuestionsAnswered;
                    }
                    break;
                default:
                    break;

            }
            //deactivate the spawn random question object 

            randomQuestionSpawner.gameObject.SetActive(false);
            
            
        }

        else
        {
            numberOfClicks++;

            switch (numberOfClicks)
            {
                case 1:
                    {
                        //what is the cure for asthma question

                        //know which option is chosen
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        


                        //change the question text
                        if (transform.GetChild(2).gameObject.activeInHierarchy == false && transform.GetChild(3).gameObject.activeInHierarchy == false)
                        {
                            question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = question.questions[1].questionText;
                        }

                        //change the options text
                        optionA.text = "There is no cure";
                        optionB.text = "It depends on the planet";


                        //know which option is wrong
                        options[0].isCorrectOption = true;
                        options[1].isCorrectOption = false;

                    }
                    break;

                case 2:
                    {
                        //How long does an asthma attack last?

                        //know which option is chosen
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        

                        if (transform.GetChild(2).gameObject.activeInHierarchy == false && transform.GetChild(3).gameObject.activeInHierarchy == false)
                        {
                            question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = question.questions[2].questionText;
                        }

                        //change the options text
                        optionA.text = "Usually about 2 hours";
                        optionB.text = "Several hours or days";


                        //know which option is wrong
                        options[0].isCorrectOption = false;
                        options[1].isCorrectOption = true;
                    }
                    break;

                case 3:
                    {
                        // An asthma ______________ occurs when asthma symptoms become worse than usual.

                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        

                        if (transform.GetChild(2).gameObject.activeInHierarchy == false && transform.GetChild(3).gameObject.activeInHierarchy == false)
                        {
                            question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = question.questions[3].questionText;

                            //release options c and d
                            optionC.transform.parent.parent.gameObject.SetActive(true);
                            optionD.transform.parent.parent.gameObject.SetActive(true);
                        }

                        //change the options text
                        optionA.text = "Crisis";
                        optionB.text = "Attack";
                        optionC.text = "Event";
                        optionD.text = "All of the above";

                        //know which option is wrong
                        options[0].isCorrectOption = false;
                        options[1].isCorrectOption = true;
                        options[2].isCorrectOption = false;
                        options[3].isCorrectOption = false;

                    }
                    break;

                case 4:
                    {
                        //What causes an asthma attack?

                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        

                        if (transform.GetChild(2).gameObject.activeInHierarchy == true && transform.GetChild(3).gameObject.activeInHierarchy == true)
                        {
                            question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = question.questions[4].questionText;
                        }

                        //change the options text
                        optionA.text = "Allergens or the flu";
                        optionB.text = "Smoke";
                        optionC.text = "Exercise";
                        optionD.text = "All of the above";

                        //know which option is wrong
                        options[0].isCorrectOption = false;
                        options[1].isCorrectOption = false;
                        options[2].isCorrectOption = false;
                        options[3].isCorrectOption = true;
                    }
                    break;

                case 5:
                    {


                        //The body's poor exchange of oxygen and carbon dioxide describes…

                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        
                        if (transform.GetChild(2).gameObject.activeInHierarchy == true && transform.GetChild(3).gameObject.activeInHierarchy == true)
                        {
                            question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = question.questions[5].questionText;
                        }

                        //change the options text
                        optionA.text = "Respiratory failure";
                        optionB.text = "Pulmonary hypertension";
                        optionC.text = "Allergy-related asthma";
                        optionD.text = "Exercise-induced asthma";


                        //know which option is wrong
                        options[0].isCorrectOption = true;
                        options[1].isCorrectOption = false;
                        options[2].isCorrectOption = false;
                        options[3].isCorrectOption = false;
                    }
                    break;

                case 6:
                    {
                        //Asthma can be cured, so it is not serious and nobody dies from it.

                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }

                        

                        if (transform.GetChild(2).gameObject.activeInHierarchy == true && transform.GetChild(3).gameObject.activeInHierarchy == true)
                        {
                            question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = question.questions[6].questionText;

                            //Lock options c and d
                            optionC.transform.parent.parent.gameObject.SetActive(false);
                            optionD.transform.parent.parent.gameObject.SetActive(false);

                            //change the options text
                            optionA.text = "True";
                            optionB.text = "False";

                            //know which option is wrong
                            options[0].isCorrectOption = false;
                            options[1].isCorrectOption = true;
                        }
                    }
                    break;
                default:
                    {
                        Debug.Log("Default case");
                        //final question answered
                        if (option.isCorrectOption)
                        {
                            ++QuizManager.score;
                        }



                        //end quiz
                        quizManager.QuizHasEnded = true;
                        quizManager.EndQuiz();
                    }
                    break;
            }
        }
        
    }
}
