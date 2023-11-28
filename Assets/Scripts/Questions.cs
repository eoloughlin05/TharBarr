using Assets.Scripts.Models;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Questions

    //WIP - Example questions with various topics for now for testing and alpha submission purposes. A more niche set of questions and answers will be developed for the next/final submission.
{ 
    public Question[] GetQuestions(string category)
    {
        string folderPath = Path.Combine(Application.dataPath, "Questions");
        string filePath = Path.Combine(folderPath, $"{category}.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            // Deserialize JSON data to an array of Question objects
            var questions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Question>>(json).ToArray(); ;

            if (questions != null && questions.Length > 0)
            {
                Shuffle(questions);
                return questions;
            }
            else
            {
                Debug.LogError("Failed to deserialize questions from JSON.");
            }
        }
        else
        {
            Debug.LogError("Questions JSON file not found at: " + filePath);
        }

        return null;
    }
    private static System.Random random = new System.Random();
    private static void Shuffle<T>(T[] array)
    {
        if (array is null)
            throw new ArgumentNullException(nameof(array));

        for (int i = 0; i < array.Length - 1; ++i)
        {
            int r = random.Next(i, array.Length);
            (array[r], array[i]) = (array[i], array[r]);
        }
    }
}
