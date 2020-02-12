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

        public GameObject activeModel;
        public Animator anim;
        public Rigidbody rigid;
        public Vector3 moveDir;

        public float delta;

        public void Init()
        {
            SetupAnimator();
            rigid = GetComponent<Rigidbody>();
            
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
