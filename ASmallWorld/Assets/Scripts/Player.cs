using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ASmallWorld {
    public class Player : MonoBehaviour {
        public float speed = 4.0F;
        public float gravity = 20.0F;
        private CharacterController controller;
		private Animator anim;
		private Transform camera;

        private Vector3 moveDirection = Vector3.zero;
        public Faction faction { get; set; }
	private static readonly int SPEED = Animator.StringToHash ("Speed");

        // Use this for initialization
        void Awake() {
			camera = GameObject.FindWithTag ("MainCamera").transform;	
            controller = GetComponent<CharacterController>();
			anim = GetComponentInChildren<Animator> ();
            faction = Faction.YELLOW;
        }

        // Update is called once per frame
        void Update() {
            if (controller.isGrounded) {
				var cameraForward = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
				var v = Input.GetAxis("Vertical");
				var h = Input.GetAxis("Horizontal");

				moveDirection = v*cameraForward + h*camera.right;
                
				var turnAmount = Mathf.Atan2(moveDirection.x, moveDirection.z);
                transform.Rotate(0, turnAmount * 100.0F * Time.deltaTime, 0);
                
				moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
				
				if (moveDirection.sqrMagnitude > 0.1F) {
					anim.SetFloat (SPEED, 1.0F);
				} else {
					anim.SetFloat (SPEED, 0.0F);
				}
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);           
        }
    }
}


