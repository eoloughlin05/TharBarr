using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Assets.Scripts.Helpers
{
    internal class LivesManager : MonoBehaviour
    {
        private int lives = 3;
        public TextMeshProUGUI livesUIDisplay;
        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void Update()
        {
            livesUIDisplay.text = "Lives: " + lives;
        }

        public void UpdateLives(int value)
        {
            lives += value;
            if(lives <= 0)
            {
                gameManager.GameOver();
            }
        }

        public void ResetLives()
        {
            lives = 3;
        }
    }
}
