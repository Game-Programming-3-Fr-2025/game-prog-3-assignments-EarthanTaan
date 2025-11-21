using Unity.AppUI.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace PrototypeFive
{
    public class PlayerBehaviorScript : MonoBehaviour
    {
        public GameObject firingNode;
        public Rigidbody2D PlayerRB;
        public float drag = 0.5f;
        public float dampStrength = 5;
        public GameObject bullet;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            PlayerRB.angularDamping = dampStrength;
            PlayerRB.linearDamping = drag;
        }

        void FixedUpdate()
        {
            // Basic controls: rotate counter/clock-wise, thrust and shoot.
            // Note: (I may want to split this into 'listening' in Update() and 'execution' in FixedUpdate() but
            // I won't if I don't need to. It's a gamefeel issue.)
            
            if (Input.GetKey(KeyCode.A))
            {
                PlayerRB.AddTorque(1);
            }

            if (Input.GetKey(KeyCode.D))
            {
                PlayerRB.AddTorque(-1);
            }

            if (Input.GetKey(KeyCode.W))
            {
                PlayerRB.AddForce(transform.up * 10, ForceMode2D.Force);
            }
        }
    }
}