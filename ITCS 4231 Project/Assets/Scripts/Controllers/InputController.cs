using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class InputController : MonoBehaviour
    {
        float horizontal;
        float vertical;
        public float moveSpeed;
        StateController states;
        CameraController camController;
       


        float delta;


        void Start()
        {
            states = GetComponent<StateController>();
            states.Init();

            moveSpeed = 10f;

            camController = CameraController.singleton;
            camController.Init(this.transform);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;
            camController.Tick(delta);
            GetInput();
            UpdateStates();
            states.FixedTick(delta);

            //Timestamp 39:20

        }

        /* void Update()
         {
            delta = Time.deltaTime;
            camController.Tick(delta);
            
            GetInput();
            UpdateStates();
            states.FixedTick(delta);
        }*/

        void GetInput()
        {


           // states.Move();
            
             vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }



        void UpdateStates()
        {
            states.horizontal = horizontal;
            states.vertical = vertical;

            Vector3 v =  vertical * camController.transform.forward;
            Vector3 h = horizontal * camController.transform.right;
           
            states.moveDir = (v + h).normalized;
            states.moveDir *= moveSpeed;
            float m = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            states.moveAmount = Mathf.Clamp(m,0,5);
            
           
            


            
        }

    }
}
