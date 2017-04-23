using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ASmallWorld {
    public class Player : MonoBehaviour {
        public float speed = 4.0F;
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
            if (controller.isGrounded)
            {

                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                var m_TurnAmount = Mathf.Atan2(moveDirection.x, moveDirection.z);
                // help the character turn faster (this is in addition to root rotation in the animation)
                //float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
                transform.Rotate(0, m_TurnAmount * 100.0F * Time.deltaTime, 0);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }



            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);           
        }
    }
}


