using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA {
    public class Helper : MonoBehaviour
    {
        [Range(0, 1)]
        public float vertical;

        public string[] attacks;
        public bool playAnim;


        public bool enableRM;

        Animator anim;


    void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            enableRM = !anim.GetBool("canMove");
            anim.applyRootMotion = enableRM;

            if (enableRM)
                return;

            if (playAnim)
            {
                string targetAnim;
                int r = Random.Range(0, attacks.Length);
                targetAnim = attacks[r];
                

                vertical = 0;
                anim.CrossFade(targetAnim, 0.2f);
              //  anim.SetBool("canMove",false);
                //enableRM = true;
                playAnim = false;
            }

            anim.SetFloat("vertical", vertical);
        }
    }
}