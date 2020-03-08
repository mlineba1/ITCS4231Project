using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class InputController : MonoBehaviour
    {
        float horizontal;
        float vertical;
       
        StateController states;
        CameraController camController;
       


        float delta;


        void Start()
        {
            states = GetComponent<StateController>();
            states.Init();

           

            camController = CameraController.singleton;
            camController.Init(this.transform);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;
            
            GetInput();
            UpdateStates();
            states.FixedTick(delta);

           

        }

        void Update()
        {
            camController.Tick(delta);
        }


        /// <summary>
        /// Player Movement and button input
        /// </summary>
            void GetInput()
        {
            if (Input.GetMouseButton(0))
            {
                states.anim.SetBool("Attacking", true);
            }

         
            
             vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }


        /// <summary>
        /// Calculated movement
        /// </summary>
        void UpdateStates()
        {
            states.horizontal = horizontal;
            states.vertical = vertical;

            Vector3 v =  vertical * camController.transform.forward;
            Vector3 h = horizontal * camController.transform.right;
           
            states.moveDir = (v + h).normalized;
           
            float m = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            states.moveAmount = Mathf.Clamp(m,0,1);
           
            
           
            


            
        }

    }
}
