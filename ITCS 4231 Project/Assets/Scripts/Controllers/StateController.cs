using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class StateController : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        private float moveSpeed;

        public GameObject activeModel;
        public Animator anim;
        public Rigidbody rigid;
        public Vector3 moveDir;

        public float delta;

        public void Init()
        {
            SetupAnimator();
            rigid = GetComponent<Rigidbody>();
            moveSpeed = 10f;
        }

        public void Move()
        {
            Vector3 inputVector = Vector3.zero;

            // Check for movement input
            if (Input.GetKey(KeyCode.UpArrow))
            {
                inputVector += Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                inputVector += Vector3.back;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputVector += Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                inputVector += Vector3.right;
            }

            if (inputVector != Vector3.zero)
            {

                // Normalize input vector to standardize movement speed
                inputVector.Normalize();
                inputVector *= moveSpeed;
                rigid.velocity = inputVector;
                // Face player along movement vector
               


            }
            else
            {
                rigid.velocity = Vector3.zero;
            }
        }

        void SetupAnimator()
        {
            if (activeModel == null)
            {
                anim = GetComponentInChildren<Animator>();
                if (anim == null)
                {
                    Debug.Log("No Model Found");
                }
                else
                {
                    activeModel = anim.gameObject;
                }
            }

            if (anim == null)
            {
                anim = activeModel.GetComponent<Animator>();
            }
            anim.applyRootMotion = false;
        }
        
        public void FixedTick(float d)
        {
            delta = d;

            rigid.velocity = moveDir;
        }
        

    }
}
