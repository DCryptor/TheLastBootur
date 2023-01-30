using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace deatherror
{

    public class CharacterControl : MonoBehaviour
    {
        [HideInInspector] public InputManager inputManager;
        [HideInInspector] public Rigidbody rb;
        [HideInInspector] public Animator anim;
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public CapsuleCollider capsule;
        public GameObject ragdoll;
        public bool death;
        public bool isMove;
        public LayerMask groundLayer;
        public bool isGrounded;
        public bool box;
        public RaycastHit hit;
        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();
            capsule = GetComponent<CapsuleCollider>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                inputManager.Jump = true;
            }


            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Horizontal") == 0)
            {
                inputManager.MoveLeft = false;
                inputManager.MoveRight = false;
                return;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                inputManager.MoveLeft = false;
                inputManager.MoveRight = true;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                inputManager.MoveRight = false;
                inputManager.MoveLeft = true;

            }
            direction.z = Input.GetAxis("Horizontal");

            if (death)
            {
                Vector3 ragdoll_pos = new Vector3(transform.position.x, capsule.bounds.min.y, transform.position.z);
                Destroy(gameObject);
                GameObject create_ragdoll = Instantiate(ragdoll, ragdoll_pos, Quaternion.LookRotation(transform.forward));
            }
        }

        void FixedUpdate()
        {
            Vector3 groundCheckPos = new Vector3(this.transform.position.x, capsule.bounds.min.y, this.transform.position.z);
            isGrounded = Physics.CheckSphere(groundCheckPos, 0.3f, groundLayer);

            Vector3 raycasy_pos1 = new Vector3(transform.position.x, capsule.bounds.center.y, transform.position.z);
            if (Physics.Raycast(raycasy_pos1, transform.forward, out hit, 0.5f))
            {
                if (hit.collider.GetComponent<Box>())
                {
                    box = true;
                }
                else
                {
                    box = false;
                }
            }
            else
            {
                box = false;
            }
        }
    }
}
