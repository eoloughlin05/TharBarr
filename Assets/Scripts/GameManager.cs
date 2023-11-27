using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool spawnQuestion = false;
    public bool doesPlayerHaveLives;
    public TextMeshProUGUI gameOverText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject questionUIText;

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
    }

    public void SetSpawnQuestion (bool value)
    {
        spawnQuestion = value;
    }

    public bool GetSpawnQuestion ()
    {
        return spawnQuestion;
    }
    
}
