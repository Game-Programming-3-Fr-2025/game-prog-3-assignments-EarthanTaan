using Unity.AppUI.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviorScript : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    public float drag;
    public float dampStrength;
    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drag = 0.5f;
        dampStrength = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRB.angularDamping = dampStrength;
        PlayerRB.linearDamping = drag;
        
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
            //figure out why thisn isn't working
            GameObject newBullet = Instantiate(bullet, transform.position, transform.localRotation + new Vector2());
        }

        
    }
}
