using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ASmallWorld {
    public class GameController : MonoBehaviour {
        private Timer timer;
        private Player player;
        private OpinionPoller opinionPoller;

        void Awake() {
            DontDestroyOnLoad(transform.gameObject);
        }

        // Use this for initialization
        void Start() {
            timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            opinionPoller = GameObject.FindGameObjectWithTag("OpinionPoller").GetComponent<OpinionPoller>();
            timer.TimesUp += TimesUp;
            StartGame();
        }


        void StartGame() {
            timer.Reset();
            timer.StartTimer();
        }

        void TimesUp() {
            if (player.faction == opinionPoller.GetWinningFaction()) {
                Debug.Log("Win");
            } else {
                Debug.Log("Lose");
            }
        }
    }
}

