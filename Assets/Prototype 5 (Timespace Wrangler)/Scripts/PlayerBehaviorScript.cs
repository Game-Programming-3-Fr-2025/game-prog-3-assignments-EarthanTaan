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

        Vector3
            FindMyKeys; // Making this "private" was breaking it. I guess I still don't understand what "private" does.

        public Camera Camera;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            PlayerRB.angularDamping = dampStrength;
            PlayerRB.linearDamping = drag;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // Screen-wrap
            // First, attach a FindMyKeys variable to the player's ship (in the form of a translation from the transform's world-position to a viewport-point).
            FindMyKeys = Camera.WorldToViewportPoint(transform.position);

            // Then, track the FindMyKeys variable to note when it exits the viewport's bounds ( > 1 or < 0 ).
            if (FindMyKeys.x > 1.0f)
            {
                FindMyKeys.x = 0.0f;
            }
            if (FindMyKeys.x < 0.0f)
            {
                FindMyKeys.x = 1.0f;
            }
            if (FindMyKeys.y > 1.0f)
            {
                FindMyKeys.y = 0.0f;
            }
            if (FindMyKeys.y < 0.0f)
            {
                FindMyKeys.y = 1.0f;
            }

            // Finally, assign the transform's position to copy the values of the FindMyKeys but translated from Viewport coordinates to a World Point.
            transform.position = Camera.ViewportToWorldPoint(FindMyKeys);

            //Basic controls: rotate counter/clock-wise, thrust and shoot
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

            // Something is slowing down the rate of fire for some reason. This is new behavior.
            // (I mean I don't actually want a shooting mechanic so maybe this isn't a problem I need to solve.)
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     GameObject newBullet = Instantiate(bullet, firingNode.transform.position, firingNode.transform.rotation);
            //     //Bullet velocity is handled by the bullet's own script; when "Awake"
            //     Destroy(newBullet, 3);
            // }


        }
    }
}