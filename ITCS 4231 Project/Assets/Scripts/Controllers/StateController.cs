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
        public Vector3 moveDir;

        [SerializeField]private float moveSpeed = 10f;
        public float runSpeed = 15f;
        public float rotateSpeed = 20;
        public float toGround = 0.5f;

        public bool run;
        public bool test1;
        public bool test2;
        


        public GameObject activeModel;
        public Animator anim;
        public Rigidbody rigid;
        

        public float delta;
        public LayerMask ignoreLayers;

        public void Init()
        {
            SetupAnimator();
            rigid = GetComponent<Rigidbody>();
            rigid.angularDrag = 999;
            rigid.drag = 4;
            rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            gameObject.layer = 8;
            ignoreLayers = ~(1 << 9);
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
        

        /// <summary>
        /// Handles movement Animations, and calculates movement
        /// </summary>
        /// <param name="d"></param>
        public void FixedTick(float d)
        {
            delta = d;

            if (moveAmount > 0)
            {
                rigid.drag = 0;
            } else
            {
                rigid.drag = 4;
            }

            float targetSpeed = moveSpeed;
            if (run)
                targetSpeed = runSpeed;


            rigid.velocity = moveDir*(targetSpeed*moveAmount);

            Vector3 targetDir = moveDir;
            targetDir.y = 0;
            if (targetDir == Vector3.zero)
                targetDir = transform.forward;
            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, delta * moveAmount * rotateSpeed);
            transform.rotation = targetRotation;
            if (test1)
            {
                Debug.Log("Fixed Tick reached");
                test1 = false;
            }
            HandleMovementAnimations();
        }
        

        public void HandleMovementAnimations()
        {

            anim.SetFloat("vertical", moveAmount);

        }


        //*****Unfinished***** 
        public bool onGround()
        {
            bool r = false;

            Vector3 origin = transform.position + Vector3.up * toGround;
            Vector3 dir = -Vector3.up;
            float dis = toGround - 0.3f;
            RaycastHit hit;
            if (Physics.Raycast(origin, dir, out hit, dis, ignoreLayers)){
                r = true;
                Vector3 targetPosition = hit.point;
                transform.position = targetPosition;
            }

            return r;
           


        }

    }
}
