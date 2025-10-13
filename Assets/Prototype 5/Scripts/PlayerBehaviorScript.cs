using Unity.AppUI.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerBehaviorScript : MonoBehaviour
{
    public GameObject firingNode;
    public Rigidbody2D PlayerRB;
    public float drag = 0.5f;
    public float dampStrength = 5;
    public GameObject bullet;
    Vector3 FindMyKeys = new Vector3(); // Making these  (FindMyKeys & TargetPos)
    Vector3 TargetPos =  new Vector3(); // "private" was making it not work.
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
            transform.position = Camera.ViewportToWorldPoint(FindMyKeys);
        }
        if (FindMyKeys.x < 0.0f)
        {
            FindMyKeys.x = 1.0f;
            transform.position = Camera.ViewportToWorldPoint(FindMyKeys);
        }
        if (FindMyKeys.y > 1.0f)
        {
            FindMyKeys.y = 0.0f;
            transform.position = Camera.ViewportToWorldPoint(FindMyKeys);
        }
        if (FindMyKeys.y < 0.0f)
        {
            FindMyKeys.y = 1.0f;
            transform.position = Camera.ViewportToWorldPoint(FindMyKeys);
        }
        // Update a target-position variable with the screen-wrapped coordinates. (Isn't this redundant? Test.)
//        TargetPos = Camera.ViewportToWorldPoint(FindMyKeys);
        
        // Finally, always be assigning the ship's position from the target-position variable. (also redundant?)
//        transform.position = TargetPos;
        
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
        
        // Something is slowing down the rate of fire for some reason. This is new behavior. 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(bullet, firingNode.transform.position, firingNode.transform.rotation);
            //Bullet velocity is handled by the bullet's own script; when "Awake"
            Destroy(newBullet, 3);
        }

        
    }
}
