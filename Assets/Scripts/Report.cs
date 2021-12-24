using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Report : MonoBehaviour
{
    public GameObject[] answer0Options;
    public GameObject[] answer1Options;
    public GameObject[] answer2Options;
    public GameObject[] answer3Options;
    public GameObject[] answer4Options;

    private int[] currentAnswerOptions = { 0, 0, 0, 0, 0 };

    private string inputedAnswer;

    public int[] correctAnswerOptions = { 2, 0, 1, 3, 2 };

    private float answeredCorrectlyCount;

    public float totalQuestions = 5;

    public TMP_Text accuracyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCurrentOption(int answerToChange) 
    {
        currentAnswerOptions[answerToChange] += 1;

        if(currentAnswerOptions[answerToChange] > 3) 
        {
            currentAnswerOptions[answerToChange] = 0;
        }

        if(answerToChange == 0) 
        {
            foreach(GameObject option in answer0Options) 
            {
                option.SetActive(false);
            }
            answer0Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }
        else if(answerToChange == 1) 
        {
            foreach (GameObject option in answer1Options)
            {
                option.SetActive(false);
            }
            answer1Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }
        else if(answerToChange == 2) 
        {
            foreach (GameObject option in answer2Options)
            {
                option.SetActive(false);
            }
            answer2Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }
        else if(answerToChange == 3) 
        {
            foreach (GameObject option in answer3Options)
            {
                option.SetActive(false);
            }
            answer3Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }

        else if (answerToChange == 4)
        {
            foreach (GameObject option in answer4Options)
            {
                option.SetActive(false);
            }
            answer4Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }
    }

    public void DecreaseCurrentOption(int answerToChange)
    {
        currentAnswerOptions[answerToChange] -= 1;

        if (currentAnswerOptions[answerToChange] < 0)
        {
            currentAnswerOptions[answerToChange] = 3;
        }

        if (answerToChange == 0)
        {
            foreach (GameObject option in answer0Options)
            {
                option.SetActive(false);
            }
            answer0Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }
        else if (answerToChange == 1)
        {
            foreach (GameObject option in answer1Options)
            {
                option.SetActive(false);
            }
            answer1Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }
        else if (answerToChange == 2)
        {
            foreach (GameObject option in answer2Options)
            {
                option.SetActive(false);
            }
            answer2Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }
        else if (answerToChange == 3)
        {
            foreach (GameObject option in answer3Options)
            {
                option.SetActive(false);
            }
            answer3Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }

        else if (answerToChange == 4)
        {
            foreach (GameObject option in answer4Options)
            {
                option.SetActive(false);
            }
            answer4Options[currentAnswerOptions[answerToChange]].SetActive(true);
        }
    }

    public void CheckReport() 
    {
        foreach (int i in correctAnswerOptions)
        {
            if (currentAnswerOptions[i] == correctAnswerOptions[i])
            {
                answeredCorrectlyCount += 1f;
            }
        }
        float reportAccuracy = (answeredCorrectlyCount / totalQuestions) * 100;
        accuracyText.text = reportAccuracy.ToString();
        FirebaseManager.instance.UpdateReportAccuracy(int.Parse(reportAccuracy.ToString()));
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
