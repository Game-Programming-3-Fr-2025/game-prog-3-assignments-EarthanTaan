using System;
using UnityEngine;

public class bulletBehaviorScript : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        rb.linearVelocity = Vector2.up * 10;
    }

    // Update is called once per frame
    void Update()
    {
        // Collision stuff.
    }
}
