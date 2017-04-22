using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ASmallWorld {
    public class CameraController : MonoBehaviour {
        private Vector3 offset;
        private Transform player;

        // Use this for initialization
        void Awake() {
            // Get the players transform
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Start() {
            offset = transform.position - player.position;
        }

        // LateUpdate is called once per frame
        void LateUpdate() {
            transform.position = player.transform.position + offset;
        }
    }
}
