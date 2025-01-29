using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 10.0f;
    public float acceleration = 6f;
    public float deceleration = 6f;
    // Bounds for the player's playing field
    public float minX = -4f;
    public float maxX = 0f; // Adjust this to split the field between players
    public float minY = -6f;
    public float maxY = 6f;
    private Rigidbody2D rb2d;
    private Vector2 targetVelocity = Vector2.zero;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = Vector2.zero;
        var vel = rb2d.linearVelocity;
        if (Input.GetKey(moveUp))
        {
            targetVelocity.y = speed;
        }

        else if (Input.GetKey(moveDown))
        {
            targetVelocity.y = -speed;
        }
        if (Input.GetKey(moveLeft))
        {
            targetVelocity.x = -speed;
        }
        else if (Input.GetKey(moveRight))
        {
            targetVelocity.x = speed;
        }
        //interpolate current velocity toward target velocity
        rb2d.linearVelocity = Vector2.Lerp(rb2d.linearVelocity, targetVelocity,acceleration * Time.deltaTime);

        //clamp position within bounds
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
    void OnDrawGizmos()
    {
        // Set Gizmos color to make the bounds stand out
        Gizmos.color = Color.red;

        // Draw lines to form the rectangular bounds
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(minX, maxY, 0)); // Left
        Gizmos.DrawLine(new Vector3(maxX, minY, 0), new Vector3(maxX, maxY, 0)); // Right
        Gizmos.DrawLine(new Vector3(minX, maxY, 0), new Vector3(maxX, maxY, 0)); // Top
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(maxX, minY, 0)); // Bottom
    }

}

