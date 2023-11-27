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

    }
}
