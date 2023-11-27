using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool spawnQuestion = false;
    public bool doesPlayerHaveLives;
    public TextMeshProUGUI gameOverText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject questionUIText;
    public Button restartButton;

    public void Start()
    {
        doesPlayerHaveLives = true;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        player.SetActive(false);
        questionUIText.SetActive(false);
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
