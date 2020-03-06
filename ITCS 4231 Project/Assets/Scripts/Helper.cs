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

        

        Animator anim;
    void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (playAnim)
            {
                string targetAnim;
                int r = Random.Range(0, attacks.Length);
                targetAnim = attacks[r];
                

                vertical = 0;
                anim.CrossFade(targetAnim, 0.2f);
                playAnim = false;
            }

            anim.SetFloat("vertical", vertical);
        }
    }
}