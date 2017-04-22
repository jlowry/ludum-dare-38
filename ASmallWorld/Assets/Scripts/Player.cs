﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ASmallWorld {
    public class Player : MonoBehaviour {
        public float speed = 10.0F;
        public float gravity = 20.0F;
        private CharacterController controller;

        private Vector3 moveDirection = Vector3.zero;
        public Faction faction { get; set; }

        // Use this for initialization
        void Awake() {
            controller = GetComponent<CharacterController>();
            faction = Faction.YELLOW;
        }

        // Update is called once per frame
        void Update() {
            if (controller.isGrounded) {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}


