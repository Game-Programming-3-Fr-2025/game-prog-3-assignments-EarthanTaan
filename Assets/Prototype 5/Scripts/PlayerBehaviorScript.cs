using Unity.AppUI.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerBehaviorScript : MonoBehaviour
{
    public GameObject firingNode;
    public Rigidbody2D PlayerRB;
    public float drag;
    public float dampStrength;
    public GameObject bullet;

    public Camera Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drag = 0.5f;
        dampStrength = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerRB.angularDamping = dampStrength;
        PlayerRB.linearDamping = drag;

        // Screen-wrap
        // First, attach a FindMyKeys to the player's ship (in the form of a translation from the transform's world-position to a viewport-point).
        // Then, track the FindMyKeys variable to note when it exits the screen's bounds ( > 1 or < 0 ).
        // Update a target-position variable with the screen-wrapped coordinates.
        // Finally, always be assigning the ship's position from the target-position variable.
        if (Camera.WorldToViewportPoint(transform.position).x > 1 )
        {
            transform.position = Camera.ViewportToWorldPoint(new Vector3(0,0));
        }
        if (transform.position.x < -Screen.width * 0.5f)
        {
            transform.position.Set(Screen.width * 0.5f, transform.position.y, 0);
        }
        if (transform.position.y > Screen.height * 0.5f)
        {
            transform.position.Set(transform.position.x, -Screen.height * 0.5f, 0);
        }
        if (transform.position.y < -Screen.height * 0.5f)
        {
            transform.position.Set(transform.position.x, Screen.height * 0.5f, 0);
        }
        
        // T is for "Test"
        if (Input.GetKeyDown(KeyCode.T))
        {
            print("The screen's dimensions are " + Screen.width + ", " + Screen.height + "/n Player Position Is Now: "+transform.position);
        }
        
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(bullet, firingNode.transform.position, firingNode.transform.rotation);
            //Bullet velocity is handled by the bullet's own script; when "Awake"
            Destroy(newBullet, 5);
        }

        
    }
}
