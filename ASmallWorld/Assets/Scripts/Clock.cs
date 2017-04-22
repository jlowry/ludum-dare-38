using System;
using UnityEngine;
using UnityEngine.UI;

namespace ASmallWorld
{
    public class Clock: MonoBehaviour {
        private Text text;

        void Awake() {
            text = GetComponent<Text>();
        }

        public void SetRemainingTime(float remainingTime) {
            float orig = remainingTime / 60;
            float minutes = Mathf.Floor(orig);
            float seconds = 60 * (orig - minutes);
            text.text = String.Format("{0:00}:{1:00}", minutes, seconds); 
        }

    }
}