using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ASmallWorld {
    public class GameController : MonoBehaviour {
        private enum GameState {
            LOADING,
            MAIN_MENU,
            PLAYING,
            END
        }


        private GameState state = GameState.LOADING;

        private Timer timer;
        private Player player;
        private OpinionPoller opinionPoller;
        private MenuUI menuUI;

        void Awake() {
            //DontDestroyOnLoad(transform.gameObject);
        }

        // Use this for initialization
        void Start() {
            WireComponents();
            MainMenu();
        }

        public void ResetGame() {
            state = GameState.LOADING;
            SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);
        }

        private void WireComponents() {
            menuUI = GameObject.FindGameObjectWithTag("MenuUI").GetComponent<MenuUI>();
            timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            opinionPoller = GameObject.FindGameObjectWithTag("OpinionPoller").GetComponent<OpinionPoller>();
            timer.TimesUp += TimesUp;
        }

        public void MainMenu() {
            menuUI.MainMenu();
            state = GameState.MAIN_MENU;
        }

        public void StartGame() {
            menuUI.GamePlaying();
            state = GameState.PLAYING;
            timer.Reset();
            timer.StartTimer();
        }

        void TimesUp() {
            if (player.faction == opinionPoller.GetWinningFaction()) {
                menuUI.Victory();
            } else {
                menuUI.Defeat();
            }
            state = GameState.END;
            
        }



    }
}

