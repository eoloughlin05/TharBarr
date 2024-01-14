using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float lowerBound = 54;
    private GameManager gameManager;
    private DifficultyManager difficultyManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficultyManager = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
    }

    void Update()
    {
        float speedMultiplier = 1.0f;

        // Check if the space bar is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            speedMultiplier = 2.0f;
        }

        transform.Translate(Vector3.right * Time.deltaTime * difficultyManager.GetMovingSpeed() * speedMultiplier);

        if (transform.position.x > lowerBound)
        {
            Destroy(gameObject);
            gameManager.SetSpawnQuestion(true);
        }
    }
}
