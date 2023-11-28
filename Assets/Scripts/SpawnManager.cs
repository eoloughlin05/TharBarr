using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] optionPrefabs;
    public GameObject[] powerups;
    public Text question;
    public static bool spawnQuestion;

    private float[] spawnZLocation = { -7, 0, 7 };
    private Question[] questions;
    private GameManager gameManager;
    private int questionNumber = 0;

    public float cubeWidth = 6f;
    public TextMesh questionTextInObject;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.SetSpawnQuestion(true);
        var getQuestions = new Questions();
        questions = getQuestions.GetQuestions(gameManager.questionsCategory);
    }

    void Update()
    {
        if (gameManager.GetSpawnQuestion() && questionNumber < questions.Length && gameManager.doesPlayerHaveLives)
        {
            // Randomly decide whether to spawn a question or a powerup
            if (Random.Range(0f, 1f) < 0.1f) // Adjust the probability as needed (e.g., 0.8 means 80% chance for a question)
            {
                SpawnQuestion();
            }
            else
            {
                SpawnPowerup();
            }
        }
    }

    void SpawnQuestion()
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

    void SpawnPowerup()
    {
        GameObject selectedPowerup = GetRandomPowerup();
        var randomZLocation = Random.Range(-11, 11);

        Instantiate(selectedPowerup, new Vector3(9, 1, randomZLocation ), Quaternion.identity);

        gameManager.SetSpawnQuestion(false);
    }

    GameObject GetRandomPowerup()
    {
        // Generate a random index within the range of the powerups array
        int randomIndex = Random.Range(0, powerups.Length);

        // Return the selected powerup
        return powerups[randomIndex];
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
