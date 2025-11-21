using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace PrototypeFive
{
    // A Game Manager that can use static variables to control the game without being invoked per-script.

    public class GameManager : MonoBehaviour
    {
        // It's public, and static, so its parameters can be -read- from anywhere easily,
        // but -setting- the parameters within remains private (can only be done from within this script).
        public static GameManager Instance {  get; private set; }

        void Awake()    // Runs once, but before Start()
        {
            // Self-destruct if the GameManager sees its own doppelganger.
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        void Start()    // Runs once, before Update
        {
            
        }

        void Update()   // Runs each screen-refresh
        {
            
        }

        private void FixedUpdate()  // Runs each update-step, but adjusted for delta-time (divorced from framerate)
        { 
            
        }
    }
}