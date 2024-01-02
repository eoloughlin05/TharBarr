using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    private float movingSpeed;

    private void Start()
    {
        movingSpeed = 5;
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Increment for maxShotDistance
    public float GetMovingSpeed() => movingSpeed;


    public void UpdateSpeed()
    {
        if (scoreManager.GetScore() % 2 == 0)
        {
            movingSpeed += 5;
        }
    }

    public void ResetSpeed()
    {
        movingSpeed = 5;
    }
}

