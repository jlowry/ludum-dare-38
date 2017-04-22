using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ASmallWorld {
    public class MenuUI : MonoBehaviour {
        public GameObject victory;
        public GameObject defeat;
        public GameObject mainMenu;

        // Use this for initialization
        void Awake() { }


        public void Victory() {
            mainMenu.SetActive(false);
            victory.SetActive(true);
            defeat.SetActive(false);
        }

        public void Defeat() {
            mainMenu.SetActive(false);
            victory.SetActive(false);
            defeat.SetActive(true);
        }

        public void MainMenu() {
            mainMenu.SetActive(true);
            victory.SetActive(false);
            defeat.SetActive(false);
        }

        public void GamePlaying() {
            mainMenu.SetActive(false);
            victory.SetActive(false);
            defeat.SetActive(false);
        }
    }
}


