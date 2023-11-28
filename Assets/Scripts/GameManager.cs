using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Assets.Scripts.Helpers;

public class GameManager : MonoBehaviour
{
    private bool spawnQuestion = false;
    public bool doesPlayerHaveLives;
    public TextMeshProUGUI gameOverText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject spawnManager;
    [SerializeField]
    private GameObject questionUIText;
    public Button restartButton;
    private ScoreManager scoreManager;
    private LivesManager livesManager;
    public GameObject titleScreen;
    public string questionsCategory = "";
    [SerializeField]
    private GameObject scoreText;
    [SerializeField]
    private GameObject livesText;

    public void Start()
    {
        doesPlayerHaveLives = true;
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        livesManager = GameObject.Find("LivesManager").GetComponent<LivesManager>();
    }

    public void StartGame(string category)
    {
        doesPlayerHaveLives = true;
        scoreManager.ResetScore();
        livesManager.ResetLives();
        titleScreen.SetActive(false);
        questionsCategory = category;
        player.SetActive(true);
        spawnManager.SetActive(true);
        questionUIText.SetActive(true);
        scoreText.SetActive(true);
        livesText.SetActive(true);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        player.SetActive(false);
        questionUIText.SetActive(false);
        scoreText.SetActive(false);
        livesText.SetActive(false);
        doesPlayerHaveLives = false;
        restartButton.gameObject.SetActive(true);
    }

    public void SetSpawnQuestion (bool value)
    {
        spawnQuestion = value;
    }

    public bool GetSpawnQuestion ()
    {
        return spawnQuestion;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
