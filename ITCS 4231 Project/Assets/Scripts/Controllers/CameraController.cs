using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    public class CameraController : MonoBehaviour
    {

        public bool lockon;
        public float followSpeed = 9;
        public float mouseSpeed = 6;

        public Transform target;
        public Transform pivot;
        public Transform camTrans;

        [SerializeField] float turnSmoothing = .1f;
        public float minAngle = -35;
        public float maxAngle = 35;

        float smoothX;
        float smoothXVelocity;
        float smoothY;
        float smoothYVelocity;

        public float lookAngle;
        public float tiltAngle;

        public void Init(Transform t)
        {
            target = t;
            camTrans = Camera.main.transform;
            pivot = camTrans.parent;
        }


        public void Tick(float d)
        {

            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");
            float targetSpeed = mouseSpeed;

            FollowTarget(d);
            HandleRotations(d, v, h, targetSpeed);

        }

        void FollowTarget(float d)
        {
            float speed = d * followSpeed;
            Vector3 targetPosition = Vector3.Lerp(transform.position, target.position, speed);
            transform.position = targetPosition;
        }

        void HandleRotations(float d, float v, float h, float targetSpeed)
        {
            if(turnSmoothing > 0)
            {
                smoothX = Mathf.SmoothDamp(smoothX, h, ref smoothXVelocity, turnSmoothing);
                smoothY = Mathf.SmoothDamp(smoothY, v, ref smoothYVelocity, turnSmoothing);
            }
            else
            {
                smoothX = h;
                smoothY = v;
            }

            if (lockon)
            {
                
            }

            lookAngle += smoothX * targetSpeed;
            transform.rotation = Quaternion.Euler(0, lookAngle, 0);

            tiltAngle -= smoothY * targetSpeed;
            tiltAngle = Mathf.Clamp(tiltAngle, minAngle, maxAngle);
            pivot.localRotation = Quaternion.Euler(tiltAngle, 0, 0);

        }

        public static CameraController singleton;
        private void Awake()
        {
            if(singleton != null)
            {
                Destroy(gameObject);
            } else
            {
                singleton = this;
                DontDestroyOnLoad(gameObject);

            }
        }
    }
}
