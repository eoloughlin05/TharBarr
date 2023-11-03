using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions
{ 
    public Question[] GetQuestions()
    {
        var questions = new Question[]
        {
            new Question
            {
                QuestionId = 1,
                QuestionText = "2 + 2 = ?",
                Options = new Option[]
                {
                    new Option {OptionId = 1, OptionText = "3", IsCorrect = false},
                    new Option {OptionId = 2, OptionText = "4", IsCorrect = true},
                    new Option {OptionId = 3, OptionText = "5", IsCorrect = false}
                }
            },
            new Question
            {
                QuestionId = 2,
                QuestionText = "Which of the below words is spelt correctly?",
                Options = new Option[]
                {
                    new Option {OptionId = 1, OptionText = "Banana", IsCorrect = true},
                    new Option {OptionId = 2, OptionText = "banna", IsCorrect = false},
                    new Option {OptionId = 3, OptionText = "banan", IsCorrect = false}
                }
            },
            new Question
            {
                QuestionId = 2,
                QuestionText = "5 - 3 = ?",
                Options = new Option[]
                {
                    new Option {OptionId = 1, OptionText = "1", IsCorrect = false},
                    new Option {OptionId = 2, OptionText = "4", IsCorrect = false},
                    new Option {OptionId = 3, OptionText = "2", IsCorrect = true}
                }
            }
        };
        Shuffle(questions);
        return questions;
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
