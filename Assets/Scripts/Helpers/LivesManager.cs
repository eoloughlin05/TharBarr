using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    internal class LivesManager : MonoBehaviour
    {
        private int lives = 3;
        public TextMeshProUGUI livesUIDisplay;

        private void Update()
        {
            livesUIDisplay.text = "Lives: " + lives;
        }
        public void UpdateLives(int value)
        {
            lives += value;
        }
    }
}
