using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ASmallWorld {

    public delegate void TimerEnd();

    public class Timer : MonoBehaviour {
        public float roundDuration = 300.0F;
        private float remainingTime = 0.0F;
        private Clock clock;
        private bool timerRunning = false;

        public event TimerEnd TimesUp;

        void Awake() {
            clock = GameObject.Find("Clock").GetComponent<Clock>();
        }

        public void StartTimer() {
            timerRunning = true;
        }

        public void Reset() {
            remainingTime = roundDuration;
        }

        // Update is called once per frame
        void Update() {
            if (timerRunning) {
                remainingTime -= Time.deltaTime;
                if (remainingTime < 0.0F) {
                    remainingTime = 0.0F;
                    StopTimer();
                    if (TimesUp != null) {
                        TimesUp();
                    }
                }
                clock.SetRemainingTime(remainingTime);
            }
        }

        private void StopTimer() {
            timerRunning = false;
        }
    }
}

