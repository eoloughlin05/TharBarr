using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCategory : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public string category;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetCategory);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void SetCategory()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(category);
    }

    void Update()
    {
        
    }
}
