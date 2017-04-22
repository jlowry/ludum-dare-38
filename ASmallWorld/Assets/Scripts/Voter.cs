using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ASmallWorld {
    public class Voter : MonoBehaviour {
        private float[] opinion;

        void Awake() {
            opinion = new float[4];
            for (var i = 0; i < 4; i++) {
                opinion[i] = 0.0F;
            }
        }

        public void AddOpinion(Faction faction, float value) {
            opinion[(int) faction] += value;
        }

        public Faction GetFavouredFaction() {
            int favoured = 0;
            for (var i = 0; i < 4; i++) {
                if (opinion[i] > opinion[favoured]) {
                    favoured = i;
                }
            }
            return (Faction) favoured;
        }
    }
}

