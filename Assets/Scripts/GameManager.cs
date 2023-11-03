using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool spawnQuestion = false;

    public void SetSpawQuestion (bool value)
    {
        spawnQuestion = value;
    }

    public bool GetSpawnQuestion ()
    {
        return spawnQuestion;
    }
    
}
