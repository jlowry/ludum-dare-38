using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ASmallWorld {
    public class OpinionPoller : MonoBehaviour {
        struct PollResult
        {
//            private struct FactionVotes: IComparable<FactionVotes> {
//                public Faction faction;
//                public float votes;
//
//
//                public FactionVotes(Faction faction, float votes) {
//                    this.faction = faction;
//                    this.votes = votes;
//                }
//
//                public int CompareTo(FactionVotes other) {
//                    return this.votes.CompareTo(other.votes);
//                }
//            }

            public float red;
            public float green;
            public float blue;
            public float yellow;

            //private FactionVotes[] results;

            public PollResult(float red, float green, float blue, float yellow) {
                this.red = red;
                this.green = green;
                this.blue = blue;
                this.yellow = yellow;
            }

        }


        private Voter[] voters;
        private InfluenceMeter influenceMeter;

        private IDictionary<Faction, float> votes;

        void Awake() {
            influenceMeter = GameObject.Find("InfluenceMeter").GetComponent<InfluenceMeter>();
            votes = new Dictionary<Faction, float>() {{Faction.RED, 0.0F}, { Faction.GREEN, 0.0F}, { Faction.BLUE, 0.0F}, { Faction.YELLOW, 0.0F}};
        }

        // Use this for initialization
        void Start() {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Voter");
            voters = new Voter[gos.Length];
            for (var i = 0; i < voters.Length; i++) {
                voters[i] = gos[i].GetComponent<Voter>();
            }
        }

        private PollResult PollVoters() {
            votes[Faction.RED] = 0.0F;
            votes[Faction.GREEN] = 0.0F;
            votes[Faction.BLUE] = 0.0F;
            votes[Faction.YELLOW] = 0.0F;
            float votesCast = 0.0F;
            for (var i = 0; i < voters.Length; i++) {
                Faction faction = voters[i].GetFavouredFaction();
                votes[faction] += 1.0F;
                votesCast += 1.0F;
            }
                      
            return new PollResult(votes[Faction.RED] / votesCast, votes[Faction.GREEN] / votesCast, votes[Faction.BLUE] / votesCast, votes[Faction.YELLOW] / votesCast);
        }

        // Update is called once per frame
        void Update() {
            var result = PollVoters();
            influenceMeter.SetPercentages(result.red, result.green, result.blue, result.yellow);
        }

        public Faction GetWinningFaction() {
            var result = PollVoters();
            var myList = votes.ToList();

            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            return myList[3].Key;
        }
    }
}

