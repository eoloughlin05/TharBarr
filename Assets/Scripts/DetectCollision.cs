using Assets.Scripts.Helpers;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private LivesManager livesManager;
    private ScoreManager scoreManager;

    void Start()
    {
        livesManager = GameObject.Find("LivesManager").GetComponent<LivesManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (gameObject.CompareTag("Correct"))
            scoreManager.UpdateScore(1);

        if (gameObject.CompareTag("Incorrect"))
            livesManager.UpdateLives(-1);

        if (gameObject.CompareTag("BonusPoint"))
            scoreManager.UpdateScore(1);

        if (gameObject.CompareTag("ExtraLife"))
            livesManager.UpdateLives(1);

        if (gameObject.CompareTag("LoseAPoint"))
            scoreManager.UpdateScore(-1);

        if (gameObject.CompareTag("LoseALife"))
            livesManager.UpdateLives(-1);

    }
}
