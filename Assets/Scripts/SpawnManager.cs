using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] optionPrefabs;
    public Text question;
    public static bool spawnQuestion;

    private float[] spawnZLocation = { -7, 0, 7 };
    private Question[] questions;
    private GameManager gameManager;
    private int questionNumber = 0;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.SetSpawnQuestion(true);
        var getQuestions = new Questions();
        questions = getQuestions.GetQuestions();
    }

    void Update()
    {
        if(gameManager.GetSpawnQuestion() && questionNumber < questions.Length && gameManager.doesPlayerHaveLives)
        {

            question.text = questions[questionNumber].QuestionText;
            for (int j = 0; j < optionPrefabs.Length; j++)
            {
                SetOptionText(j);
                SetOptionTag(j);

                Instantiate(optionPrefabs[j], new Vector3(18, 1, spawnZLocation[j]), optionPrefabs[j].transform.rotation);
            }

            gameManager.SetSpawnQuestion(false);
            questionNumber++;
        }
        
    }

    private void SetOptionTag(int j)
    {
        optionPrefabs[j].tag = questions[questionNumber].Options[j].IsCorrect ? "Correct" : "Incorrect";
    }

    private void SetOptionText(int j)
    {
        optionPrefabs[j].GetComponentInChildren<TextMesh>().text = questions[questionNumber].Options[j].OptionText;
    }
}
