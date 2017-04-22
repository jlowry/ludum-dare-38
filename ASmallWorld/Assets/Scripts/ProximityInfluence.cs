using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ASmallWorld {
    public class ProximityInfluence : MonoBehaviour {
        private Voter voter;

        void Awake() {
            voter = GetComponentInParent<Voter>();
        }

        void OnTriggerEnter(Collider other) {
            if (other.tag.Equals("Player")) {
                var player = other.gameObject.GetComponent<Player>();
                voter.AddOpinion(player.faction, 10.0F);
            }
        }
    }
}

