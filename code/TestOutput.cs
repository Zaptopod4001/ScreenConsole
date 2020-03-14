using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eses.ScreenConsole
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class TestOutput : MonoBehaviour
    {
        public float delayBetween = 0.5f;
        float delayNow;

        void Start()
        {
            Debug.Log("Program started!");
        }

        void Update()
        {
            // Create some output values to debug console
            delayNow += Time.deltaTime;

            if (delayNow > delayBetween)
            {
                delayNow = 0;
                Debug.Log("Updating, time: " + Time.time);
            }
        }

        void OnEnable()
        {
            Debug.Log("Program enabled!");
        }

        void OnDisable()
        {
            Debug.Log("Program disabled!");
        }
    }

}