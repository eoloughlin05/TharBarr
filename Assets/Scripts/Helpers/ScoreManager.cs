using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class ScoreManager : MonoBehaviour
    {
        private int score = 0;
        public TextMeshProUGUI scoreUIDisplay;

        private void Update()
        {
            scoreUIDisplay.text = "Score: " + score;
        }
        public void UpdateScore(int value)
        {
            score += value;
        }
    }
}
