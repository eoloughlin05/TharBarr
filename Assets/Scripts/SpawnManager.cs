using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] optionPrefabs;
    public GameObject[] powerups;
    public Text question;
    public static bool spawnQuestion;

    private float[] spawnZLocation = { -8, 0, 8 };
    private Question[] questions;
    private GameManager gameManager;
    private int questionNumber = 0;
    [SerializeField]
    private GameObject questionUIText;

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
            if (Random.Range(0f, 1f) < 0.7f) 
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
        questionUIText.SetActive(true);
        question.text = questions[questionNumber].QuestionText;

        for (int questionOption = 0; questionOption < 3; questionOption++)
        {
            SetOptionText(questionOption);
            SetOptionTag(questionOption);

            Instantiate(optionPrefabs[questionOption], new Vector3(18, 1, spawnZLocation[questionOption]), optionPrefabs[questionOption].transform.rotation);
        }

        gameManager.SetSpawnQuestion(false);
        questionNumber++;
    }

    void SpawnPowerup()
    {
        questionUIText.SetActive(false);
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


    private void SetOptionTag(int option)
    {
        optionPrefabs[option].tag = questions[questionNumber].Options[option].IsCorrect ? "Correct" : "Incorrect";
    }

    private void SetOptionText(int option)
    {
        optionPrefabs[option].GetComponentInChildren<TextMesh>().text = questions[questionNumber].Options[option].OptionText;
    }
}
